namespace Form1
{
    partial class FormProductoSpec
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
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.lblCatalogo = new System.Windows.Forms.Label();
            this.DESCRIPCION = new System.Windows.Forms.RichTextBox();
            this.buttonDataSheet = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelMaximo = new System.Windows.Forms.Label();
            this.labelMinimo = new System.Windows.Forms.Label();
            this.labelOrdenados = new System.Windows.Forms.Label();
            this.labelFechaOrden = new System.Windows.Forms.Label();
            this.CODIGODEBARRAS = new System.Windows.Forms.TextBox();
            this.MARCA = new System.Windows.Forms.TextBox();
            this.COORDENADA = new System.Windows.Forms.TextBox();
            this.MINIMO = new System.Windows.Forms.TextBox();
            this.MAXIMO = new System.Windows.Forms.TextBox();
            this.textFechaOrdenados = new System.Windows.Forms.TextBox();
            this.ORDENADO = new System.Windows.Forms.TextBox();
            this.buttonAdjuntarDataSheet = new System.Windows.Forms.Button();
            this.buttonAdjuntarImagen = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.ButtonGuardarCambios = new System.Windows.Forms.Button();
            this.STOCK = new System.Windows.Forms.TextBox();
            this.UNIDAD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPrecioLista = new System.Windows.Forms.Label();
            this.PrecioAlmacen = new System.Windows.Forms.TextBox();
            this.buttonAjustarStock = new System.Windows.Forms.Button();
            this.FECHA_AJUSTE = new System.Windows.Forms.TextBox();
            this.AJUSTE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAdvertencia1 = new System.Windows.Forms.Label();
            this.labelActualizacion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditPU = new System.Windows.Forms.Button();
            this.buttonAgregarPartida = new System.Windows.Forms.Button();
            this.buttonSoloCerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ADJUNTOS = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CATALOGO = new System.Windows.Forms.TextBox();
            this.DOCUMENTOS = new System.Windows.Forms.TextBox();
            this.ckmuerto = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(67, 161);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(56, 17);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "MARCA";
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoBarras.Location = new System.Drawing.Point(8, 130);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(146, 17);
            this.lblCodigoBarras.TabIndex = 2;
            this.lblCodigoBarras.Text = "CODIGO DE BARRAS";
            // 
            // lblCatalogo
            // 
            this.lblCatalogo.AutoSize = true;
            this.lblCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalogo.Location = new System.Drawing.Point(78, 20);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new System.Drawing.Size(85, 17);
            this.lblCatalogo.TabIndex = 3;
            this.lblCatalogo.Text = "CATALOGO";
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.Location = new System.Drawing.Point(12, 53);
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Size = new System.Drawing.Size(504, 66);
            this.DESCRIPCION.TabIndex = 2;
            this.DESCRIPCION.Text = "";
            this.DESCRIPCION.TextChanged += new System.EventHandler(this.richTextBoxDescripcion_TextChanged);
            // 
            // buttonDataSheet
            // 
            this.buttonDataSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataSheet.Location = new System.Drawing.Point(690, 421);
            this.buttonDataSheet.Name = "buttonDataSheet";
            this.buttonDataSheet.Size = new System.Drawing.Size(131, 30);
            this.buttonDataSheet.TabIndex = 17;
            this.buttonDataSheet.Text = "Data Sheet PDF";
            this.buttonDataSheet.UseVisualStyleBackColor = true;
            this.buttonDataSheet.Click += new System.EventHandler(this.buttonDataSheet_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditar.Location = new System.Drawing.Point(327, 474);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(131, 30);
            this.buttonEditar.TabIndex = 12;
            this.buttonEditar.Text = "EDITAR";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(191, 526);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(131, 24);
            this.buttonCancelar.TabIndex = 14;
            this.buttonCancelar.Text = "Cerrar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUbicacion.Location = new System.Drawing.Point(37, 198);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(81, 17);
            this.labelUbicacion.TabIndex = 10;
            this.labelUbicacion.Text = "UBICACION";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelStock.Location = new System.Drawing.Point(26, 271);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(92, 26);
            this.labelStock.TabIndex = 11;
            this.labelStock.Text = "STOCK";
            // 
            // labelMaximo
            // 
            this.labelMaximo.AutoSize = true;
            this.labelMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaximo.Location = new System.Drawing.Point(61, 392);
            this.labelMaximo.Name = "labelMaximo";
            this.labelMaximo.Size = new System.Drawing.Size(62, 17);
            this.labelMaximo.TabIndex = 12;
            this.labelMaximo.Text = "MAXIMO";
            // 
            // labelMinimo
            // 
            this.labelMinimo.AutoSize = true;
            this.labelMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimo.Location = new System.Drawing.Point(58, 353);
            this.labelMinimo.Name = "labelMinimo";
            this.labelMinimo.Size = new System.Drawing.Size(57, 17);
            this.labelMinimo.TabIndex = 13;
            this.labelMinimo.Text = "MINIMO";
            // 
            // labelOrdenados
            // 
            this.labelOrdenados.AutoSize = true;
            this.labelOrdenados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrdenados.Location = new System.Drawing.Point(18, 314);
            this.labelOrdenados.Name = "labelOrdenados";
            this.labelOrdenados.Size = new System.Drawing.Size(97, 17);
            this.labelOrdenados.TabIndex = 14;
            this.labelOrdenados.Text = "ORDENADOS";
            // 
            // labelFechaOrden
            // 
            this.labelFechaOrden.AutoSize = true;
            this.labelFechaOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaOrden.Location = new System.Drawing.Point(5, 424);
            this.labelFechaOrden.Name = "labelFechaOrden";
            this.labelFechaOrden.Size = new System.Drawing.Size(107, 17);
            this.labelFechaOrden.TabIndex = 15;
            this.labelFechaOrden.Text = "FECHA ORDEN";
            this.labelFechaOrden.Visible = false;
            // 
            // CODIGODEBARRAS
            // 
            this.CODIGODEBARRAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CODIGODEBARRAS.Location = new System.Drawing.Point(160, 125);
            this.CODIGODEBARRAS.Name = "CODIGODEBARRAS";
            this.CODIGODEBARRAS.Size = new System.Drawing.Size(315, 26);
            this.CODIGODEBARRAS.TabIndex = 3;
            this.CODIGODEBARRAS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CODIGODEBARRAS_KeyDown);
            // 
            // MARCA
            // 
            this.MARCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MARCA.Location = new System.Drawing.Point(132, 158);
            this.MARCA.Name = "MARCA";
            this.MARCA.ReadOnly = true;
            this.MARCA.Size = new System.Drawing.Size(209, 26);
            this.MARCA.TabIndex = 4;
            // 
            // COORDENADA
            // 
            this.COORDENADA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COORDENADA.Location = new System.Drawing.Point(132, 195);
            this.COORDENADA.Name = "COORDENADA";
            this.COORDENADA.ReadOnly = true;
            this.COORDENADA.Size = new System.Drawing.Size(209, 26);
            this.COORDENADA.TabIndex = 5;
            // 
            // MINIMO
            // 
            this.MINIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MINIMO.Location = new System.Drawing.Point(130, 349);
            this.MINIMO.Name = "MINIMO";
            this.MINIMO.ReadOnly = true;
            this.MINIMO.Size = new System.Drawing.Size(89, 26);
            this.MINIMO.TabIndex = 9;
            // 
            // MAXIMO
            // 
            this.MAXIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MAXIMO.Location = new System.Drawing.Point(130, 386);
            this.MAXIMO.Name = "MAXIMO";
            this.MAXIMO.ReadOnly = true;
            this.MAXIMO.Size = new System.Drawing.Size(89, 26);
            this.MAXIMO.TabIndex = 10;
            // 
            // textFechaOrdenados
            // 
            this.textFechaOrdenados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFechaOrdenados.Location = new System.Drawing.Point(132, 421);
            this.textFechaOrdenados.Name = "textFechaOrdenados";
            this.textFechaOrdenados.ReadOnly = true;
            this.textFechaOrdenados.Size = new System.Drawing.Size(174, 26);
            this.textFechaOrdenados.TabIndex = 11;
            this.textFechaOrdenados.Visible = false;
            // 
            // ORDENADO
            // 
            this.ORDENADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORDENADO.Location = new System.Drawing.Point(132, 308);
            this.ORDENADO.Name = "ORDENADO";
            this.ORDENADO.ReadOnly = true;
            this.ORDENADO.Size = new System.Drawing.Size(89, 26);
            this.ORDENADO.TabIndex = 8;
            // 
            // buttonAdjuntarDataSheet
            // 
            this.buttonAdjuntarDataSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjuntarDataSheet.Location = new System.Drawing.Point(617, 519);
            this.buttonAdjuntarDataSheet.Name = "buttonAdjuntarDataSheet";
            this.buttonAdjuntarDataSheet.Size = new System.Drawing.Size(153, 31);
            this.buttonAdjuntarDataSheet.TabIndex = 16;
            this.buttonAdjuntarDataSheet.Text = "Adjuntar Hoja de Datos";
            this.buttonAdjuntarDataSheet.UseVisualStyleBackColor = true;
            this.buttonAdjuntarDataSheet.Visible = false;
            this.buttonAdjuntarDataSheet.Click += new System.EventHandler(this.buttonAdjuntarDataSheet_Click);
            // 
            // buttonAdjuntarImagen
            // 
            this.buttonAdjuntarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjuntarImagen.Location = new System.Drawing.Point(447, 519);
            this.buttonAdjuntarImagen.Name = "buttonAdjuntarImagen";
            this.buttonAdjuntarImagen.Size = new System.Drawing.Size(153, 31);
            this.buttonAdjuntarImagen.TabIndex = 15;
            this.buttonAdjuntarImagen.Text = "Adjuntar Imagen";
            this.buttonAdjuntarImagen.UseVisualStyleBackColor = true;
            this.buttonAdjuntarImagen.Visible = false;
            this.buttonAdjuntarImagen.Click += new System.EventHandler(this.buttonAdjuntarImagen_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(9, 454);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(610, 17);
            this.labelError.TabIndex = 26;
            this.labelError.Text = "***Los valores ingresados no corresponden a los campos llenados. Corrija y vuelva" +
    " a intentarlo.";
            this.labelError.Visible = false;
            // 
            // ButtonGuardarCambios
            // 
            this.ButtonGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGuardarCambios.Location = new System.Drawing.Point(326, 474);
            this.ButtonGuardarCambios.Name = "ButtonGuardarCambios";
            this.ButtonGuardarCambios.Size = new System.Drawing.Size(159, 30);
            this.ButtonGuardarCambios.TabIndex = 13;
            this.ButtonGuardarCambios.Text = "GUARDAR CAMBIOS";
            this.ButtonGuardarCambios.UseVisualStyleBackColor = true;
            this.ButtonGuardarCambios.Visible = false;
            this.ButtonGuardarCambios.Click += new System.EventHandler(this.ButtonGuardarCambios_Click);
            // 
            // STOCK
            // 
            this.STOCK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STOCK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.STOCK.Location = new System.Drawing.Point(132, 271);
            this.STOCK.Name = "STOCK";
            this.STOCK.ReadOnly = true;
            this.STOCK.Size = new System.Drawing.Size(89, 26);
            this.STOCK.TabIndex = 7;
            this.STOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UNIDAD
            // 
            this.UNIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNIDAD.Location = new System.Drawing.Point(132, 231);
            this.UNIDAD.Name = "UNIDAD";
            this.UNIDAD.ReadOnly = true;
            this.UNIDAD.Size = new System.Drawing.Size(89, 26);
            this.UNIDAD.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "UNIDAD";
            // 
            // labelPrecioLista
            // 
            this.labelPrecioLista.AutoSize = true;
            this.labelPrecioLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioLista.Location = new System.Drawing.Point(336, 231);
            this.labelPrecioLista.Name = "labelPrecioLista";
            this.labelPrecioLista.Size = new System.Drawing.Size(54, 13);
            this.labelPrecioLista.TabIndex = 31;
            this.labelPrecioLista.Text = "P.U. USD";
            // 
            // PrecioAlmacen
            // 
            this.PrecioAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioAlmacen.Location = new System.Drawing.Point(399, 228);
            this.PrecioAlmacen.Name = "PrecioAlmacen";
            this.PrecioAlmacen.ReadOnly = true;
            this.PrecioAlmacen.Size = new System.Drawing.Size(117, 20);
            this.PrecioAlmacen.TabIndex = 30;
            // 
            // buttonAjustarStock
            // 
            this.buttonAjustarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjustarStock.Location = new System.Drawing.Point(357, 380);
            this.buttonAjustarStock.Name = "buttonAjustarStock";
            this.buttonAjustarStock.Size = new System.Drawing.Size(159, 30);
            this.buttonAjustarStock.TabIndex = 34;
            this.buttonAjustarStock.Text = "AJUSTAR STOCK";
            this.buttonAjustarStock.UseVisualStyleBackColor = true;
            this.buttonAjustarStock.Visible = false;
            this.buttonAjustarStock.Click += new System.EventHandler(this.buttonAjustarStock_Click);
            // 
            // FECHA_AJUSTE
            // 
            this.FECHA_AJUSTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FECHA_AJUSTE.Location = new System.Drawing.Point(423, 344);
            this.FECHA_AJUSTE.Name = "FECHA_AJUSTE";
            this.FECHA_AJUSTE.ReadOnly = true;
            this.FECHA_AJUSTE.Size = new System.Drawing.Size(89, 26);
            this.FECHA_AJUSTE.TabIndex = 36;
            // 
            // AJUSTE
            // 
            this.AJUSTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AJUSTE.Location = new System.Drawing.Point(423, 312);
            this.AJUSTE.Name = "AJUSTE";
            this.AJUSTE.ReadOnly = true;
            this.AJUSTE.Size = new System.Drawing.Size(89, 26);
            this.AJUSTE.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "ID_CONTEO_ULT.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "FECHA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "37";
            // 
            // textBox37
            // 
            this.textBox37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox37.Location = new System.Drawing.Point(399, 253);
            this.textBox37.Name = "textBox37";
            this.textBox37.ReadOnly = true;
            this.textBox37.Size = new System.Drawing.Size(117, 20);
            this.textBox37.TabIndex = 40;
            // 
            // textBox50
            // 
            this.textBox50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox50.Location = new System.Drawing.Point(400, 279);
            this.textBox50.Name = "textBox50";
            this.textBox50.ReadOnly = true;
            this.textBox50.Size = new System.Drawing.Size(117, 20);
            this.textBox50.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(366, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "50";
            // 
            // labelAdvertencia1
            // 
            this.labelAdvertencia1.AutoSize = true;
            this.labelAdvertencia1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdvertencia1.ForeColor = System.Drawing.Color.Red;
            this.labelAdvertencia1.Location = new System.Drawing.Point(324, 245);
            this.labelAdvertencia1.Name = "labelAdvertencia1";
            this.labelAdvertencia1.Size = new System.Drawing.Size(190, 13);
            this.labelAdvertencia1.TabIndex = 43;
            this.labelAdvertencia1.Text = "Precio no Valio hasta nueva existencia";
            this.labelAdvertencia1.Visible = false;
            // 
            // labelActualizacion
            // 
            this.labelActualizacion.AutoSize = true;
            this.labelActualizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActualizacion.ForeColor = System.Drawing.Color.Red;
            this.labelActualizacion.Location = new System.Drawing.Point(410, 212);
            this.labelActualizacion.Name = "labelActualizacion";
            this.labelActualizacion.Size = new System.Drawing.Size(75, 13);
            this.labelActualizacion.TabIndex = 44;
            this.labelActualizacion.Text = "UltimaCompra:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(410, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Actualizada:";
            // 
            // buttonEditPU
            // 
            this.buttonEditPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditPU.Location = new System.Drawing.Point(357, 417);
            this.buttonEditPU.Name = "buttonEditPU";
            this.buttonEditPU.Size = new System.Drawing.Size(159, 30);
            this.buttonEditPU.TabIndex = 46;
            this.buttonEditPU.Text = "EDITAR PU";
            this.buttonEditPU.UseVisualStyleBackColor = true;
            this.buttonEditPU.Visible = false;
            this.buttonEditPU.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAgregarPartida
            // 
            this.buttonAgregarPartida.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonAgregarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarPartida.Location = new System.Drawing.Point(841, 467);
            this.buttonAgregarPartida.Name = "buttonAgregarPartida";
            this.buttonAgregarPartida.Size = new System.Drawing.Size(131, 30);
            this.buttonAgregarPartida.TabIndex = 47;
            this.buttonAgregarPartida.Text = "AGREGAR PARTIDA";
            this.buttonAgregarPartida.UseVisualStyleBackColor = true;
            this.buttonAgregarPartida.Visible = false;
            this.buttonAgregarPartida.Click += new System.EventHandler(this.buttonAgregarPartida_Click);
            // 
            // buttonSoloCerrar
            // 
            this.buttonSoloCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSoloCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSoloCerrar.Location = new System.Drawing.Point(55, 526);
            this.buttonSoloCerrar.Name = "buttonSoloCerrar";
            this.buttonSoloCerrar.Size = new System.Drawing.Size(131, 24);
            this.buttonSoloCerrar.TabIndex = 48;
            this.buttonSoloCerrar.Text = "CERRAR VENTANA";
            this.buttonSoloCerrar.UseVisualStyleBackColor = true;
            this.buttonSoloCerrar.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(358, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 30);
            this.button1.TabIndex = 49;
            this.button1.Text = "COSTOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(783, 519);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 31);
            this.button2.TabIndex = 422;
            this.button2.Text = "Adjuntar Documentos";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ADJUNTOS
            // 
            this.ADJUNTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADJUNTOS.Location = new System.Drawing.Point(341, 524);
            this.ADJUNTOS.Name = "ADJUNTOS";
            this.ADJUNTOS.Size = new System.Drawing.Size(79, 26);
            this.ADJUNTOS.TabIndex = 423;
            this.ADJUNTOS.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gainsboro;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(690, 466);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 31);
            this.button3.TabIndex = 424;
            this.button3.Text = "Documentos";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CATALOGO
            // 
            this.CATALOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CATALOGO.Location = new System.Drawing.Point(177, 17);
            this.CATALOGO.Name = "CATALOGO";
            this.CATALOGO.ReadOnly = true;
            this.CATALOGO.Size = new System.Drawing.Size(325, 26);
            this.CATALOGO.TabIndex = 1;
            // 
            // DOCUMENTOS
            // 
            this.DOCUMENTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOCUMENTOS.Location = new System.Drawing.Point(553, 485);
            this.DOCUMENTOS.Name = "DOCUMENTOS";
            this.DOCUMENTOS.Size = new System.Drawing.Size(79, 26);
            this.DOCUMENTOS.TabIndex = 425;
            this.DOCUMENTOS.Visible = false;
            // 
            // ckmuerto
            // 
            this.ckmuerto.AutoSize = true;
            this.ckmuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckmuerto.Location = new System.Drawing.Point(40, 482);
            this.ckmuerto.Name = "ckmuerto";
            this.ckmuerto.Size = new System.Drawing.Size(212, 29);
            this.ckmuerto.TabIndex = 426;
            this.ckmuerto.Text = "STOCK MUERTO";
            this.ckmuerto.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(522, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(485, 126);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 26);
            this.button4.TabIndex = 427;
            this.button4.Text = "+";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(225, 270);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 30);
            this.button5.TabIndex = 428;
            this.button5.Text = "VALIDAR";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormProductoSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 557);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ckmuerto);
            this.Controls.Add(this.DOCUMENTOS);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ADJUNTOS);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSoloCerrar);
            this.Controls.Add(this.buttonAgregarPartida);
            this.Controls.Add(this.buttonEditPU);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelActualizacion);
            this.Controls.Add(this.labelAdvertencia1);
            this.Controls.Add(this.textBox50);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox37);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FECHA_AJUSTE);
            this.Controls.Add(this.AJUSTE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAjustarStock);
            this.Controls.Add(this.labelPrecioLista);
            this.Controls.Add(this.PrecioAlmacen);
            this.Controls.Add(this.UNIDAD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.STOCK);
            this.Controls.Add(this.ButtonGuardarCambios);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonAdjuntarDataSheet);
            this.Controls.Add(this.buttonAdjuntarImagen);
            this.Controls.Add(this.textFechaOrdenados);
            this.Controls.Add(this.ORDENADO);
            this.Controls.Add(this.MAXIMO);
            this.Controls.Add(this.MINIMO);
            this.Controls.Add(this.COORDENADA);
            this.Controls.Add(this.MARCA);
            this.Controls.Add(this.CODIGODEBARRAS);
            this.Controls.Add(this.CATALOGO);
            this.Controls.Add(this.labelFechaOrden);
            this.Controls.Add(this.labelOrdenados);
            this.Controls.Add(this.labelMinimo);
            this.Controls.Add(this.labelMaximo);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelUbicacion);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonDataSheet);
            this.Controls.Add(this.DESCRIPCION);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCatalogo);
            this.Controls.Add(this.lblCodigoBarras);
            this.Controls.Add(this.lblMarca);
            this.Name = "FormProductoSpec";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESPECIFICACIONES DEL PRODUCTO";
            this.Load += new System.EventHandler(this.FormProductoSpec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormProductoSpec_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.Label lblCatalogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox DESCRIPCION;
        private System.Windows.Forms.Button buttonDataSheet;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelMaximo;
        private System.Windows.Forms.Label labelMinimo;
        private System.Windows.Forms.Label labelOrdenados;
        private System.Windows.Forms.Label labelFechaOrden;
        private System.Windows.Forms.TextBox CODIGODEBARRAS;
        private System.Windows.Forms.TextBox MARCA;
        private System.Windows.Forms.TextBox COORDENADA;
        private System.Windows.Forms.TextBox MINIMO;
        private System.Windows.Forms.TextBox MAXIMO;
        private System.Windows.Forms.TextBox textFechaOrdenados;
        private System.Windows.Forms.TextBox ORDENADO;
        private System.Windows.Forms.Button buttonAdjuntarDataSheet;
        private System.Windows.Forms.Button buttonAdjuntarImagen;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button ButtonGuardarCambios;
        private System.Windows.Forms.TextBox STOCK;
        private System.Windows.Forms.TextBox UNIDAD;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelPrecioLista;
        public System.Windows.Forms.TextBox PrecioAlmacen;
        private System.Windows.Forms.Button buttonAjustarStock;
        private System.Windows.Forms.TextBox FECHA_AJUSTE;
        private System.Windows.Forms.TextBox AJUSTE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox37;
        public System.Windows.Forms.TextBox textBox50;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelAdvertencia1;
        public System.Windows.Forms.Label labelActualizacion;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditPU;
        private System.Windows.Forms.Button buttonAgregarPartida;
        private System.Windows.Forms.Button buttonSoloCerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ADJUNTOS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox CATALOGO;
        private System.Windows.Forms.TextBox DOCUMENTOS;
        private System.Windows.Forms.CheckBox ckmuerto;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}