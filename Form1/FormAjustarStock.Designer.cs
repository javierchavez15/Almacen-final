namespace Form1
{
    partial class FormAjustarStock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCANCELAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAjuste = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelProducto = new System.Windows.Forms.Label();
            this.labelStockTeorico = new System.Windows.Forms.Label();
            this.buttonActualizarStock = new System.Windows.Forms.Button();
            this.textBoxConteoFisico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxStockTeorico = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.Size = new System.Drawing.Size(378, 521);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonCANCELAR
            // 
            this.buttonCANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCANCELAR.Location = new System.Drawing.Point(283, 670);
            this.buttonCANCELAR.Name = "buttonCANCELAR";
            this.buttonCANCELAR.Size = new System.Drawing.Size(223, 23);
            this.buttonCANCELAR.TabIndex = 1;
            this.buttonCANCELAR.Text = "Cerrar Ventana";
            this.buttonCANCELAR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NUMERO DE INVENTARIO";
            // 
            // textBoxAjuste
            // 
            this.textBoxAjuste.Location = new System.Drawing.Point(183, 11);
            this.textBoxAjuste.Name = "textBoxAjuste";
            this.textBoxAjuste.Size = new System.Drawing.Size(94, 20);
            this.textBoxAjuste.TabIndex = 3;
            this.textBoxAjuste.TextChanged += new System.EventHandler(this.textBoxAjuste_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FECHA DE AJUSTE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(431, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // labelProducto
            // 
            this.labelProducto.AutoSize = true;
            this.labelProducto.Location = new System.Drawing.Point(22, 60);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Size = new System.Drawing.Size(74, 13);
            this.labelProducto.TabIndex = 7;
            this.labelProducto.Text = "PRODUCTO: ";
            // 
            // labelStockTeorico
            // 
            this.labelStockTeorico.AutoSize = true;
            this.labelStockTeorico.Location = new System.Drawing.Point(45, 83);
            this.labelStockTeorico.Name = "labelStockTeorico";
            this.labelStockTeorico.Size = new System.Drawing.Size(49, 13);
            this.labelStockTeorico.TabIndex = 8;
            this.labelStockTeorico.Text = "STOCK: ";
            // 
            // buttonActualizarStock
            // 
            this.buttonActualizarStock.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonActualizarStock.Location = new System.Drawing.Point(431, 78);
            this.buttonActualizarStock.Name = "buttonActualizarStock";
            this.buttonActualizarStock.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizarStock.TabIndex = 9;
            this.buttonActualizarStock.Text = "AjustarStock";
            this.buttonActualizarStock.UseVisualStyleBackColor = true;
            this.buttonActualizarStock.Click += new System.EventHandler(this.buttonActualizarStock_Click);
            // 
            // textBoxConteoFisico
            // 
            this.textBoxConteoFisico.Location = new System.Drawing.Point(326, 80);
            this.textBoxConteoFisico.Name = "textBoxConteoFisico";
            this.textBoxConteoFisico.Size = new System.Drawing.Size(94, 20);
            this.textBoxConteoFisico.TabIndex = 10;
            this.textBoxConteoFisico.TextChanged += new System.EventHandler(this.textBoxConteoFisico_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "CONTEO FISICO: ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(386, 143);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 5;
            this.dataGridView2.Size = new System.Drawing.Size(378, 521);
            this.dataGridView2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ENTRADAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "SALIDAS";
            // 
            // textBoxStockTeorico
            // 
            this.textBoxStockTeorico.Location = new System.Drawing.Point(100, 80);
            this.textBoxStockTeorico.Name = "textBoxStockTeorico";
            this.textBoxStockTeorico.ReadOnly = true;
            this.textBoxStockTeorico.Size = new System.Drawing.Size(94, 20);
            this.textBoxStockTeorico.TabIndex = 15;
            // 
            // FormAjustarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 699);
            this.Controls.Add(this.textBoxStockTeorico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxConteoFisico);
            this.Controls.Add(this.buttonActualizarStock);
            this.Controls.Add(this.labelStockTeorico);
            this.Controls.Add(this.labelProducto);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAjuste);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCANCELAR);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAjustarStock";
            this.Text = "FormAjustarStock";
            this.Load += new System.EventHandler(this.FormAjustarStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCANCELAR;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxAjuste;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label labelProducto;
        public System.Windows.Forms.Label labelStockTeorico;
        private System.Windows.Forms.Button buttonActualizarStock;
        public System.Windows.Forms.TextBox textBoxConteoFisico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxStockTeorico;
    }
}