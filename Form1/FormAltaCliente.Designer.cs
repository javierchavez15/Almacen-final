namespace Form1
{
    partial class FormAltaCliente
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
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txbRazonSocial = new System.Windows.Forms.TextBox();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(29, 37);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(52, 13);
            this.labelCliente.TabIndex = 37;
            this.labelCliente.Text = "CLIENTE";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(188, 8);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(115, 13);
            this.labelTitulo.TabIndex = 35;
            this.labelTitulo.Text = "ALTA DE CLIENTE";
            // 
            // txbRazonSocial
            // 
            this.txbRazonSocial.Location = new System.Drawing.Point(105, 34);
            this.txbRazonSocial.Name = "txbRazonSocial";
            this.txbRazonSocial.Size = new System.Drawing.Size(323, 20);
            this.txbRazonSocial.TabIndex = 34;
            // 
            // buttonAlta
            // 
            this.buttonAlta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAlta.Location = new System.Drawing.Point(379, 81);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(75, 23);
            this.buttonAlta.TabIndex = 38;
            this.buttonAlta.Text = "Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(32, 81);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 39;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormAltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 117);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.txbRazonSocial);
            this.Name = "FormAltaCliente";
            this.Text = "FormAltaCliente";
            this.Load += new System.EventHandler(this.FormAltaCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txbRazonSocial;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Button buttonCancelar;
    }
}