namespace Form1
{
    partial class FormAltaProveedores
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
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txbMarcas = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbListaProveedores = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbContacto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txbPaginaWeb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDiascredito = new System.Windows.Forms.TextBox();
            this.txbMontocredito = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbRadio = new System.Windows.Forms.TextBox();
            this.txbCelular = new System.Windows.Forms.TextBox();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.txbPais = new System.Windows.Forms.TextBox();
            this.txbEstado = new System.Windows.Forms.TextBox();
            this.txbCiudad = new System.Windows.Forms.TextBox();
            this.txbDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbRazonSocial = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(89, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 75;
            this.button1.Text = "Alta Contactos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 74;
            this.label17.Text = "Marcas";
            // 
            // txbMarcas
            // 
            this.txbMarcas.Location = new System.Drawing.Point(89, 91);
            this.txbMarcas.Name = "txbMarcas";
            this.txbMarcas.Size = new System.Drawing.Size(420, 20);
            this.txbMarcas.TabIndex = 73;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(224, 403);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 32);
            this.btnGuardar.TabIndex = 72;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(64, 403);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 71;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 26);
            this.label16.TabIndex = 70;
            this.label16.Text = "Seleccionar \r\nProveedor";
            // 
            // cmbListaProveedores
            // 
            this.cmbListaProveedores.FormattingEnabled = true;
            this.cmbListaProveedores.Location = new System.Drawing.Point(89, 31);
            this.cmbListaProveedores.Name = "cmbListaProveedores";
            this.cmbListaProveedores.Size = new System.Drawing.Size(420, 21);
            this.cmbListaProveedores.TabIndex = 69;
            this.cmbListaProveedores.SelectedIndexChanged += new System.EventHandler(this.cmbListaProveedores_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 175);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "Contacto";
            // 
            // txbContacto
            // 
            this.txbContacto.Location = new System.Drawing.Point(278, 172);
            this.txbContacto.Name = "txbContacto";
            this.txbContacto.Size = new System.Drawing.Size(33, 20);
            this.txbContacto.TabIndex = 44;
            this.txbContacto.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(196, 452);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(141, 23);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cerrar Ventana";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Pagina web";
            // 
            // txbPaginaWeb
            // 
            this.txbPaginaWeb.Location = new System.Drawing.Point(89, 274);
            this.txbPaginaWeb.Name = "txbPaginaWeb";
            this.txbPaginaWeb.Size = new System.Drawing.Size(420, 20);
            this.txbPaginaWeb.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(277, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "Dias Credito";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Monto Credito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Categoria";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "e-mail";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Radio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Celular";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Pais";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Ciudad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Direccion";
            // 
            // txbDiascredito
            // 
            this.txbDiascredito.Location = new System.Drawing.Point(347, 351);
            this.txbDiascredito.Name = "txbDiascredito";
            this.txbDiascredito.Size = new System.Drawing.Size(162, 20);
            this.txbDiascredito.TabIndex = 53;
            this.txbDiascredito.Text = "0";
            // 
            // txbMontocredito
            // 
            this.txbMontocredito.Location = new System.Drawing.Point(89, 351);
            this.txbMontocredito.Name = "txbMontocredito";
            this.txbMontocredito.Size = new System.Drawing.Size(162, 20);
            this.txbMontocredito.TabIndex = 52;
            this.txbMontocredito.Text = "0";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(89, 248);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(162, 20);
            this.txbEmail.TabIndex = 48;
            // 
            // txbRadio
            // 
            this.txbRadio.Location = new System.Drawing.Point(321, 245);
            this.txbRadio.Name = "txbRadio";
            this.txbRadio.Size = new System.Drawing.Size(188, 20);
            this.txbRadio.TabIndex = 49;
            // 
            // txbCelular
            // 
            this.txbCelular.Location = new System.Drawing.Point(321, 219);
            this.txbCelular.Name = "txbCelular";
            this.txbCelular.Size = new System.Drawing.Size(188, 20);
            this.txbCelular.TabIndex = 47;
            // 
            // txbTelefono
            // 
            this.txbTelefono.Location = new System.Drawing.Point(89, 219);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(162, 20);
            this.txbTelefono.TabIndex = 46;
            // 
            // txbPais
            // 
            this.txbPais.Location = new System.Drawing.Point(374, 172);
            this.txbPais.Name = "txbPais";
            this.txbPais.Size = new System.Drawing.Size(135, 20);
            this.txbPais.TabIndex = 45;
            // 
            // txbEstado
            // 
            this.txbEstado.AcceptsTab = true;
            this.txbEstado.Location = new System.Drawing.Point(321, 146);
            this.txbEstado.Name = "txbEstado";
            this.txbEstado.Size = new System.Drawing.Size(188, 20);
            this.txbEstado.TabIndex = 43;
            // 
            // txbCiudad
            // 
            this.txbCiudad.Location = new System.Drawing.Point(89, 143);
            this.txbCiudad.Name = "txbCiudad";
            this.txbCiudad.Size = new System.Drawing.Size(162, 20);
            this.txbCiudad.TabIndex = 42;
            // 
            // txbDireccion
            // 
            this.txbDireccion.Location = new System.Drawing.Point(89, 117);
            this.txbDireccion.Name = "txbDireccion";
            this.txbDireccion.Size = new System.Drawing.Size(420, 20);
            this.txbDireccion.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(202, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Alta de Proveedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Razon Social";
            // 
            // txbRazonSocial
            // 
            this.txbRazonSocial.Location = new System.Drawing.Point(89, 66);
            this.txbRazonSocial.Name = "txbRazonSocial";
            this.txbRazonSocial.Size = new System.Drawing.Size(420, 20);
            this.txbRazonSocial.TabIndex = 38;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(89, 303);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(162, 21);
            this.cmbCategoria.TabIndex = 51;
            // 
            // btnAlta
            // 
            this.btnAlta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Location = new System.Drawing.Point(434, 403);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 32);
            this.btnAlta.TabIndex = 56;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // FormAltaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txbMarcas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbListaProveedores);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txbContacto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txbPaginaWeb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDiascredito);
            this.Controls.Add(this.txbMontocredito);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.txbRadio);
            this.Controls.Add(this.txbCelular);
            this.Controls.Add(this.txbTelefono);
            this.Controls.Add(this.txbPais);
            this.Controls.Add(this.txbEstado);
            this.Controls.Add(this.txbCiudad);
            this.Controls.Add(this.txbDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbRazonSocial);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnAlta);
            this.Name = "FormAltaProveedores";
            this.Text = "FormAltaProveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txbMarcas;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox cmbListaProveedores;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txbContacto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txbPaginaWeb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txbDiascredito;
        public System.Windows.Forms.TextBox txbMontocredito;
        public System.Windows.Forms.TextBox txbEmail;
        public System.Windows.Forms.TextBox txbRadio;
        public System.Windows.Forms.TextBox txbCelular;
        public System.Windows.Forms.TextBox txbTelefono;
        public System.Windows.Forms.TextBox txbPais;
        public System.Windows.Forms.TextBox txbEstado;
        public System.Windows.Forms.TextBox txbCiudad;
        public System.Windows.Forms.TextBox txbDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txbRazonSocial;
        public System.Windows.Forms.ComboBox cmbCategoria;
        public System.Windows.Forms.Button btnAlta;
    }
}