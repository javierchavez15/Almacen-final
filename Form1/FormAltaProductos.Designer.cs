namespace Form1
{
    partial class FormAltaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaProductos));
            this.COORDENADA = new System.Windows.Forms.TextBox();
            this.CATALOGO = new System.Windows.Forms.TextBox();
            this.CODIGODEBARRAS = new System.Windows.Forms.TextBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DESCRIPCION = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UNIDAD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MINIMO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MAXIMO = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.MARCA = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAdjuntarImagen = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAdjuntarDataSheet = new System.Windows.Forms.Button();
            this.labelModulo = new System.Windows.Forms.Label();
            this.labelPrecioLista = new System.Windows.Forms.Label();
            this.PRECIOLISTA = new System.Windows.Forms.TextBox();
            this.Modulo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MONEDA = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ADJUNTOS = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DOCUMENTOS = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // COORDENADA
            // 
            this.COORDENADA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COORDENADA.Location = new System.Drawing.Point(123, 283);
            this.COORDENADA.Name = "COORDENADA";
            this.COORDENADA.Size = new System.Drawing.Size(318, 26);
            this.COORDENADA.TabIndex = 7;
            // 
            // CATALOGO
            // 
            this.CATALOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CATALOGO.Location = new System.Drawing.Point(173, 12);
            this.CATALOGO.Name = "CATALOGO";
            this.CATALOGO.Size = new System.Drawing.Size(310, 26);
            this.CATALOGO.TabIndex = 1;
            // 
            // CODIGODEBARRAS
            // 
            this.CODIGODEBARRAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CODIGODEBARRAS.Location = new System.Drawing.Point(173, 50);
            this.CODIGODEBARRAS.Name = "CODIGODEBARRAS";
            this.CODIGODEBARRAS.Size = new System.Drawing.Size(310, 26);
            this.CODIGODEBARRAS.TabIndex = 2;
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAlta.Location = new System.Drawing.Point(637, 591);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(136, 44);
            this.btnAlta.TabIndex = 15;
            this.btnAlta.Text = "ALTA";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "CATALOGO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "COORDENADA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "DESCRIPCION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "CODIGO DE BARRAS";
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DESCRIPCION.Location = new System.Drawing.Point(123, 91);
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.Size = new System.Drawing.Size(650, 89);
            this.DESCRIPCION.TabIndex = 3;
            this.DESCRIPCION.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "UNIDAD";
            // 
            // UNIDAD
            // 
            this.UNIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNIDAD.Location = new System.Drawing.Point(123, 239);
            this.UNIDAD.Name = "UNIDAD";
            this.UNIDAD.Size = new System.Drawing.Size(79, 26);
            this.UNIDAD.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "MINIMO";
            // 
            // MINIMO
            // 
            this.MINIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MINIMO.Location = new System.Drawing.Point(123, 330);
            this.MINIMO.Name = "MINIMO";
            this.MINIMO.Size = new System.Drawing.Size(79, 26);
            this.MINIMO.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "MAXIMO";
            // 
            // MAXIMO
            // 
            this.MAXIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MAXIMO.Location = new System.Drawing.Point(123, 373);
            this.MAXIMO.Name = "MAXIMO";
            this.MAXIMO.Size = new System.Drawing.Size(79, 26);
            this.MAXIMO.TabIndex = 10;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(59, 199);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(56, 17);
            this.lblMarca.TabIndex = 18;
            this.lblMarca.Text = "MARCA";
            // 
            // MARCA
            // 
            this.MARCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MARCA.Location = new System.Drawing.Point(123, 196);
            this.MARCA.Name = "MARCA";
            this.MARCA.Size = new System.Drawing.Size(318, 26);
            this.MARCA.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(35, 591);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(153, 44);
            this.buttonCancelar.TabIndex = 19;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAdjuntarImagen
            // 
            this.buttonAdjuntarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjuntarImagen.Location = new System.Drawing.Point(288, 417);
            this.buttonAdjuntarImagen.Name = "buttonAdjuntarImagen";
            this.buttonAdjuntarImagen.Size = new System.Drawing.Size(153, 31);
            this.buttonAdjuntarImagen.TabIndex = 13;
            this.buttonAdjuntarImagen.Text = "Adjuntar Imagen";
            this.buttonAdjuntarImagen.UseVisualStyleBackColor = true;
            this.buttonAdjuntarImagen.Click += new System.EventHandler(this.buttonAdjuntarImagen_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(62, 560);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(610, 17);
            this.labelError.TabIndex = 22;
            this.labelError.Text = "***Los valores ingresados no corresponden a los campos llenados. Corrija y vuelva" +
    " a intentarlo.";
            this.labelError.Visible = false;
            // 
            // buttonAdjuntarDataSheet
            // 
            this.buttonAdjuntarDataSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjuntarDataSheet.Location = new System.Drawing.Point(49, 417);
            this.buttonAdjuntarDataSheet.Name = "buttonAdjuntarDataSheet";
            this.buttonAdjuntarDataSheet.Size = new System.Drawing.Size(153, 31);
            this.buttonAdjuntarDataSheet.TabIndex = 12;
            this.buttonAdjuntarDataSheet.Text = "Adjuntar Hoja de Datos";
            this.buttonAdjuntarDataSheet.UseVisualStyleBackColor = true;
            this.buttonAdjuntarDataSheet.Click += new System.EventHandler(this.buttonAdjuntarDataSheet_Click);
            // 
            // labelModulo
            // 
            this.labelModulo.AutoSize = true;
            this.labelModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModulo.Location = new System.Drawing.Point(245, 244);
            this.labelModulo.Name = "labelModulo";
            this.labelModulo.Size = new System.Drawing.Size(69, 17);
            this.labelModulo.TabIndex = 27;
            this.labelModulo.Text = "MODULO";
            // 
            // labelPrecioLista
            // 
            this.labelPrecioLista.AutoSize = true;
            this.labelPrecioLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioLista.Location = new System.Drawing.Point(213, 333);
            this.labelPrecioLista.Name = "labelPrecioLista";
            this.labelPrecioLista.Size = new System.Drawing.Size(101, 17);
            this.labelPrecioLista.TabIndex = 25;
            this.labelPrecioLista.Text = "PRECIO LISTA";
            // 
            // PRECIOLISTA
            // 
            this.PRECIOLISTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIOLISTA.Location = new System.Drawing.Point(320, 330);
            this.PRECIOLISTA.Name = "PRECIOLISTA";
            this.PRECIOLISTA.Size = new System.Drawing.Size(121, 26);
            this.PRECIOLISTA.TabIndex = 9;
            // 
            // Modulo
            // 
            this.Modulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modulo.FormattingEnabled = true;
            this.Modulo.Location = new System.Drawing.Point(320, 241);
            this.Modulo.Name = "Modulo";
            this.Modulo.Size = new System.Drawing.Size(121, 23);
            this.Modulo.TabIndex = 6;
            this.Modulo.SelectedIndexChanged += new System.EventHandler(this.Modulo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(245, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "MONEDA";
            // 
            // MONEDA
            // 
            this.MONEDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MONEDA.FormattingEnabled = true;
            this.MONEDA.Items.AddRange(new object[] {
            "USD",
            "MXP"});
            this.MONEDA.Location = new System.Drawing.Point(320, 376);
            this.MONEDA.Name = "MONEDA";
            this.MONEDA.Size = new System.Drawing.Size(121, 23);
            this.MONEDA.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(183, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 31);
            this.button1.TabIndex = 14;
            this.button1.Text = "Adjuntar Documentos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ADJUNTOS
            // 
            this.ADJUNTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADJUNTOS.Location = new System.Drawing.Point(271, 580);
            this.ADJUNTOS.Name = "ADJUNTOS";
            this.ADJUNTOS.ReadOnly = true;
            this.ADJUNTOS.Size = new System.Drawing.Size(180, 26);
            this.ADJUNTOS.TabIndex = 32;
            this.ADJUNTOS.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 520);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(318, 23);
            this.comboBox1.TabIndex = 421;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(35, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 31);
            this.button2.TabIndex = 422;
            this.button2.Text = "Quitar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DOCUMENTOS
            // 
            this.DOCUMENTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOCUMENTOS.Location = new System.Drawing.Point(271, 609);
            this.DOCUMENTOS.Name = "DOCUMENTOS";
            this.DOCUMENTOS.ReadOnly = true;
            this.DOCUMENTOS.Size = new System.Drawing.Size(180, 26);
            this.DOCUMENTOS.TabIndex = 423;
            this.DOCUMENTOS.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(489, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 26);
            this.button3.TabIndex = 424;
            this.button3.Text = "+";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(473, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 303);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // FormAltaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 644);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DOCUMENTOS);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ADJUNTOS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MONEDA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Modulo);
            this.Controls.Add(this.labelModulo);
            this.Controls.Add(this.labelPrecioLista);
            this.Controls.Add(this.PRECIOLISTA);
            this.Controls.Add(this.buttonAdjuntarDataSheet);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonAdjuntarImagen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.MARCA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MAXIMO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MINIMO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UNIDAD);
            this.Controls.Add(this.DESCRIPCION);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.CODIGODEBARRAS);
            this.Controls.Add(this.CATALOGO);
            this.Controls.Add(this.COORDENADA);
            this.Name = "FormAltaProductos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALTA DE PRODUCTOS";
            this.Load += new System.EventHandler(this.frmEditarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox COORDENADA;
        private System.Windows.Forms.TextBox CATALOGO;
        private System.Windows.Forms.TextBox CODIGODEBARRAS;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox DESCRIPCION;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UNIDAD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MINIMO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MAXIMO;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox MARCA;
        private System.Windows.Forms.Button buttonCancelar;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAdjuntarImagen;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonAdjuntarDataSheet;
        private System.Windows.Forms.Label labelModulo;
        private System.Windows.Forms.Label labelPrecioLista;
        private System.Windows.Forms.TextBox PRECIOLISTA;
        private System.Windows.Forms.ComboBox Modulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox MONEDA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ADJUNTOS;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox DOCUMENTOS;
        private System.Windows.Forms.Button button3;
    }
}