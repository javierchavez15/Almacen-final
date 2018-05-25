namespace Form1
{
    partial class FormAltaEmpleado
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.labelEmpleado = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textboxEmpleado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(40, 94);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 44;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonAlta
            // 
            this.buttonAlta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAlta.Location = new System.Drawing.Point(387, 94);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(75, 23);
            this.buttonAlta.TabIndex = 43;
            this.buttonAlta.Text = "Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // labelEmpleado
            // 
            this.labelEmpleado.AutoSize = true;
            this.labelEmpleado.Location = new System.Drawing.Point(37, 50);
            this.labelEmpleado.Name = "labelEmpleado";
            this.labelEmpleado.Size = new System.Drawing.Size(66, 13);
            this.labelEmpleado.TabIndex = 42;
            this.labelEmpleado.Text = "EMPLEADO";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(161, 18);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(214, 13);
            this.labelTitulo.TabIndex = 41;
            this.labelTitulo.Text = "ALTA DE GERENTE DE PROYECTO";
            // 
            // textboxEmpleado
            // 
            this.textboxEmpleado.Location = new System.Drawing.Point(113, 47);
            this.textboxEmpleado.Name = "textboxEmpleado";
            this.textboxEmpleado.Size = new System.Drawing.Size(323, 20);
            this.textboxEmpleado.TabIndex = 40;
            // 
            // FormAltaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 143);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.labelEmpleado);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.textboxEmpleado);
            this.Name = "FormAltaEmpleado";
            this.Text = "FormAltaEmpleado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Label labelEmpleado;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textboxEmpleado;
    }
}