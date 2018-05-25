namespace Form1
{
    partial class FormDevolucion
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
            this.labelProducto = new System.Windows.Forms.Label();
            this.textBoxExistencia = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDisminuir = new System.Windows.Forms.Button();
            this.textBoxSUMARESTA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddFull = new System.Windows.Forms.Button();
            this.buttonDisminFull = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelProducto
            // 
            this.labelProducto.AutoSize = true;
            this.labelProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto.Location = new System.Drawing.Point(20, 20);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Size = new System.Drawing.Size(95, 16);
            this.labelProducto.TabIndex = 1;
            this.labelProducto.Text = "DEVOLUCION";
            // 
            // textBoxExistencia
            // 
            this.textBoxExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExistencia.Location = new System.Drawing.Point(141, 72);
            this.textBoxExistencia.Name = "textBoxExistencia";
            this.textBoxExistencia.ReadOnly = true;
            this.textBoxExistencia.Size = new System.Drawing.Size(85, 26);
            this.textBoxExistencia.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(67, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(263, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "SALVAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CANTIDAD";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Form1.Properties.Resources.mas;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(281, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 33);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDisminuir
            // 
            this.buttonDisminuir.BackgroundImage = global::Form1.Properties.Resources.menos;
            this.buttonDisminuir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDisminuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisminuir.Location = new System.Drawing.Point(242, 68);
            this.buttonDisminuir.Name = "buttonDisminuir";
            this.buttonDisminuir.Size = new System.Drawing.Size(33, 33);
            this.buttonDisminuir.TabIndex = 0;
            this.buttonDisminuir.UseVisualStyleBackColor = true;
            this.buttonDisminuir.Click += new System.EventHandler(this.buttonDisminuir_Click);
            // 
            // textBoxSUMARESTA
            // 
            this.textBoxSUMARESTA.Location = new System.Drawing.Point(141, 112);
            this.textBoxSUMARESTA.Name = "textBoxSUMARESTA";
            this.textBoxSUMARESTA.Size = new System.Drawing.Size(85, 20);
            this.textBoxSUMARESTA.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "DEV. MULTIPLE";
            // 
            // buttonAddFull
            // 
            this.buttonAddFull.BackgroundImage = global::Form1.Properties.Resources.mas;
            this.buttonAddFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddFull.Location = new System.Drawing.Point(281, 107);
            this.buttonAddFull.Name = "buttonAddFull";
            this.buttonAddFull.Size = new System.Drawing.Size(33, 33);
            this.buttonAddFull.TabIndex = 11;
            this.buttonAddFull.UseVisualStyleBackColor = true;
            this.buttonAddFull.Click += new System.EventHandler(this.buttonAddFull_Click);
            // 
            // buttonDisminFull
            // 
            this.buttonDisminFull.BackgroundImage = global::Form1.Properties.Resources.menos;
            this.buttonDisminFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDisminFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisminFull.Location = new System.Drawing.Point(242, 107);
            this.buttonDisminFull.Name = "buttonDisminFull";
            this.buttonDisminFull.Size = new System.Drawing.Size(33, 33);
            this.buttonDisminFull.TabIndex = 10;
            this.buttonDisminFull.UseVisualStyleBackColor = true;
            this.buttonDisminFull.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 232);
            this.Controls.Add(this.buttonAddFull);
            this.Controls.Add(this.buttonDisminFull);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSUMARESTA);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxExistencia);
            this.Controls.Add(this.labelProducto);
            this.Controls.Add(this.buttonDisminuir);
            this.Name = "FormDevolucion";
            this.Text = "FormDevolucion";
            this.Load += new System.EventHandler(this.FormDevolucion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDisminuir;
        public System.Windows.Forms.Label labelProducto;
        public System.Windows.Forms.TextBox textBoxExistencia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSUMARESTA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFull;
        private System.Windows.Forms.Button buttonDisminFull;
    }
}