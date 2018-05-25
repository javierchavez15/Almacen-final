namespace Form1
{
    partial class FormENTRADAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxTC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxProyectoId = new System.Windows.Forms.TextBox();
            this.buttonNewProject = new System.Windows.Forms.Button();
            this.labelProyecto = new System.Windows.Forms.Label();
            this.comboBoxProyecto = new System.Windows.Forms.ComboBox();
            this.checkBoxPorProyecto = new System.Windows.Forms.CheckBox();
            this.comboBoxMonedaCompra = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBoxOENid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxProveedores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFACTURAP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.textBoxProducto = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.buttonIngresarHoja = new System.Windows.Forms.Button();
            this.dateTimePickerFacturaP = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ingresarOREPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITARMODIFICARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboVendedor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtpedimento = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.ckimportacion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTC
            // 
            this.textBoxTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTC.Location = new System.Drawing.Point(749, 68);
            this.textBoxTC.Name = "textBoxTC";
            this.textBoxTC.Size = new System.Drawing.Size(100, 22);
            this.textBoxTC.TabIndex = 3;
            this.textBoxTC.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(711, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 16);
            this.label11.TabIndex = 94;
            this.label11.Text = "TC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(243, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 92;
            this.label10.Text = "# Proyecto:";
            // 
            // textBoxProyectoId
            // 
            this.textBoxProyectoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProyectoId.Location = new System.Drawing.Point(329, 2);
            this.textBoxProyectoId.Name = "textBoxProyectoId";
            this.textBoxProyectoId.ReadOnly = true;
            this.textBoxProyectoId.Size = new System.Drawing.Size(91, 22);
            this.textBoxProyectoId.TabIndex = 91;
            this.textBoxProyectoId.Text = "0";
            // 
            // buttonNewProject
            // 
            this.buttonNewProject.Enabled = false;
            this.buttonNewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewProject.Location = new System.Drawing.Point(14, 87);
            this.buttonNewProject.Name = "buttonNewProject";
            this.buttonNewProject.Size = new System.Drawing.Size(75, 23);
            this.buttonNewProject.TabIndex = 90;
            this.buttonNewProject.Text = "Nuevo";
            this.buttonNewProject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNewProject.UseVisualStyleBackColor = true;
            this.buttonNewProject.Visible = false;
            this.buttonNewProject.Click += new System.EventHandler(this.buttonNewProject_Click);
            // 
            // labelProyecto
            // 
            this.labelProyecto.AutoSize = true;
            this.labelProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProyecto.Location = new System.Drawing.Point(35, 34);
            this.labelProyecto.Name = "labelProyecto";
            this.labelProyecto.Size = new System.Drawing.Size(83, 16);
            this.labelProyecto.TabIndex = 89;
            this.labelProyecto.Text = "PROYECTO";
            // 
            // comboBoxProyecto
            // 
            this.comboBoxProyecto.Enabled = false;
            this.comboBoxProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyecto.FormattingEnabled = true;
            this.comboBoxProyecto.Location = new System.Drawing.Point(121, 32);
            this.comboBoxProyecto.Name = "comboBoxProyecto";
            this.comboBoxProyecto.Size = new System.Drawing.Size(728, 24);
            this.comboBoxProyecto.TabIndex = 88;
            this.comboBoxProyecto.SelectedIndexChanged += new System.EventHandler(this.comboBoxProyecto_SelectedIndexChanged);
            // 
            // checkBoxPorProyecto
            // 
            this.checkBoxPorProyecto.AutoSize = true;
            this.checkBoxPorProyecto.Location = new System.Drawing.Point(14, 34);
            this.checkBoxPorProyecto.Name = "checkBoxPorProyecto";
            this.checkBoxPorProyecto.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPorProyecto.TabIndex = 87;
            this.checkBoxPorProyecto.UseVisualStyleBackColor = true;
            this.checkBoxPorProyecto.CheckedChanged += new System.EventHandler(this.checkBoxPorProyecto_CheckedChanged);
            // 
            // comboBoxMonedaCompra
            // 
            this.comboBoxMonedaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonedaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMonedaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMonedaCompra.FormattingEnabled = true;
            this.comboBoxMonedaCompra.Items.AddRange(new object[] {
            "USD",
            "PMX"});
            this.comboBoxMonedaCompra.Location = new System.Drawing.Point(614, 65);
            this.comboBoxMonedaCompra.Name = "comboBoxMonedaCompra";
            this.comboBoxMonedaCompra.Size = new System.Drawing.Size(91, 23);
            this.comboBoxMonedaCompra.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(524, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 82;
            this.label7.Text = "MONEDA";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Location = new System.Drawing.Point(2, 163);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.Size = new System.Drawing.Size(1224, 514);
            this.dataGridView2.TabIndex = 80;
            // 
            // textBoxOENid
            // 
            this.textBoxOENid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOENid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOENid.Location = new System.Drawing.Point(1075, 3);
            this.textBoxOENid.Name = "textBoxOENid";
            this.textBoxOENid.ReadOnly = true;
            this.textBoxOENid.Size = new System.Drawing.Size(151, 22);
            this.textBoxOENid.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1019, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "# OEN:";
            // 
            // comboBoxProveedores
            // 
            this.comboBoxProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProveedores.FormattingEnabled = true;
            this.comboBoxProveedores.Location = new System.Drawing.Point(121, 65);
            this.comboBoxProveedores.Name = "comboBoxProveedores";
            this.comboBoxProveedores.Size = new System.Drawing.Size(384, 24);
            this.comboBoxProveedores.TabIndex = 1;
            this.comboBoxProveedores.SelectedIndexChanged += new System.EventHandler(this.comboBoxProveedores_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 77;
            this.label4.Text = "PROVEEDOR";
            // 
            // txtFACTURAP
            // 
            this.txtFACTURAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFACTURAP.Location = new System.Drawing.Point(121, 100);
            this.txtFACTURAP.Name = "txtFACTURAP";
            this.txtFACTURAP.Size = new System.Drawing.Size(153, 22);
            this.txtFACTURAP.TabIndex = 4;
            this.txtFACTURAP.Leave += new System.EventHandler(this.txtFACTURAP_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "FACTURA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(510, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 75;
            this.label2.Text = "QTY";
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCantidad.Location = new System.Drawing.Point(562, 129);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(100, 29);
            this.textBoxCantidad.TabIndex = 8;
            this.textBoxCantidad.Text = "1";
            this.textBoxCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxProducto
            // 
            this.textBoxProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProducto.Location = new System.Drawing.Point(121, 129);
            this.textBoxProducto.Name = "textBoxProducto";
            this.textBoxProducto.Size = new System.Drawing.Size(345, 29);
            this.textBoxProducto.TabIndex = 7;
            this.textBoxProducto.TextChanged += new System.EventHandler(this.textBoxProducto_TextChanged);
            this.textBoxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProducto_KeyDown);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(0, 683);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(172, 28);
            this.buttonCancelar.TabIndex = 73;
            this.buttonCancelar.Text = "CANCELAR HOJA";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "PRODUCTO";
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngresar.Location = new System.Drawing.Point(666, 128);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(183, 29);
            this.buttonIngresar.TabIndex = 9;
            this.buttonIngresar.Text = "INGRESAR PRODUCTO";
            this.buttonIngresar.UseVisualStyleBackColor = true;
            this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click_1);
            // 
            // buttonIngresarHoja
            // 
            this.buttonIngresarHoja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIngresarHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngresarHoja.Location = new System.Drawing.Point(1027, 683);
            this.buttonIngresarHoja.Name = "buttonIngresarHoja";
            this.buttonIngresarHoja.Size = new System.Drawing.Size(199, 29);
            this.buttonIngresarHoja.TabIndex = 10;
            this.buttonIngresarHoja.Text = "IMPRIMIR HOJA";
            this.buttonIngresarHoja.UseVisualStyleBackColor = true;
            this.buttonIngresarHoja.Click += new System.EventHandler(this.buttonIngresarHoja_Click);
            // 
            // dateTimePickerFacturaP
            // 
            this.dateTimePickerFacturaP.Location = new System.Drawing.Point(402, 100);
            this.dateTimePickerFacturaP.Name = "dateTimePickerFacturaP";
            this.dateTimePickerFacturaP.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFacturaP.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(279, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 97;
            this.label6.Text = "FECHA FACTURA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(855, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 98;
            this.label8.Text = "Tipo Cambio";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarOREPToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1228, 24);
            this.menuStrip1.TabIndex = 99;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ingresarOREPToolStripMenuItem
            // 
            this.ingresarOREPToolStripMenuItem.Name = "ingresarOREPToolStripMenuItem";
            this.ingresarOREPToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.ingresarOREPToolStripMenuItem.Text = "IngresarOREP";
            this.ingresarOREPToolStripMenuItem.Click += new System.EventHandler(this.ingresarOREPToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLTAToolStripMenuItem,
            this.eDITARMODIFICARToolStripMenuItem});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // aLTAToolStripMenuItem
            // 
            this.aLTAToolStripMenuItem.Name = "aLTAToolStripMenuItem";
            this.aLTAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aLTAToolStripMenuItem.Text = "ALTA";
            this.aLTAToolStripMenuItem.Click += new System.EventHandler(this.aLTAToolStripMenuItem_Click);
            // 
            // eDITARMODIFICARToolStripMenuItem
            // 
            this.eDITARMODIFICARToolStripMenuItem.Name = "eDITARMODIFICARToolStripMenuItem";
            this.eDITARMODIFICARToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eDITARMODIFICARToolStripMenuItem.Text = "EDITAR/MODIFICAR";
            this.eDITARMODIFICARToolStripMenuItem.Click += new System.EventHandler(this.eDITARMODIFICARToolStripMenuItem_Click);
            // 
            // comboVendedor
            // 
            this.comboVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboVendedor.FormattingEnabled = true;
            this.comboVendedor.Location = new System.Drawing.Point(1044, 63);
            this.comboVendedor.Name = "comboVendedor";
            this.comboVendedor.Size = new System.Drawing.Size(182, 24);
            this.comboVendedor.TabIndex = 100;
            this.comboVendedor.SelectedIndexChanged += new System.EventHandler(this.comboVendedor_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(959, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 101;
            this.label9.Text = "VENDEDOR";
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.Enabled = false;
            this.comboBoxClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(947, 31);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(279, 24);
            this.comboBoxClientes.TabIndex = 102;
            this.comboBoxClientes.Visible = false;
            this.comboBoxClientes.SelectedIndexChanged += new System.EventHandler(this.comboBoxClientes_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(877, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 103;
            this.label12.Text = "CLIENTE";
            this.label12.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1075, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 25);
            this.button2.TabIndex = 425;
            this.button2.Text = "Quitar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(879, 128);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 23);
            this.comboBox1.TabIndex = 424;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1073, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 25);
            this.button1.TabIndex = 423;
            this.button1.Text = "Adjuntar Documentos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtpedimento
            // 
            this.txtpedimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpedimento.Location = new System.Drawing.Point(879, 96);
            this.txtpedimento.Name = "txtpedimento";
            this.txtpedimento.Size = new System.Drawing.Size(190, 22);
            this.txtpedimento.TabIndex = 6;
            this.txtpedimento.Leave += new System.EventHandler(this.txtpedimento_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(746, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 16);
            this.label13.TabIndex = 427;
            this.label13.Text = "NO. PEDIMENTO";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(468, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 29);
            this.button3.TabIndex = 428;
            this.button3.Text = "+";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ckimportacion
            // 
            this.ckimportacion.AutoSize = true;
            this.ckimportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckimportacion.Location = new System.Drawing.Point(798, 689);
            this.ckimportacion.Name = "ckimportacion";
            this.ckimportacion.Size = new System.Drawing.Size(223, 20);
            this.ckimportacion.TabIndex = 429;
            this.ckimportacion.Text = "APLICAR 8% DE IMPORTACION";
            this.ckimportacion.UseVisualStyleBackColor = true;
            // 
            // FormENTRADAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 715);
            this.Controls.Add(this.ckimportacion);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtpedimento);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxClientes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboVendedor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerFacturaP);
            this.Controls.Add(this.buttonIngresarHoja);
            this.Controls.Add(this.textBoxTC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxProyectoId);
            this.Controls.Add(this.buttonNewProject);
            this.Controls.Add(this.labelProyecto);
            this.Controls.Add(this.comboBoxProyecto);
            this.Controls.Add(this.checkBoxPorProyecto);
            this.Controls.Add(this.comboBoxMonedaCompra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBoxOENid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxProveedores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFACTURAP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.textBoxProducto);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonIngresar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(870, 754);
            this.Name = "FormENTRADAS";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORDEN DE ENTRADA OEN";
            this.Load += new System.EventHandler(this.FormENTRADAS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxProyectoId;
        private System.Windows.Forms.Button buttonNewProject;
        private System.Windows.Forms.Label labelProyecto;
        private System.Windows.Forms.ComboBox comboBoxProyecto;
        private System.Windows.Forms.CheckBox checkBoxPorProyecto;
        private System.Windows.Forms.ComboBox comboBoxMonedaCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBoxOENid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxProveedores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFACTURAP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.TextBox textBoxProducto;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.Button buttonIngresarHoja;
        private System.Windows.Forms.DateTimePicker dateTimePickerFacturaP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ingresarOREPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLTAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITARMODIFICARToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboVendedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtpedimento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ckimportacion;
    }
}