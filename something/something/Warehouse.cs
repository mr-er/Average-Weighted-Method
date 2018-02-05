using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace something
{

    //Program realizuje działanie metody średniej ważonej ceny ewidencyjnej dla pojedynczej pozycji magazynowej. 
    //więcej o metodzie http://www.findict.pl/slownik/metoda-sredniej-wazonej-ceny-ewidencyjnej-metoda-wyceny-zapasow (Data dostępu: 18/01/2018)

    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
            //Wczytanie transakcji
            loadDatabase();
            validateDBValues();
            calculateEverything();
            //W przypadku zamknięcia aplikacji zachowuje zmiany.
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        //Event wyłączający możliwość sortowania transakcji 
        private void dataGridWarehouse_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridWarehouse.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }



        //Wczytywanie pliku XML z operacjami na pozycji magazynowej i sprawdzenie danych
        private void loadDatabase()
        {
            try
            {
                string filePath = "db.xml";
                DBDataSet.ReadXml(filePath);
                dataGridWarehouse.DataSource = DBDataSet;
                dataGridWarehouse.DataMember = "transakcja";
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Nie można załadować bazy danych." + ex);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Nie można załadować bazy danych." + ex);
            }
        }
        
        //W przypadku zamknięcia programu zapisuje wartości w pliku XML. 
        private void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                string path = "db.xml";
                DataSet ds = (DataSet)dataGridWarehouse.DataSource;
                ds.WriteXml(path);
            }
            catch (System.NullReferenceException ex)
            {
                string time = DateTime.Now.ToString(" yyyy:MM:dd:h:mm:ss tt ");
                string message = time + " Wystąpił błąd podczas zapisu bazy danych! " + ex;
                File.AppendAllText("log.txt", message);
                MessageBox.Show(message);
            }
            catch 
            {
                string time = DateTime.Now.ToString(" yyyy:MM:dd:h:mm:ss tt ");
                string message = time + " Wystąpił nieznany błąd. ";
                File.AppendAllText("log.txt", message);
                MessageBox.Show(message);
            }
        }

        //Przycisk służący do usuwanie zaznaczonej transakcji 
        private void bDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridWarehouse.SelectedRows)
            {
                if(item.Index==0)
                {
                    MessageBox.Show("Nie można usunąć transakcji inwentaryzacji.");
                }
                else
                { 
                dataGridWarehouse.Rows.RemoveAt(item.Index);
                }
            }
            calculateEverything();
        }

        //Sprawdzanie poprawności danych
        private bool validateDBValues()
        {
            for (int x = 0; x < dataGridWarehouse.Rows.Count - 1; x++)
            {
                try
                {
                    //Sprawdzanie poprawności nazw transakcji 
                    if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() != "Przyjęcie" && dataGridWarehouse.Rows[x].Cells[0].Value.ToString() != "Wydanie"
                        && dataGridWarehouse.Rows[x].Cells[0].Value.ToString() != "Inwentaryzacja")
                    {
                        throw new ArgumentException("Invalid transaction");

                    }
                    //Test parsowania ceny zakupu
                    try
                    {
                        if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() == "Przyjęcie")
                        {
                            decimal.Parse(dataGridWarehouse.Rows[x].Cells[1].Value.ToString());
                        }
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid purchase price");
                    }
                    //Test parsowania ilości sztuk
                    try
                    {
                        decimal.Parse(dataGridWarehouse.Rows[x].Cells[2].Value.ToString());
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid quantity");
                    }
                    //Test parsowania ceny ewidencyjnej 
                    try
                    {
                        decimal.Parse(dataGridWarehouse.Rows[x].Cells[3].Value.ToString());
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid transaction price");
                    }
                    //Test parsowania wartości transakcji
                    try
                    {
                        decimal.Parse(dataGridWarehouse.Rows[x].Cells[4].Value.ToString());
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid transaction total value");
                    }
                    //Test parsowania wartości stanu magazynowego pozycji 
                    try
                    {
                        decimal.Parse(dataGridWarehouse.Rows[x].Cells[5].Value.ToString());
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid transaction OnStock Quantity");
                    }
                }
                catch (Exception ex)
                {
                    int iterator = x;
                    MessageBox.Show("Wystąpił błąd poprawności danych w wierszu " + (iterator + 1) + ": \n" + ex);
                    return false;
                }
            }
            return true;
        }

        //Stan magazynowy pozycji
        private decimal onStockQuantity = 0.00m;

        //Obliczanie stanu magazynowego 
        private void calculateOnStockValue()
        {
            onStockQuantity = 0.00m;
            for (int x = 0; x < dataGridWarehouse.Rows.Count; x++)
            {
                if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() == "Przyjęcie")
                {
                    onStockQuantity = onStockQuantity + decimal.Parse(dataGridWarehouse.Rows[x].Cells[2].Value.ToString());
                    dataGridWarehouse.Rows[x].Cells[5].Value = onStockQuantity.ToString();
                }
                else if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() == "Wydanie")
                {
                    onStockQuantity = onStockQuantity - decimal.Parse(dataGridWarehouse.Rows[x].Cells[2].Value.ToString());
                    dataGridWarehouse.Rows[x].Cells[5].Value = onStockQuantity;
                }

                tBInStock.Text = onStockQuantity.ToString();
            }
        }

        //Obliczanie ceny ewidencyjnej
        private void calculateTransactionPrice()
        {
            decimal average = 0.00m;
            for (int x = 0; x < DBDataSet.Tables[0].Rows.Count; x++)
            {
                //Obliczenie ceny rozchodu metodą średniej ważonej
                if (DBDataSet.Tables[0].Rows[x][0].ToString() == "Przyjęcie")
                {
                    //Cena zakupu = cena ewidencyjna transakcji 
                    dataGridWarehouse.Rows[x].Cells[3].Value = DBDataSet.Tables[0].Rows[x][1].ToString();
                }
                //Wyliczanie ceny ewidencyjnej dla wydań
                else if (DBDataSet.Tables[0].Rows[x][0].ToString() == "Wydanie")
                {
                    //Wywoływanie metody obliczającej cenę ewidencyjną rozchodu 

                    average = checkAverage(x);
                    average = Math.Round(average, 4);
                    dataGridWarehouse.Rows[x].Cells[3].Value = average;

                }
            }
        }

        //Obliczanie całkowitej wartości transakcji
        private void calculateTransactionTotalValue()
        {
            for (int x = 0; x < DBDataSet.Tables[0].Rows.Count; x++)
            {
                if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() == "Przyjęcie")
                {
                    //Obliczanie całkowitej wartości transakcji 
                    dataGridWarehouse.Rows[x].Cells[4].Value = decimal.Parse(dataGridWarehouse.Rows[x].Cells[1].Value.ToString())
                        * decimal.Parse(dataGridWarehouse.Rows[x].Cells[2].Value.ToString());
                }
                //Wyliczanie ceny ewidencyjnej dla wydań
                else if (dataGridWarehouse.Rows[x].Cells[0].Value.ToString() == "Wydanie")
                {
                    dataGridWarehouse.Rows[x].Cells[4].Value = decimal.Parse(dataGridWarehouse.Rows[x].Cells[3].Value.ToString())
                      * decimal.Parse(dataGridWarehouse.Rows[x].Cells[2].Value.ToString());
                }
            }
        }

        //Wywoływanie metod oblicząjących cały magazyn 
        private void calculateEverything()
        {
            calculateOnStockValue();
            calculateTransactionPrice();
            calculateTransactionTotalValue();
        }


        //Algorytm wyliczający średnią ewidencyjną rozchodu
        private decimal oldPrice = 0.00m;
        private decimal oldQuantity = 0.00m;
        private decimal average = 0.00m;
        private decimal checkAverage(int i)
        {
            oldPrice = 0.00m;
            oldQuantity = 0.00m;
            average = 0.00m;
            for (int x = 0; x <= i; x++)
            {
                //Obliczenie ceny rozchodu metodą średniej ważonej
                if (DBDataSet.Tables[0].Rows[x][0].ToString() == "Przyjęcie")
                {
                    average = (oldPrice * oldQuantity + decimal.Parse(DBDataSet.Tables[0].Rows[x][1].ToString()) * decimal.Parse(DBDataSet.Tables[0].Rows[x][2].ToString())) / ( oldQuantity + decimal.Parse(DBDataSet.Tables[0].Rows[x][2].ToString()));

                    oldPrice = average;
                    oldQuantity = decimal.Parse(DBDataSet.Tables[0].Rows[x][5].ToString());
                }
                //Wyliczanie ceny ewidencyjnej dla wydań
                else if (DBDataSet.Tables[0].Rows[x][0].ToString() == "Wydanie")
                {
                }
                else
                {
                    average = 0.00m;
                }
            }
            return average;
        }

        //Wykrywanie zaznaczonego wiersza
        private void dataGridWarehouse_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            else
            {
                //Jeżeli przycisk zapisu danych jest odblokowany to niemożliwa jest zmiana danych, dodawanie nowych transakcji
                if (bSaveTransaction.Enabled == true)
                {
                    return;
                }
                else
                {
                    tBoxIndex.Text = (e.Row.Index + 1).ToString();
                    tBoxTransaction.Text = e.Row.Cells[0].Value.ToString();
                    if (tBoxTransaction.Text == "Wydanie")
                    {
                        chBoxArrival.Visible = true;
                        chBoxRemoval.Visible = true;
                        chBoxRemoval.Checked = true;
                        bEditTransaction.Enabled = true;
                    }
                    else if (tBoxTransaction.Text == "Przyjęcie")
                    {
                        chBoxArrival.Visible = true;
                        chBoxRemoval.Visible = true;
                        chBoxArrival.Checked = true;
                        bEditTransaction.Enabled = true;
                    }
                    else
                    {
                        bEditTransaction.Enabled = false;
                        chBoxArrival.Visible = false;
                        chBoxRemoval.Visible = false;
                    }
                    tBoxPurchasePrice.Text = e.Row.Cells[1].Value.ToString();
                    tBoxQuantity.Text = e.Row.Cells[2].Value.ToString();
                }
            }
        }

        //Checkbox przyjęcia
        private void chBoxArrival_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxArrival.Checked == true)
            {
                if (chBoxRemoval.Checked == true)
                {
                    chBoxRemoval.Checked = false;
                }
                tBoxTransaction.Text = "Przyjęcie";
            }
            else
            {
                chBoxRemoval.Checked = true;
                tBoxPurchasePrice.Visible = false;
            }
        }

        //Checkbox wydania 
        private void chBoxRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRemoval.Checked == true)
            {
                if(chBoxArrival.Checked == true)
                {
                    chBoxArrival.Checked = false;
                }
                tBoxTransaction.Text = "Wydanie";               
            }
            else
            {
                chBoxArrival.Checked = true;
                tBoxPurchasePrice.Visible = true;
            }
        }


        //Edytowanie transakcji
        private void bEditTransaction_Click(object sender, EventArgs e)
        {
            if (bSaveTransaction.Enabled == false)
            {
                bSaveTransaction.Enabled = true;
                bEditTransaction.Enabled = false;
                bNewTransaction.Enabled = false;
                tBoxQuantity.Enabled = true;
                tBoxPurchasePrice.Enabled = true;
                bDeleteSelected.Enabled = false;
            }
        }

        //Zapisywanie transakcji
        private void bSaveTransaction_Click(object sender, EventArgs e)
        {
            int index = int.Parse(tBoxIndex.Text);
            decimal quantity;
            decimal purchasePrice;
            index = index - 1; 
            try
            {
                
                quantity = decimal.Parse(tBoxQuantity.Text);
                tBoxQuantity.Text = string.Format("{0:0.00}", quantity);
                quantity = decimal.Parse(tBoxQuantity.Text);

                if (tBoxTransaction.Text == "Przyjęcie")
                {
                    purchasePrice = decimal.Parse(tBoxPurchasePrice.Text);
                    tBoxPurchasePrice.Text = string.Format("{0:0.00}", purchasePrice);
                    purchasePrice = decimal.Parse(tBoxPurchasePrice.Text);
                    if (purchasePrice <=0 || quantity <= 0)
                    {
                        throw new Exception ("Quantity and Purchase Price must be above 0 Value!");
                    }
                    dataGridWarehouse.Rows[index].Cells[0].Value = tBoxTransaction.Text;
                    dataGridWarehouse.Rows[index].Cells[1].Value = purchasePrice;
                    dataGridWarehouse.Rows[index].Cells[2].Value = quantity;
                }
                else if (tBoxTransaction.Text == "Wydanie")
                {
                    dataGridWarehouse.Rows[index].Cells[0].Value = tBoxTransaction.Text;
                    dataGridWarehouse.Rows[index].Cells[1].Value = "";
                    dataGridWarehouse.Rows[index].Cells[2].Value = quantity;
                }

                bSaveTransaction.Enabled = false;
                bEditTransaction.Enabled = true;
                bNewTransaction.Enabled = true;
                tBoxPurchasePrice.Enabled = false;
                tBoxQuantity.Enabled = false;
                chBoxArrival.Enabled = false;
                chBoxRemoval.Enabled = false;
                bDeleteSelected.Enabled = true;
                calculateEverything();
            }
            catch(FormatException)
            {
                MessageBox.Show("Niewłaściwy format danych!");
            }
            catch(Exception)
            {
                MessageBox.Show("Ilość i cena zakupu muszą wynosić więcej niż 0!");
            }


        }

        //Dodawanie transakcji
        private void bNewTransaction_Click(object sender, EventArgs e)
        {
            if (bSaveTransaction.Enabled == false)
            {
                DBDataSet.Tables[0].Rows.Add("Przyjęcie", "0.00", "0.00");

                dataGridWarehouse.Rows[dataGridWarehouse.Rows.Count-1].Selected = true;

                tBoxIndex.Text = dataGridWarehouse.Rows.Count.ToString();
                tBoxQuantity.Text = "1.00";
                tBoxPurchasePrice.Text = "1.00";

                bSaveTransaction.Enabled = true;
                bEditTransaction.Enabled = false;
                bNewTransaction.Enabled = false;
                tBoxQuantity.Enabled = true;
                tBoxPurchasePrice.Enabled = true;
                chBoxArrival.Enabled = true;
                chBoxRemoval.Enabled = true;
                bDeleteSelected.Enabled = false;
            }
        }

    }
}
