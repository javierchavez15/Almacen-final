namespace Form1
{
    partial class FormAltaProyecto
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
            this.label1 = new System.Windows.Forms.Label();
            this.NOMBRE = new System.Windows.Forms.TextBox();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.ID_CLIENTE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GERENTE = new System.Windows.Forms.ComboBox();
            this.buttonAltaCliente = new System.Windows.Forms.Button();
            this.buttonAltaGerente = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtproyecto = new System.Windows.Forms.TextBox();
            this.txtanticipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtfin = new System.Windows.Forms.DateTimePicker();
            this.lbltipo = new System.Windows.Forms.Label();
            this.dtinicio = new System.Windows.Forms.DateTimePicker();
            this.lblfechafactura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DEL PROYECTO";
            // 
            // NOMBRE
            // 
            this.NOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRE.Location = new System.Drawing.Point(233, 103);
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Size = new System.Drawing.Size(549, 22);
            this.NOMBRE.TabIndex = 1;
            this.NOMBRE.TextChanged += new System.EventHandler(this.NOMBRE_TextChanged);
            // 
            // buttonAlta
            // 
            this.buttonAlta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlta.Location = new System.Drawing.Point(233, 327);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(126, 35);
            this.buttonAlta.TabIndex = 2;
            this.buttonAlta.Text = "ALTA";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID_CLIENTE
            // 
            this.ID_CLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CLIENTE.FormattingEnabled = true;
            this.ID_CLIENTE.Location = new System.Drawing.Point(233, 145);
            this.ID_CLIENTE.Name = "ID_CLIENTE";
            this.ID_CLIENTE.Size = new System.Drawing.Size(549, 24);
            this.ID_CLIENTE.TabIndex = 3;
            this.ID_CLIENTE.SelectedIndexChanged += new System.EventHandler(this.ID_CLIENTE_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "GERENTE DEL PROYECTO";
            // 
            // GERENTE
            // 
            this.GERENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GERENTE.FormattingEnabled = true;
            this.GERENTE.Location = new System.Drawing.Point(233, 27);
            this.GERENTE.Name = "GERENTE";
            this.GERENTE.Size = new System.Drawing.Size(549, 24);
            this.GERENTE.TabIndex = 6;
            this.GERENTE.SelectedIndexChanged += new System.EventHandler(this.GERENTE_SelectedIndexChanged);
            // 
            // buttonAltaCliente
            // 
            this.buttonAltaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAltaCliente.Location = new System.Drawing.Point(688, 182);
            this.buttonAltaCliente.Name = "buttonAltaCliente";
            this.buttonAltaCliente.Size = new System.Drawing.Size(94, 32);
            this.buttonAltaCliente.TabIndex = 7;
            this.buttonAltaCliente.Text = "ALTA";
            this.buttonAltaCliente.UseVisualStyleBackColor = true;
            this.buttonAltaCliente.Visible = false;
            this.buttonAltaCliente.Click += new System.EventHandler(this.buttonAltaCliente_Click);
            // 
            // buttonAltaGerente
            // 
            this.buttonAltaGerente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAltaGerente.Location = new System.Drawing.Point(688, 56);
            this.buttonAltaGerente.Name = "buttonAltaGerente";
            this.buttonAltaGerente.Size = new System.Drawing.Size(94, 32);
            this.buttonAltaGerente.TabIndex = 8;
            this.buttonAltaGerente.Text = "ALTA";
            this.buttonAltaGerente.UseVisualStyleBackColor = true;
            this.buttonAltaGerente.Visible = false;
            this.buttonAltaGerente.Click += new System.EventHandler(this.buttonAltaGerente_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(470, 327);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(126, 35);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(278, 71);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(138, 17);
            this.radioButton2.TabIndex = 404;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ASIGNAR NUMERO";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(31, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(228, 17);
            this.radioButton1.TabIndex = 403;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "GENERAR NUMERO AUTOMATICO";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtproyecto
            // 
            this.txtproyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproyecto.Location = new System.Drawing.Point(438, 68);
            this.txtproyecto.Name = "txtproyecto";
            this.txtproyecto.Size = new System.Drawing.Size(141, 20);
            this.txtproyecto.TabIndex = 402;
            this.txtproyecto.TextChanged += new System.EventHandler(this.txtproyecto_TextChanged);
            // 
            // txtanticipo
            // 
            this.txtanticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtanticipo.Location = new System.Drawing.Point(116, 275);
            this.txtanticipo.Name = "txtanticipo";
            this.txtanticipo.Size = new System.Drawing.Size(141, 20);
            this.txtanticipo.TabIndex = 418;
            this.txtanticipo.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(28, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 417;
            this.label4.Text = "ANTICIPO:";
            // 
            // dtfin
            // 
            this.dtfin.Location = new System.Drawing.Point(294, 233);
            this.dtfin.Name = "dtfin";
            this.dtfin.Size = new System.Drawing.Size(198, 20);
            this.dtfin.TabIndex = 414;
            // 
            // lbltipo
            // 
            this.lbltipo.AutoSize = true;
            this.lbltipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltipo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbltipo.Location = new System.Drawing.Point(28, 238);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(196, 16);
            this.lbltipo.TabIndex = 416;
            this.lbltipo.Text = "FECHA ESTIMADA DE FIN:";
            // 
            // dtinicio
            // 
            this.dtinicio.Location = new System.Drawing.Point(294, 194);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Size = new System.Drawing.Size(195, 20);
            this.dtinicio.TabIndex = 413;
            // 
            // lblfechafactura
            // 
            this.lblfechafactura.AutoSize = true;
            this.lblfechafactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfechafactura.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblfechafactura.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblfechafactura.Location = new System.Drawing.Point(28, 198);
            this.lblfechafactura.Name = "lblfechafactura";
            this.lblfechafactura.Size = new System.Drawing.Size(216, 16);
            this.lblfechafactura.TabIndex = 415;
            this.lblfechafactura.Text = "FECHA ESTIMADA DE INICIO:";
            // 
            // FormAltaProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 379);
            this.Controls.Add(this.txtanticipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtfin);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.dtinicio);
            this.Controls.Add(this.lblfechafactura);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtproyecto);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAltaGerente);
            this.Controls.Add(this.buttonAltaCliente);
            this.Controls.Add(this.GERENTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_CLIENTE);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.NOMBRE);
            this.Controls.Add(this.label1);
            this.Name = "FormAltaProyecto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROYECTOS";
            this.Load += new System.EventHandler(this.FormAltaProyecto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NOMBRE;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.ComboBox ID_CLIENTE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GERENTE;
        private System.Windows.Forms.Button buttonAltaCliente;
        private System.Windows.Forms.Button buttonAltaGerente;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtproyecto;
        private System.Windows.Forms.TextBox txtanticipo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtfin;
        private System.Windows.Forms.Label lbltipo;
        private System.Windows.Forms.DateTimePicker dtinicio;
        private System.Windows.Forms.Label lblfechafactura;
    }
}