﻿namespace Form1
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.textBoxCatalogo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eNTRADASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERAROSAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vERTODASToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pORPRODUCTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIDASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERAROSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vERTODASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pORPRODUCTOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pROYECTOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nUEVOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vERTODOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPOSICIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERAROREPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vEROREPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pORPRODUCTOToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aLTABAJAEDICIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTAEXISTENCIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESPALDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFLACIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOSTOALMACENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1218, 564);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1223, 37);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(156, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Cerrar";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(1073, 34);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(144, 32);
            this.buttonBuscar.TabIndex = 3;
            this.buttonBuscar.Text = "BUSCAR";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // textBoxCatalogo
            // 
            this.textBoxCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCatalogo.Location = new System.Drawing.Point(199, 37);
            this.textBoxCatalogo.Name = "textBoxCatalogo";
            this.textBoxCatalogo.Size = new System.Drawing.Size(431, 29);
            this.textBoxCatalogo.TabIndex = 1;
            this.textBoxCatalogo.TextChanged += new System.EventHandler(this.textBoxCatalogo_TextChanged);
            this.textBoxCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCatalogo_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eNTRADASToolStripMenuItem,
            this.sALIDASToolStripMenuItem,
            this.rEPOSICIONESToolStripMenuItem,
            this.aLTABAJAEDICIONToolStripMenuItem,
            this.lISTAEXISTENCIASToolStripMenuItem,
            this.rESPALDOSToolStripMenuItem,
            this.rToolStripMenuItem,
            this.iNFLACIONToolStripMenuItem,
            this.cOSTOALMACENToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1218, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eNTRADASToolStripMenuItem
            // 
            this.eNTRADASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gENERAROSAToolStripMenuItem1,
            this.vERTODASToolStripMenuItem1,
            this.pORPRODUCTOToolStripMenuItem});
            this.eNTRADASToolStripMenuItem.Name = "eNTRADASToolStripMenuItem";
            this.eNTRADASToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.eNTRADASToolStripMenuItem.Text = "ORDENES ENTRADA";
            this.eNTRADASToolStripMenuItem.Click += new System.EventHandler(this.eNTRADASToolStripMenuItem_Click);
            // 
            // gENERAROSAToolStripMenuItem1
            // 
            this.gENERAROSAToolStripMenuItem1.Name = "gENERAROSAToolStripMenuItem1";
            this.gENERAROSAToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.gENERAROSAToolStripMenuItem1.Text = "GENERAR OEN";
            this.gENERAROSAToolStripMenuItem1.Click += new System.EventHandler(this.gENERAROSAToolStripMenuItem1_Click);
            // 
            // vERTODASToolStripMenuItem1
            // 
            this.vERTODASToolStripMenuItem1.Name = "vERTODASToolStripMenuItem1";
            this.vERTODASToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.vERTODASToolStripMenuItem1.Text = "VER TODAS";
            this.vERTODASToolStripMenuItem1.Click += new System.EventHandler(this.vERTODASToolStripMenuItem1_Click);
            // 
            // pORPRODUCTOToolStripMenuItem
            // 
            this.pORPRODUCTOToolStripMenuItem.Name = "pORPRODUCTOToolStripMenuItem";
            this.pORPRODUCTOToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pORPRODUCTOToolStripMenuItem.Text = "POR PRODUCTO";
            // 
            // sALIDASToolStripMenuItem
            // 
            this.sALIDASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gENERAROSAToolStripMenuItem,
            this.vERTODASToolStripMenuItem,
            this.pORPRODUCTOToolStripMenuItem1,
            this.pROYECTOSToolStripMenuItem});
            this.sALIDASToolStripMenuItem.Name = "sALIDASToolStripMenuItem";
            this.sALIDASToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.sALIDASToolStripMenuItem.Text = "ORDENES SALIDA";
            this.sALIDASToolStripMenuItem.Click += new System.EventHandler(this.sALIDASToolStripMenuItem_Click);
            // 
            // gENERAROSAToolStripMenuItem
            // 
            this.gENERAROSAToolStripMenuItem.Name = "gENERAROSAToolStripMenuItem";
            this.gENERAROSAToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.gENERAROSAToolStripMenuItem.Text = "GENERAR OSA";
            this.gENERAROSAToolStripMenuItem.Click += new System.EventHandler(this.gENERAROSAToolStripMenuItem_Click);
            // 
            // vERTODASToolStripMenuItem
            // 
            this.vERTODASToolStripMenuItem.Name = "vERTODASToolStripMenuItem";
            this.vERTODASToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.vERTODASToolStripMenuItem.Text = "VER TODAS";
            this.vERTODASToolStripMenuItem.Click += new System.EventHandler(this.vERTODASToolStripMenuItem_Click);
            // 
            // pORPRODUCTOToolStripMenuItem1
            // 
            this.pORPRODUCTOToolStripMenuItem1.Name = "pORPRODUCTOToolStripMenuItem1";
            this.pORPRODUCTOToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.pORPRODUCTOToolStripMenuItem1.Text = "POR PRODUCTO";
            // 
            // pROYECTOSToolStripMenuItem
            // 
            this.pROYECTOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nUEVOToolStripMenuItem,
            this.vERTODOSToolStripMenuItem});
            this.pROYECTOSToolStripMenuItem.Name = "pROYECTOSToolStripMenuItem";
            this.pROYECTOSToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pROYECTOSToolStripMenuItem.Text = "PROYECTOS";
            this.pROYECTOSToolStripMenuItem.Click += new System.EventHandler(this.pROYECTOSToolStripMenuItem_Click);
            // 
            // nUEVOToolStripMenuItem
            // 
            this.nUEVOToolStripMenuItem.Name = "nUEVOToolStripMenuItem";
            this.nUEVOToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.nUEVOToolStripMenuItem.Text = "NUEVO";
            this.nUEVOToolStripMenuItem.Click += new System.EventHandler(this.nUEVOToolStripMenuItem_Click);
            // 
            // vERTODOSToolStripMenuItem
            // 
            this.vERTODOSToolStripMenuItem.Name = "vERTODOSToolStripMenuItem";
            this.vERTODOSToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.vERTODOSToolStripMenuItem.Text = "VER TODOS / EDITAR";
            this.vERTODOSToolStripMenuItem.Click += new System.EventHandler(this.vERTODOSToolStripMenuItem_Click);
            // 
            // rEPOSICIONESToolStripMenuItem
            // 
            this.rEPOSICIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gENERAROREPToolStripMenuItem,
            this.vEROREPSToolStripMenuItem,
            this.pORPRODUCTOToolStripMenuItem2});
            this.rEPOSICIONESToolStripMenuItem.Name = "rEPOSICIONESToolStripMenuItem";
            this.rEPOSICIONESToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.rEPOSICIONESToolStripMenuItem.Text = "ORDENES REPOSICION";
            // 
            // gENERAROREPToolStripMenuItem
            // 
            this.gENERAROREPToolStripMenuItem.Name = "gENERAROREPToolStripMenuItem";
            this.gENERAROREPToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.gENERAROREPToolStripMenuItem.Text = "GENERAR OREP";
            this.gENERAROREPToolStripMenuItem.Click += new System.EventHandler(this.gENERAROREPToolStripMenuItem_Click);
            // 
            // vEROREPSToolStripMenuItem
            // 
            this.vEROREPSToolStripMenuItem.Name = "vEROREPSToolStripMenuItem";
            this.vEROREPSToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.vEROREPSToolStripMenuItem.Text = "VER TODAS";
            this.vEROREPSToolStripMenuItem.Click += new System.EventHandler(this.vEROREPSToolStripMenuItem_Click);
            // 
            // pORPRODUCTOToolStripMenuItem2
            // 
            this.pORPRODUCTOToolStripMenuItem2.Name = "pORPRODUCTOToolStripMenuItem2";
            this.pORPRODUCTOToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.pORPRODUCTOToolStripMenuItem2.Text = "POR PRODUCTO";
            // 
            // aLTABAJAEDICIONToolStripMenuItem
            // 
            this.aLTABAJAEDICIONToolStripMenuItem.Name = "aLTABAJAEDICIONToolStripMenuItem";
            this.aLTABAJAEDICIONToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.aLTABAJAEDICIONToolStripMenuItem.Text = "ALTA DE PRODUCTOS";
            this.aLTABAJAEDICIONToolStripMenuItem.Click += new System.EventHandler(this.aLTABAJAEDICIONToolStripMenuItem_Click);
            // 
            // lISTAEXISTENCIASToolStripMenuItem
            // 
            this.lISTAEXISTENCIASToolStripMenuItem.Name = "lISTAEXISTENCIASToolStripMenuItem";
            this.lISTAEXISTENCIASToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.lISTAEXISTENCIASToolStripMenuItem.Text = "LISTA EXISTENCIAS";
            this.lISTAEXISTENCIASToolStripMenuItem.Click += new System.EventHandler(this.lISTAEXISTENCIASToolStripMenuItem_Click_1);
            // 
            // rESPALDOSToolStripMenuItem
            // 
            this.rESPALDOSToolStripMenuItem.Name = "rESPALDOSToolStripMenuItem";
            this.rESPALDOSToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.rESPALDOSToolStripMenuItem.Text = "RESPALDOS";
            this.rESPALDOSToolStripMenuItem.Click += new System.EventHandler(this.rESPALDOSToolStripMenuItem_Click);
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.rToolStripMenuItem.Text = "REPORTES";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // iNFLACIONToolStripMenuItem
            // 
            this.iNFLACIONToolStripMenuItem.Name = "iNFLACIONToolStripMenuItem";
            this.iNFLACIONToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.iNFLACIONToolStripMenuItem.Text = "INFLACION";
            this.iNFLACIONToolStripMenuItem.Click += new System.EventHandler(this.iNFLACIONToolStripMenuItem_Click);
            // 
            // cOSTOALMACENToolStripMenuItem
            // 
            this.cOSTOALMACENToolStripMenuItem.Name = "cOSTOALMACENToolStripMenuItem";
            this.cOSTOALMACENToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.cOSTOALMACENToolStripMenuItem.Text = "COSTO ALMACEN";
            this.cOSTOALMACENToolStripMenuItem.Click += new System.EventHandler(this.cOSTOALMACENToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "CATALOGO/CODIGO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(764, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "MARCA";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarca.Location = new System.Drawing.Point(846, 37);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(211, 29);
            this.textBoxMarca.TabIndex = 2;
            this.textBoxMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMarca_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(636, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "STOCK MUERTO";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 645);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCatalogo);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXISTENCIAS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox textBoxCatalogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eNTRADASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIDASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLTABAJAEDICIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPOSICIONESToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.ToolStripMenuItem gENERAROSAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vERTODASToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gENERAROSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vERTODASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gENERAROREPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vEROREPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pORPRODUCTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pORPRODUCTOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pORPRODUCTOToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lISTAEXISTENCIASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROYECTOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nUEVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vERTODOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESPALDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNFLACIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOSTOALMACENToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
