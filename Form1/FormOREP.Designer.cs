namespace Form1
{
    partial class FormOREP
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonDerecha1 = new System.Windows.Forms.Button();
            this.buttonDerechaTodos = new System.Windows.Forms.Button();
            this.buttonIzquierdaTodos = new System.Windows.Forms.Button();
            this.buttonIzquierda1 = new System.Windows.Forms.Button();
            this.button1Cerrar = new System.Windows.Forms.Button();
            this.buttonImprimirLista = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonImprimirOREP = new System.Windows.Forms.Button();
            this.textBoxIdOREP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(603, 481);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(612, 87);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 5;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(603, 481);
            this.dataGridView2.TabIndex = 1;
            // 
            // buttonDerecha1
            // 
            this.buttonDerecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDerecha1.Location = new System.Drawing.Point(538, 571);
            this.buttonDerecha1.Name = "buttonDerecha1";
            this.buttonDerecha1.Size = new System.Drawing.Size(45, 45);
            this.buttonDerecha1.TabIndex = 2;
            this.buttonDerecha1.Text = ">";
            this.buttonDerecha1.UseVisualStyleBackColor = true;
            this.buttonDerecha1.Visible = false;
            this.buttonDerecha1.Click += new System.EventHandler(this.buttonDerecha1_Click);
            // 
            // buttonDerechaTodos
            // 
            this.buttonDerechaTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDerechaTodos.Location = new System.Drawing.Point(426, 571);
            this.buttonDerechaTodos.Name = "buttonDerechaTodos";
            this.buttonDerechaTodos.Size = new System.Drawing.Size(72, 45);
            this.buttonDerechaTodos.TabIndex = 3;
            this.buttonDerechaTodos.Text = ">>";
            this.buttonDerechaTodos.UseVisualStyleBackColor = true;
            this.buttonDerechaTodos.Click += new System.EventHandler(this.buttonDerechaTodos_Click);
            // 
            // buttonIzquierdaTodos
            // 
            this.buttonIzquierdaTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzquierdaTodos.Location = new System.Drawing.Point(736, 571);
            this.buttonIzquierdaTodos.Name = "buttonIzquierdaTodos";
            this.buttonIzquierdaTodos.Size = new System.Drawing.Size(72, 45);
            this.buttonIzquierdaTodos.TabIndex = 5;
            this.buttonIzquierdaTodos.Text = "<<";
            this.buttonIzquierdaTodos.UseVisualStyleBackColor = true;
            this.buttonIzquierdaTodos.Click += new System.EventHandler(this.buttonIzquierdaTodos_Click);
            // 
            // buttonIzquierda1
            // 
            this.buttonIzquierda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzquierda1.Location = new System.Drawing.Point(639, 571);
            this.buttonIzquierda1.Name = "buttonIzquierda1";
            this.buttonIzquierda1.Size = new System.Drawing.Size(45, 45);
            this.buttonIzquierda1.TabIndex = 4;
            this.buttonIzquierda1.Text = "<";
            this.buttonIzquierda1.UseVisualStyleBackColor = true;
            this.buttonIzquierda1.Visible = false;
            // 
            // button1Cerrar
            // 
            this.button1Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Cerrar.Location = new System.Drawing.Point(10, 604);
            this.button1Cerrar.Name = "button1Cerrar";
            this.button1Cerrar.Size = new System.Drawing.Size(151, 30);
            this.button1Cerrar.TabIndex = 6;
            this.button1Cerrar.Text = "Cerrar Ventana";
            this.button1Cerrar.UseVisualStyleBackColor = true;
            this.button1Cerrar.Click += new System.EventHandler(this.button1Cerrar_Click);
            // 
            // buttonImprimirLista
            // 
            this.buttonImprimirLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimirLista.Location = new System.Drawing.Point(401, 46);
            this.buttonImprimirLista.Name = "buttonImprimirLista";
            this.buttonImprimirLista.Size = new System.Drawing.Size(157, 35);
            this.buttonImprimirLista.TabIndex = 7;
            this.buttonImprimirLista.Text = "Imprimir Lista";
            this.buttonImprimirLista.UseVisualStyleBackColor = true;
            this.buttonImprimirLista.Visible = false;
            this.buttonImprimirLista.Click += new System.EventHandler(this.buttonImprimirLista_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "INVENTARIO PARA REPOSICION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(707, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "ORDEN DE REPOSICION";
            // 
            // buttonImprimirOREP
            // 
            this.buttonImprimirOREP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimirOREP.Location = new System.Drawing.Point(1054, 47);
            this.buttonImprimirOREP.Name = "buttonImprimirOREP";
            this.buttonImprimirOREP.Size = new System.Drawing.Size(141, 35);
            this.buttonImprimirOREP.TabIndex = 10;
            this.buttonImprimirOREP.Text = "Imprimir Orden";
            this.buttonImprimirOREP.UseVisualStyleBackColor = true;
            this.buttonImprimirOREP.Click += new System.EventHandler(this.buttonImprimirOREP_Click);
            // 
            // textBoxIdOREP
            // 
            this.textBoxIdOREP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdOREP.Location = new System.Drawing.Point(1087, 6);
            this.textBoxIdOREP.Name = "textBoxIdOREP";
            this.textBoxIdOREP.ReadOnly = true;
            this.textBoxIdOREP.Size = new System.Drawing.Size(108, 29);
            this.textBoxIdOREP.TabIndex = 11;
            this.textBoxIdOREP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1003, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "OREP #";
            // 
            // FormOREP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 642);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIdOREP);
            this.Controls.Add(this.buttonImprimirOREP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonImprimirLista);
            this.Controls.Add(this.button1Cerrar);
            this.Controls.Add(this.buttonIzquierdaTodos);
            this.Controls.Add(this.buttonIzquierda1);
            this.Controls.Add(this.buttonDerechaTodos);
            this.Controls.Add(this.buttonDerecha1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormOREP";
            this.Text = "GENERAR OREP";
            this.Load += new System.EventHandler(this.FormOREP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button buttonDerecha1;
        private System.Windows.Forms.Button buttonDerechaTodos;
        private System.Windows.Forms.Button buttonIzquierdaTodos;
        private System.Windows.Forms.Button buttonIzquierda1;
        private System.Windows.Forms.Button button1Cerrar;
        private System.Windows.Forms.Button buttonImprimirLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonImprimirOREP;
        private System.Windows.Forms.TextBox textBoxIdOREP;
        private System.Windows.Forms.Label label3;
    }
}