namespace Form1
{
    partial class FormEditPU
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
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNuevoPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPRODUCTO = new System.Windows.Forms.Label();
            this.labelPrecioActual = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numeroCotizacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.buttonAdjuntar = new System.Windows.Forms.Button();
            this.precioUnitario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.moneda2 = new System.Windows.Forms.ComboBox();
            this.tipoCambio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCerrarVentana = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActualizar.Location = new System.Drawing.Point(429, 300);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(178, 30);
            this.buttonActualizar.TabIndex = 0;
            this.buttonActualizar.Text = "ACTUALIZAR";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "PU ACTUAL";
            // 
            // textBoxNuevoPrecio
            // 
            this.textBoxNuevoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNuevoPrecio.Location = new System.Drawing.Point(160, 108);
            this.textBoxNuevoPrecio.Name = "textBoxNuevoPrecio";
            this.textBoxNuevoPrecio.ReadOnly = true;
            this.textBoxNuevoPrecio.Size = new System.Drawing.Size(100, 23);
            this.textBoxNuevoPrecio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "NUEVO PU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "USD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "USD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "PRODUCTO:";
            // 
            // labelPRODUCTO
            // 
            this.labelPRODUCTO.AutoSize = true;
            this.labelPRODUCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPRODUCTO.Location = new System.Drawing.Point(169, 33);
            this.labelPRODUCTO.Name = "labelPRODUCTO";
            this.labelPRODUCTO.Size = new System.Drawing.Size(91, 17);
            this.labelPRODUCTO.TabIndex = 8;
            this.labelPRODUCTO.Text = "PRODUCTO:";
            // 
            // labelPrecioActual
            // 
            this.labelPrecioActual.AutoSize = true;
            this.labelPrecioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioActual.Location = new System.Drawing.Point(169, 80);
            this.labelPrecioActual.Name = "labelPrecioActual";
            this.labelPrecioActual.Size = new System.Drawing.Size(85, 17);
            this.labelPrecioActual.TabIndex = 9;
            this.labelPrecioActual.Text = "PU ACTUAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "DATOS DE COTIZACION DEL PROVEEDOR";
            // 
            // numeroCotizacion
            // 
            this.numeroCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCotizacion.Location = new System.Drawing.Point(200, 210);
            this.numeroCotizacion.Name = "numeroCotizacion";
            this.numeroCotizacion.Size = new System.Drawing.Size(180, 23);
            this.numeroCotizacion.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(64, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "NUM. COTIZACION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(403, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "FECHA";
            // 
            // fecha2
            // 
            this.fecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha2.Location = new System.Drawing.Point(464, 211);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(227, 23);
            this.fecha2.TabIndex = 14;
            // 
            // buttonAdjuntar
            // 
            this.buttonAdjuntar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjuntar.Location = new System.Drawing.Point(636, 253);
            this.buttonAdjuntar.Name = "buttonAdjuntar";
            this.buttonAdjuntar.Size = new System.Drawing.Size(178, 23);
            this.buttonAdjuntar.TabIndex = 17;
            this.buttonAdjuntar.Text = "ADJUNTAR ARCHIVO";
            this.buttonAdjuntar.UseVisualStyleBackColor = true;
            this.buttonAdjuntar.Click += new System.EventHandler(this.buttonAdjuntar_Click);
            // 
            // precioUnitario
            // 
            this.precioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precioUnitario.Location = new System.Drawing.Point(143, 250);
            this.precioUnitario.Name = "precioUnitario";
            this.precioUnitario.Size = new System.Drawing.Size(102, 23);
            this.precioUnitario.TabIndex = 19;
            this.precioUnitario.Text = "0";
            this.precioUnitario.TextChanged += new System.EventHandler(this.precioUnitario_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "PRECIO U";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(276, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "MONEDA";
            // 
            // moneda2
            // 
            this.moneda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda2.FormattingEnabled = true;
            this.moneda2.Items.AddRange(new object[] {
            "USD",
            "PMX"});
            this.moneda2.Location = new System.Drawing.Point(355, 252);
            this.moneda2.Name = "moneda2";
            this.moneda2.Size = new System.Drawing.Size(96, 24);
            this.moneda2.TabIndex = 21;
            // 
            // tipoCambio
            // 
            this.tipoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoCambio.Location = new System.Drawing.Point(511, 253);
            this.tipoCambio.Name = "tipoCambio";
            this.tipoCambio.Size = new System.Drawing.Size(96, 23);
            this.tipoCambio.TabIndex = 23;
            this.tipoCambio.Text = "0";
            this.tipoCambio.TextChanged += new System.EventHandler(this.tipoCambio_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(479, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "TC";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // buttonCerrarVentana
            // 
            this.buttonCerrarVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrarVentana.Location = new System.Drawing.Point(320, 366);
            this.buttonCerrarVentana.Name = "buttonCerrarVentana";
            this.buttonCerrarVentana.Size = new System.Drawing.Size(202, 30);
            this.buttonCerrarVentana.TabIndex = 24;
            this.buttonCerrarVentana.Text = "CERRAR VENTANA";
            this.buttonCerrarVentana.UseVisualStyleBackColor = true;
            this.buttonCerrarVentana.Click += new System.EventHandler(this.buttonCerrarVentana_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(636, 300);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(178, 30);
            this.buttonGuardar.TabIndex = 25;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(121, 339);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(610, 17);
            this.labelError.TabIndex = 27;
            this.labelError.Text = "***Los valores ingresados no corresponden a los campos llenados. Corrija y vuelva" +
                " a intentarlo.";
            this.labelError.Visible = false;
            // 
            // FormEditPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 426);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonCerrarVentana);
            this.Controls.Add(this.tipoCambio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.moneda2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.precioUnitario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonAdjuntar);
            this.Controls.Add(this.fecha2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numeroCotizacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelPrecioActual);
            this.Controls.Add(this.labelPRODUCTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNuevoPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonActualizar);
            this.Name = "FormEditPU";
            this.Text = "FormEditPU";
            this.Load += new System.EventHandler(this.FormEditPU_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxNuevoPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelPRODUCTO;
        public System.Windows.Forms.Label labelPrecioActual;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox numeroCotizacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Button buttonAdjuntar;
        private System.Windows.Forms.TextBox precioUnitario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox moneda2;
        public System.Windows.Forms.TextBox tipoCambio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonCerrarVentana;
        public System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label labelError;
    }
}