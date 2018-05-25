namespace Form1
{
    partial class FormOSASxPROYECTO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1Cerrar = new System.Windows.Forms.Button();
            this.labelIdProyecto = new System.Windows.Forms.Label();
            this.labelGerente = new System.Windows.Forms.Label();
            this.labelNombreProyecto = new System.Windows.Forms.Label();
            this.labelNombreCliente = new System.Windows.Forms.Label();
            this.buttonCerrarProyecto = new System.Windows.Forms.Button();
            this.buttonReabrirProyecto = new System.Windows.Forms.Button();
            this.labelStatusProyecto = new System.Windows.Forms.Label();
            this.buttonIMPRIMIR = new System.Windows.Forms.Button();
            this.lblcosto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersWidth = 10;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1109, 559);
            this.dataGridView1.TabIndex = 24;
            // 
            // button1Cerrar
            // 
            this.button1Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Cerrar.Location = new System.Drawing.Point(15, 613);
            this.button1Cerrar.Name = "button1Cerrar";
            this.button1Cerrar.Size = new System.Drawing.Size(151, 30);
            this.button1Cerrar.TabIndex = 28;
            this.button1Cerrar.Text = "Cerrar Ventana";
            this.button1Cerrar.UseVisualStyleBackColor = true;
            // 
            // labelIdProyecto
            // 
            this.labelIdProyecto.AutoSize = true;
            this.labelIdProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdProyecto.Location = new System.Drawing.Point(11, 2);
            this.labelIdProyecto.Name = "labelIdProyecto";
            this.labelIdProyecto.Size = new System.Drawing.Size(96, 20);
            this.labelIdProyecto.TabIndex = 29;
            this.labelIdProyecto.Text = "ID_proyecto";
            // 
            // labelGerente
            // 
            this.labelGerente.AutoSize = true;
            this.labelGerente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGerente.Location = new System.Drawing.Point(11, 27);
            this.labelGerente.Name = "labelGerente";
            this.labelGerente.Size = new System.Drawing.Size(68, 20);
            this.labelGerente.TabIndex = 30;
            this.labelGerente.Text = "Gerente";
            // 
            // labelNombreProyecto
            // 
            this.labelNombreProyecto.AutoSize = true;
            this.labelNombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreProyecto.Location = new System.Drawing.Point(239, 1);
            this.labelNombreProyecto.Name = "labelNombreProyecto";
            this.labelNombreProyecto.Size = new System.Drawing.Size(127, 20);
            this.labelNombreProyecto.TabIndex = 31;
            this.labelNombreProyecto.Text = "NombreProyecto";
            // 
            // labelNombreCliente
            // 
            this.labelNombreCliente.AutoSize = true;
            this.labelNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreCliente.Location = new System.Drawing.Point(239, 27);
            this.labelNombreCliente.Name = "labelNombreCliente";
            this.labelNombreCliente.Size = new System.Drawing.Size(58, 20);
            this.labelNombreCliente.TabIndex = 32;
            this.labelNombreCliente.Text = "Cliente";
            // 
            // buttonCerrarProyecto
            // 
            this.buttonCerrarProyecto.BackColor = System.Drawing.Color.Red;
            this.buttonCerrarProyecto.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonCerrarProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrarProyecto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCerrarProyecto.Location = new System.Drawing.Point(975, 1);
            this.buttonCerrarProyecto.Name = "buttonCerrarProyecto";
            this.buttonCerrarProyecto.Size = new System.Drawing.Size(148, 23);
            this.buttonCerrarProyecto.TabIndex = 33;
            this.buttonCerrarProyecto.Text = "CERRAR PROYECTO";
            this.buttonCerrarProyecto.UseVisualStyleBackColor = false;
            this.buttonCerrarProyecto.Click += new System.EventHandler(this.buttonCerrarProyecto_Click);
            // 
            // buttonReabrirProyecto
            // 
            this.buttonReabrirProyecto.BackColor = System.Drawing.Color.Lime;
            this.buttonReabrirProyecto.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonReabrirProyecto.Location = new System.Drawing.Point(975, 25);
            this.buttonReabrirProyecto.Name = "buttonReabrirProyecto";
            this.buttonReabrirProyecto.Size = new System.Drawing.Size(148, 23);
            this.buttonReabrirProyecto.TabIndex = 34;
            this.buttonReabrirProyecto.Text = "REABRIR PROYECTO";
            this.buttonReabrirProyecto.UseVisualStyleBackColor = false;
            // 
            // labelStatusProyecto
            // 
            this.labelStatusProyecto.AutoSize = true;
            this.labelStatusProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusProyecto.Location = new System.Drawing.Point(704, 26);
            this.labelStatusProyecto.Name = "labelStatusProyecto";
            this.labelStatusProyecto.Size = new System.Drawing.Size(87, 20);
            this.labelStatusProyecto.TabIndex = 35;
            this.labelStatusProyecto.Text = "ESTATUS:";
            // 
            // buttonIMPRIMIR
            // 
            this.buttonIMPRIMIR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonIMPRIMIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonIMPRIMIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIMPRIMIR.Location = new System.Drawing.Point(768, 613);
            this.buttonIMPRIMIR.Name = "buttonIMPRIMIR";
            this.buttonIMPRIMIR.Size = new System.Drawing.Size(129, 30);
            this.buttonIMPRIMIR.TabIndex = 36;
            this.buttonIMPRIMIR.Text = "IMRPIMIR PDF";
            this.buttonIMPRIMIR.UseVisualStyleBackColor = false;
            this.buttonIMPRIMIR.Click += new System.EventHandler(this.buttonIMPRIMIR_Click);
            // 
            // lblcosto
            // 
            this.lblcosto.AutoSize = true;
            this.lblcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcosto.Location = new System.Drawing.Point(704, 1);
            this.lblcosto.Name = "lblcosto";
            this.lblcosto.Size = new System.Drawing.Size(163, 20);
            this.lblcosto.TabIndex = 37;
            this.lblcosto.Text = "COSTO EN DOLLAR:";
            // 
            // FormOSASxPROYECTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 647);
            this.Controls.Add(this.lblcosto);
            this.Controls.Add(this.buttonIMPRIMIR);
            this.Controls.Add(this.labelStatusProyecto);
            this.Controls.Add(this.buttonReabrirProyecto);
            this.Controls.Add(this.buttonCerrarProyecto);
            this.Controls.Add(this.labelNombreCliente);
            this.Controls.Add(this.labelNombreProyecto);
            this.Controls.Add(this.labelGerente);
            this.Controls.Add(this.labelIdProyecto);
            this.Controls.Add(this.button1Cerrar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormOSASxPROYECTO";
            this.Text = "FormOSASxPROYECTO";
            this.Load += new System.EventHandler(this.FormOSASxPROYECTO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1Cerrar;
        public System.Windows.Forms.Label labelIdProyecto;
        public System.Windows.Forms.Label labelGerente;
        public System.Windows.Forms.Label labelNombreProyecto;
        public System.Windows.Forms.Label labelNombreCliente;
        public System.Windows.Forms.Button buttonCerrarProyecto;
        public System.Windows.Forms.Button buttonReabrirProyecto;
        public System.Windows.Forms.Label labelStatusProyecto;
        private System.Windows.Forms.Button buttonIMPRIMIR;
        public System.Windows.Forms.Label lblcosto;
    }
}