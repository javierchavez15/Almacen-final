namespace Form1
{
    partial class FormRespaldoCompras
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
            this.labelListaProductos = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelProductRespaldados = new System.Windows.Forms.Label();
            this.labelProductPU = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarRespaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldosDeCOMPRASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarOrdenadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosSinPrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteABCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosConPrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelListaProductos
            // 
            this.labelListaProductos.AutoSize = true;
            this.labelListaProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaProductos.Location = new System.Drawing.Point(12, 31);
            this.labelListaProductos.Name = "labelListaProductos";
            this.labelListaProductos.Size = new System.Drawing.Size(308, 24);
            this.labelListaProductos.TabIndex = 15;
            this.labelListaProductos.Text = "LISTA DE PRODCTOS EN STOCK:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 403);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelProductRespaldados
            // 
            this.labelProductRespaldados.AutoSize = true;
            this.labelProductRespaldados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductRespaldados.Location = new System.Drawing.Point(12, 80);
            this.labelProductRespaldados.Name = "labelProductRespaldados";
            this.labelProductRespaldados.Size = new System.Drawing.Size(277, 24);
            this.labelProductRespaldados.TabIndex = 18;
            this.labelProductRespaldados.Text = "PRODUCTOS RESPALDADOS:";
            // 
            // labelProductPU
            // 
            this.labelProductPU.AutoSize = true;
            this.labelProductPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductPU.Location = new System.Drawing.Point(12, 56);
            this.labelProductPU.Name = "labelProductPU";
            this.labelProductPU.Size = new System.Drawing.Size(210, 24);
            this.labelProductPU.TabIndex = 19;
            this.labelProductPU.Text = "PRODUCTOS CON PU:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accionesToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarRespaldosToolStripMenuItem,
            this.respaldosDeCOMPRASToolStripMenuItem,
            this.borrarOrdenadosToolStripMenuItem,
            this.consulta1ToolStripMenuItem,
            this.productosSinPrecioToolStripMenuItem,
            this.reporteABCToolStripMenuItem,
            this.productosConPrecioToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.accionesToolStripMenuItem.Text = "Actualizacion";
            // 
            // actualizarRespaldosToolStripMenuItem
            // 
            this.actualizarRespaldosToolStripMenuItem.Name = "actualizarRespaldosToolStripMenuItem";
            this.actualizarRespaldosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.actualizarRespaldosToolStripMenuItem.Text = "Actualizar Respaldos";
            this.actualizarRespaldosToolStripMenuItem.Click += new System.EventHandler(this.actualizarRespaldosToolStripMenuItem_Click);
            // 
            // respaldosDeCOMPRASToolStripMenuItem
            // 
            this.respaldosDeCOMPRASToolStripMenuItem.Name = "respaldosDeCOMPRASToolStripMenuItem";
            this.respaldosDeCOMPRASToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.respaldosDeCOMPRASToolStripMenuItem.Text = "Respaldos de COMPRAS";
            this.respaldosDeCOMPRASToolStripMenuItem.Click += new System.EventHandler(this.respaldosDeCOMPRASToolStripMenuItem_Click);
            // 
            // borrarOrdenadosToolStripMenuItem
            // 
            this.borrarOrdenadosToolStripMenuItem.Name = "borrarOrdenadosToolStripMenuItem";
            this.borrarOrdenadosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.borrarOrdenadosToolStripMenuItem.Text = "borrar ordenados";
            this.borrarOrdenadosToolStripMenuItem.Click += new System.EventHandler(this.borrarOrdenadosToolStripMenuItem_Click);
            // 
            // consulta1ToolStripMenuItem
            // 
            this.consulta1ToolStripMenuItem.Name = "consulta1ToolStripMenuItem";
            this.consulta1ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.consulta1ToolStripMenuItem.Text = "consulta1";
            this.consulta1ToolStripMenuItem.Click += new System.EventHandler(this.consulta1ToolStripMenuItem_Click);
            // 
            // productosSinPrecioToolStripMenuItem
            // 
            this.productosSinPrecioToolStripMenuItem.Name = "productosSinPrecioToolStripMenuItem";
            this.productosSinPrecioToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.productosSinPrecioToolStripMenuItem.Text = "ProductosSinPrecio";
            this.productosSinPrecioToolStripMenuItem.Click += new System.EventHandler(this.productosSinPrecioToolStripMenuItem_Click);
            // 
            // reporteABCToolStripMenuItem
            // 
            this.reporteABCToolStripMenuItem.Name = "reporteABCToolStripMenuItem";
            this.reporteABCToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.reporteABCToolStripMenuItem.Text = "ReporteSalidas";
            this.reporteABCToolStripMenuItem.Click += new System.EventHandler(this.reporteABCToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // productosConPrecioToolStripMenuItem
            // 
            this.productosConPrecioToolStripMenuItem.Name = "productosConPrecioToolStripMenuItem";
            this.productosConPrecioToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.productosConPrecioToolStripMenuItem.Text = "ProductosConPrecio";
            this.productosConPrecioToolStripMenuItem.Click += new System.EventHandler(this.productosConPrecioToolStripMenuItem_Click);
            // 
            // FormRespaldoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 525);
            this.Controls.Add(this.labelProductPU);
            this.Controls.Add(this.labelProductRespaldados);
            this.Controls.Add(this.labelListaProductos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormRespaldoCompras";
            this.Text = "FormRespaldoCompras";
            this.Load += new System.EventHandler(this.FormRespaldoCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelListaProductos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelProductRespaldados;
        private System.Windows.Forms.Label labelProductPU;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarRespaldosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldosDeCOMPRASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarOrdenadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosSinPrecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteABCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosConPrecioToolStripMenuItem;

    }
}