namespace Form1
{
    partial class FormPROYECTOS
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
            this.buttonBUSQUEDA = new System.Windows.Forms.Button();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButtonDESCRIPCION = new System.Windows.Forms.RadioButton();
            this.radioButtonID = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonCerrado = new System.Windows.Forms.RadioButton();
            this.radioButtonABIERTO = new System.Windows.Forms.RadioButton();
            this.buttonCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBUSQUEDA
            // 
            this.buttonBUSQUEDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBUSQUEDA.Location = new System.Drawing.Point(847, 26);
            this.buttonBUSQUEDA.Name = "buttonBUSQUEDA";
            this.buttonBUSQUEDA.Size = new System.Drawing.Size(112, 31);
            this.buttonBUSQUEDA.TabIndex = 2;
            this.buttonBUSQUEDA.Text = "BUSCAR";
            this.buttonBUSQUEDA.UseVisualStyleBackColor = true;
            this.buttonBUSQUEDA.Click += new System.EventHandler(this.buttonBUSQUEDA_Click);
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBusqueda.Location = new System.Drawing.Point(350, 28);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(491, 26);
            this.textBoxBusqueda.TabIndex = 3;
            this.textBoxBusqueda.TextChanged += new System.EventHandler(this.textBoxBusqueda_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1383, 492);
            this.dataGridView1.TabIndex = 4;
            // 
            // radioButtonDESCRIPCION
            // 
            this.radioButtonDESCRIPCION.AutoSize = true;
            this.radioButtonDESCRIPCION.Checked = true;
            this.radioButtonDESCRIPCION.Location = new System.Drawing.Point(6, 32);
            this.radioButtonDESCRIPCION.Name = "radioButtonDESCRIPCION";
            this.radioButtonDESCRIPCION.Size = new System.Drawing.Size(117, 17);
            this.radioButtonDESCRIPCION.TabIndex = 5;
            this.radioButtonDESCRIPCION.TabStop = true;
            this.radioButtonDESCRIPCION.Text = "Por DESCRIPCION";
            this.radioButtonDESCRIPCION.UseVisualStyleBackColor = true;
            // 
            // radioButtonID
            // 
            this.radioButtonID.AutoSize = true;
            this.radioButtonID.Location = new System.Drawing.Point(6, 9);
            this.radioButtonID.Name = "radioButtonID";
            this.radioButtonID.Size = new System.Drawing.Size(54, 17);
            this.radioButtonID.TabIndex = 6;
            this.radioButtonID.Text = "por ID";
            this.radioButtonID.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonID);
            this.groupBox1.Controls.Add(this.radioButtonDESCRIPCION);
            this.groupBox1.Location = new System.Drawing.Point(965, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonCerrado);
            this.groupBox2.Controls.Add(this.radioButtonABIERTO);
            this.groupBox2.Location = new System.Drawing.Point(1121, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // radioButtonCerrado
            // 
            this.radioButtonCerrado.AutoSize = true;
            this.radioButtonCerrado.Location = new System.Drawing.Point(6, 9);
            this.radioButtonCerrado.Name = "radioButtonCerrado";
            this.radioButtonCerrado.Size = new System.Drawing.Size(78, 17);
            this.radioButtonCerrado.TabIndex = 6;
            this.radioButtonCerrado.Text = "CERRADO";
            this.radioButtonCerrado.UseVisualStyleBackColor = true;
            // 
            // radioButtonABIERTO
            // 
            this.radioButtonABIERTO.AutoSize = true;
            this.radioButtonABIERTO.Checked = true;
            this.radioButtonABIERTO.Location = new System.Drawing.Point(6, 32);
            this.radioButtonABIERTO.Name = "radioButtonABIERTO";
            this.radioButtonABIERTO.Size = new System.Drawing.Size(72, 17);
            this.radioButtonABIERTO.TabIndex = 5;
            this.radioButtonABIERTO.TabStop = true;
            this.radioButtonABIERTO.Text = "ABIERTO";
            this.radioButtonABIERTO.UseVisualStyleBackColor = true;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Location = new System.Drawing.Point(678, 567);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(112, 31);
            this.buttonCerrar.TabIndex = 9;
            this.buttonCerrar.Text = "CERRAR VENTANA";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            // 
            // FormPROYECTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 610);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.buttonBUSQUEDA);
            this.Name = "FormPROYECTOS";
            this.Text = "FormPROYECTOS";
            this.Load += new System.EventHandler(this.FormPROYECTOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBUSQUEDA;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButtonDESCRIPCION;
        private System.Windows.Forms.RadioButton radioButtonID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonCerrado;
        private System.Windows.Forms.RadioButton radioButtonABIERTO;
        private System.Windows.Forms.Button buttonCerrar;
    }
}