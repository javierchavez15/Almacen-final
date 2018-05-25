namespace Form1
{
    partial class FormBuscarProducto
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCatalogo = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCopiarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(771, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "MARCA";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarca.Location = new System.Drawing.Point(853, 15);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(211, 29);
            this.textBoxMarca.TabIndex = 21;
            this.textBoxMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMarca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "CATALOGO/CODIGO";
            // 
            // textBoxCatalogo
            // 
            this.textBoxCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCatalogo.Location = new System.Drawing.Point(233, 15);
            this.textBoxCatalogo.Name = "textBoxCatalogo";
            this.textBoxCatalogo.Size = new System.Drawing.Size(509, 29);
            this.textBoxCatalogo.TabIndex = 19;
            this.textBoxCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCatalogo_KeyDown);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(1080, 12);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(144, 32);
            this.buttonBuscar.TabIndex = 18;
            this.buttonBuscar.Text = "BUSCAR";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1304, 590);
            this.dataGridView1.TabIndex = 17;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(33, 667);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(156, 23);
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "Cerrar";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCopiarProducto
            // 
            this.buttonCopiarProducto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCopiarProducto.Location = new System.Drawing.Point(1136, 667);
            this.buttonCopiarProducto.Name = "buttonCopiarProducto";
            this.buttonCopiarProducto.Size = new System.Drawing.Size(156, 23);
            this.buttonCopiarProducto.TabIndex = 24;
            this.buttonCopiarProducto.Text = "Copiar Producto";
            this.buttonCopiarProducto.UseVisualStyleBackColor = true;
            this.buttonCopiarProducto.Click += new System.EventHandler(this.buttonCopiarProducto_Click);
            // 
            // FormBuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 702);
            this.Controls.Add(this.buttonCopiarProducto);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCatalogo);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormBuscarProducto";
            this.Text = "FormBuscarProducto";
            this.Load += new System.EventHandler(this.FormBuscarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxCatalogo;
        public System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCopiarProducto;
    }
}