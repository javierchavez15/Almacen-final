namespace Form1
{
    partial class FormCostos
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
            this.txtcatalogo = new System.Windows.Forms.TextBox();
            this.lblCatalogo = new System.Windows.Forms.Label();
            this.labelPrecioLista = new System.Windows.Forms.Label();
            this.txtcosto = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcatalogo
            // 
            this.txtcatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcatalogo.Location = new System.Drawing.Point(183, 21);
            this.txtcatalogo.Name = "txtcatalogo";
            this.txtcatalogo.ReadOnly = true;
            this.txtcatalogo.Size = new System.Drawing.Size(325, 26);
            this.txtcatalogo.TabIndex = 4;
            // 
            // lblCatalogo
            // 
            this.lblCatalogo.AutoSize = true;
            this.lblCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalogo.Location = new System.Drawing.Point(84, 24);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new System.Drawing.Size(85, 17);
            this.lblCatalogo.TabIndex = 5;
            this.lblCatalogo.Text = "CATALOGO";
            // 
            // labelPrecioLista
            // 
            this.labelPrecioLista.AutoSize = true;
            this.labelPrecioLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioLista.Location = new System.Drawing.Point(552, 27);
            this.labelPrecioLista.Name = "labelPrecioLista";
            this.labelPrecioLista.Size = new System.Drawing.Size(54, 13);
            this.labelPrecioLista.TabIndex = 33;
            this.labelPrecioLista.Text = "P.U. USD";
            this.labelPrecioLista.Visible = false;
            // 
            // txtcosto
            // 
            this.txtcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcosto.Location = new System.Drawing.Point(615, 24);
            this.txtcosto.Name = "txtcosto";
            this.txtcosto.ReadOnly = true;
            this.txtcosto.Size = new System.Drawing.Size(117, 20);
            this.txtcosto.TabIndex = 32;
            this.txtcosto.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 529);
            this.dataGridView1.TabIndex = 34;
            // 
            // button1Cerrar
            // 
            this.button1Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Cerrar.Location = new System.Drawing.Point(829, 17);
            this.button1Cerrar.Name = "button1Cerrar";
            this.button1Cerrar.Size = new System.Drawing.Size(151, 30);
            this.button1Cerrar.TabIndex = 35;
            this.button1Cerrar.Text = "Cerrar Ventana";
            this.button1Cerrar.UseVisualStyleBackColor = true;
            this.button1Cerrar.Click += new System.EventHandler(this.button1Cerrar_Click);
            // 
            // FormCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 591);
            this.Controls.Add(this.button1Cerrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelPrecioLista);
            this.Controls.Add(this.txtcosto);
            this.Controls.Add(this.txtcatalogo);
            this.Controls.Add(this.lblCatalogo);
            this.MaximumSize = new System.Drawing.Size(1072, 630);
            this.MinimumSize = new System.Drawing.Size(1072, 630);
            this.Name = "FormCostos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMBIOS DE COSTOS";
            this.Load += new System.EventHandler(this.FormCostos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtcatalogo;
        private System.Windows.Forms.Label lblCatalogo;
        public System.Windows.Forms.Label labelPrecioLista;
        public System.Windows.Forms.TextBox txtcosto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1Cerrar;
    }
}