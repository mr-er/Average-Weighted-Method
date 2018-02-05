namespace something
{
    partial class Warehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DBDataSet = new System.Data.DataSet();
            this.dataGridWarehouse = new System.Windows.Forms.DataGridView();
            this.bDeleteSelected = new System.Windows.Forms.Button();
            this.tBInStock = new System.Windows.Forms.TextBox();
            this.lInStock = new System.Windows.Forms.Label();
            this.tBoxTransaction = new System.Windows.Forms.TextBox();
            this.tBoxQuantity = new System.Windows.Forms.TextBox();
            this.tBoxPurchasePrice = new System.Windows.Forms.TextBox();
            this.lTransaction = new System.Windows.Forms.Label();
            this.lQuantity = new System.Windows.Forms.Label();
            this.lIndex = new System.Windows.Forms.Label();
            this.tBoxIndex = new System.Windows.Forms.TextBox();
            this.chBoxArrival = new System.Windows.Forms.CheckBox();
            this.lPurchasePrice = new System.Windows.Forms.Label();
            this.chBoxRemoval = new System.Windows.Forms.CheckBox();
            this.bEditTransaction = new System.Windows.Forms.Button();
            this.bNewTransaction = new System.Windows.Forms.Button();
            this.bSaveTransaction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // DBDataSet
            // 
            this.DBDataSet.DataSetName = "DBDataSet";
            this.DBDataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
            // 
            // dataGridWarehouse
            // 
            this.dataGridWarehouse.AllowUserToAddRows = false;
            this.dataGridWarehouse.AllowUserToDeleteRows = false;
            this.dataGridWarehouse.AllowUserToResizeColumns = false;
            this.dataGridWarehouse.AllowUserToResizeRows = false;
            this.dataGridWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWarehouse.Location = new System.Drawing.Point(12, 148);
            this.dataGridWarehouse.MultiSelect = false;
            this.dataGridWarehouse.Name = "dataGridWarehouse";
            this.dataGridWarehouse.ReadOnly = true;
            this.dataGridWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridWarehouse.Size = new System.Drawing.Size(916, 304);
            this.dataGridWarehouse.TabIndex = 3;
            this.dataGridWarehouse.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridWarehouse_ColumnAdded);
            this.dataGridWarehouse.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridWarehouse_RowStateChanged);
            // 
            // bDeleteSelected
            // 
            this.bDeleteSelected.Location = new System.Drawing.Point(222, 120);
            this.bDeleteSelected.Name = "bDeleteSelected";
            this.bDeleteSelected.Size = new System.Drawing.Size(165, 23);
            this.bDeleteSelected.TabIndex = 4;
            this.bDeleteSelected.Text = "Usuń zaznaczoną transakcje";
            this.bDeleteSelected.UseVisualStyleBackColor = true;
            this.bDeleteSelected.Click += new System.EventHandler(this.bDeleteSelected_Click);
            // 
            // tBInStock
            // 
            this.tBInStock.Location = new System.Drawing.Point(116, 122);
            this.tBInStock.Name = "tBInStock";
            this.tBInStock.ReadOnly = true;
            this.tBInStock.Size = new System.Drawing.Size(100, 20);
            this.tBInStock.TabIndex = 5;
            // 
            // lInStock
            // 
            this.lInStock.AutoSize = true;
            this.lInStock.Location = new System.Drawing.Point(14, 125);
            this.lInStock.Name = "lInStock";
            this.lInStock.Size = new System.Drawing.Size(96, 13);
            this.lInStock.TabIndex = 6;
            this.lInStock.Text = "Stan magazynowy:";
            // 
            // tBoxTransaction
            // 
            this.tBoxTransaction.Location = new System.Drawing.Point(123, 29);
            this.tBoxTransaction.Name = "tBoxTransaction";
            this.tBoxTransaction.ReadOnly = true;
            this.tBoxTransaction.Size = new System.Drawing.Size(100, 20);
            this.tBoxTransaction.TabIndex = 7;
            // 
            // tBoxQuantity
            // 
            this.tBoxQuantity.Enabled = false;
            this.tBoxQuantity.Location = new System.Drawing.Point(229, 29);
            this.tBoxQuantity.Name = "tBoxQuantity";
            this.tBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.tBoxQuantity.TabIndex = 8;
            // 
            // tBoxPurchasePrice
            // 
            this.tBoxPurchasePrice.Enabled = false;
            this.tBoxPurchasePrice.Location = new System.Drawing.Point(335, 29);
            this.tBoxPurchasePrice.Name = "tBoxPurchasePrice";
            this.tBoxPurchasePrice.Size = new System.Drawing.Size(100, 20);
            this.tBoxPurchasePrice.TabIndex = 9;
            // 
            // lTransaction
            // 
            this.lTransaction.AutoSize = true;
            this.lTransaction.Location = new System.Drawing.Point(124, 9);
            this.lTransaction.Name = "lTransaction";
            this.lTransaction.Size = new System.Drawing.Size(91, 13);
            this.lTransaction.TabIndex = 12;
            this.lTransaction.Text = "Rodzaj transakcji:";
            // 
            // lQuantity
            // 
            this.lQuantity.AutoSize = true;
            this.lQuantity.Location = new System.Drawing.Point(226, 9);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(60, 13);
            this.lQuantity.TabIndex = 13;
            this.lQuantity.Text = "Ilość sztuk:";
            // 
            // lIndex
            // 
            this.lIndex.AutoSize = true;
            this.lIndex.Location = new System.Drawing.Point(14, 9);
            this.lIndex.Name = "lIndex";
            this.lIndex.Size = new System.Drawing.Size(42, 13);
            this.lIndex.TabIndex = 14;
            this.lIndex.Text = "Indeks:";
            // 
            // tBoxIndex
            // 
            this.tBoxIndex.Location = new System.Drawing.Point(17, 29);
            this.tBoxIndex.Name = "tBoxIndex";
            this.tBoxIndex.ReadOnly = true;
            this.tBoxIndex.Size = new System.Drawing.Size(100, 20);
            this.tBoxIndex.TabIndex = 15;
            // 
            // chBoxArrival
            // 
            this.chBoxArrival.AutoSize = true;
            this.chBoxArrival.Enabled = false;
            this.chBoxArrival.Location = new System.Drawing.Point(132, 56);
            this.chBoxArrival.Name = "chBoxArrival";
            this.chBoxArrival.Size = new System.Drawing.Size(68, 17);
            this.chBoxArrival.TabIndex = 16;
            this.chBoxArrival.Text = "Przyjęcie";
            this.chBoxArrival.UseVisualStyleBackColor = true;
            this.chBoxArrival.CheckedChanged += new System.EventHandler(this.chBoxArrival_CheckedChanged);
            // 
            // lPurchasePrice
            // 
            this.lPurchasePrice.AutoSize = true;
            this.lPurchasePrice.Location = new System.Drawing.Point(332, 9);
            this.lPurchasePrice.Name = "lPurchasePrice";
            this.lPurchasePrice.Size = new System.Drawing.Size(73, 13);
            this.lPurchasePrice.TabIndex = 17;
            this.lPurchasePrice.Text = "Cena zakupu:";
            // 
            // chBoxRemoval
            // 
            this.chBoxRemoval.AutoSize = true;
            this.chBoxRemoval.Enabled = false;
            this.chBoxRemoval.Location = new System.Drawing.Point(132, 80);
            this.chBoxRemoval.Name = "chBoxRemoval";
            this.chBoxRemoval.Size = new System.Drawing.Size(68, 17);
            this.chBoxRemoval.TabIndex = 18;
            this.chBoxRemoval.Text = "Wydanie";
            this.chBoxRemoval.UseVisualStyleBackColor = true;
            this.chBoxRemoval.CheckedChanged += new System.EventHandler(this.chBoxRemoval_CheckedChanged);
            // 
            // bEditTransaction
            // 
            this.bEditTransaction.Enabled = false;
            this.bEditTransaction.Location = new System.Drawing.Point(441, 27);
            this.bEditTransaction.Name = "bEditTransaction";
            this.bEditTransaction.Size = new System.Drawing.Size(138, 23);
            this.bEditTransaction.TabIndex = 19;
            this.bEditTransaction.Text = "Edytuj";
            this.bEditTransaction.UseVisualStyleBackColor = true;
            this.bEditTransaction.Click += new System.EventHandler(this.bEditTransaction_Click);
            // 
            // bNewTransaction
            // 
            this.bNewTransaction.Location = new System.Drawing.Point(647, 27);
            this.bNewTransaction.Name = "bNewTransaction";
            this.bNewTransaction.Size = new System.Drawing.Size(157, 23);
            this.bNewTransaction.TabIndex = 20;
            this.bNewTransaction.Text = "Dodaj nową transakcje";
            this.bNewTransaction.UseVisualStyleBackColor = true;
            this.bNewTransaction.Click += new System.EventHandler(this.bNewTransaction_Click);
            // 
            // bSaveTransaction
            // 
            this.bSaveTransaction.Enabled = false;
            this.bSaveTransaction.Location = new System.Drawing.Point(441, 56);
            this.bSaveTransaction.Name = "bSaveTransaction";
            this.bSaveTransaction.Size = new System.Drawing.Size(138, 23);
            this.bSaveTransaction.TabIndex = 21;
            this.bSaveTransaction.Text = "Zapisz transakcje";
            this.bSaveTransaction.UseVisualStyleBackColor = true;
            this.bSaveTransaction.Click += new System.EventHandler(this.bSaveTransaction_Click);
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 469);
            this.Controls.Add(this.bSaveTransaction);
            this.Controls.Add(this.bNewTransaction);
            this.Controls.Add(this.bEditTransaction);
            this.Controls.Add(this.chBoxRemoval);
            this.Controls.Add(this.lPurchasePrice);
            this.Controls.Add(this.chBoxArrival);
            this.Controls.Add(this.tBoxIndex);
            this.Controls.Add(this.lIndex);
            this.Controls.Add(this.lQuantity);
            this.Controls.Add(this.lTransaction);
            this.Controls.Add(this.tBoxPurchasePrice);
            this.Controls.Add(this.tBoxQuantity);
            this.Controls.Add(this.tBoxTransaction);
            this.Controls.Add(this.lInStock);
            this.Controls.Add(this.tBInStock);
            this.Controls.Add(this.bDeleteSelected);
            this.Controls.Add(this.dataGridWarehouse);
            this.Name = "Warehouse";
            this.Text = "Warehouse - Average Weighted Method";
            ((System.ComponentModel.ISupportInitialize)(this.DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.DataSet DBDataSet;
        private System.Windows.Forms.DataGridView dataGridWarehouse;
        private System.Windows.Forms.Button bDeleteSelected;
        private System.Windows.Forms.TextBox tBInStock;
        private System.Windows.Forms.Label lInStock;
        private System.Windows.Forms.TextBox tBoxTransaction;
        private System.Windows.Forms.TextBox tBoxQuantity;
        private System.Windows.Forms.TextBox tBoxPurchasePrice;
        private System.Windows.Forms.Label lTransaction;
        private System.Windows.Forms.Label lQuantity;
        private System.Windows.Forms.Label lIndex;
        private System.Windows.Forms.TextBox tBoxIndex;
        private System.Windows.Forms.CheckBox chBoxArrival;
        private System.Windows.Forms.Label lPurchasePrice;
        private System.Windows.Forms.CheckBox chBoxRemoval;
        private System.Windows.Forms.Button bEditTransaction;
        private System.Windows.Forms.Button bNewTransaction;
        private System.Windows.Forms.Button bSaveTransaction;
    }
}

