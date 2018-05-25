namespace Form1
{
    partial class conteo
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
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtnumero
            // 
            this.txtnumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumero.Location = new System.Drawing.Point(37, 12);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(211, 29);
            this.txtnumero.TabIndex = 21;
            this.txtnumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnumero_KeyDown);
            this.txtnumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumero_KeyPress);
            // 
            // buttonEditar
            // 
            this.buttonEditar.BackColor = System.Drawing.SystemColors.Info;
            this.buttonEditar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditar.Location = new System.Drawing.Point(89, 47);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(102, 25);
            this.buttonEditar.TabIndex = 35;
            this.buttonEditar.Text = "Guardar";
            this.buttonEditar.UseVisualStyleBackColor = false;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // conteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 82);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.txtnumero);
            this.MaximumSize = new System.Drawing.Size(300, 121);
            this.MinimumSize = new System.Drawing.Size(300, 121);
            this.Name = "conteo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numero de inventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEditar;
        public System.Windows.Forms.TextBox txtnumero;
    }
}