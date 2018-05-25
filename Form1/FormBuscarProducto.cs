using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class FormBuscarProducto : Form
    {
        public FormBuscarProducto()
        {
            InitializeComponent();
        }

        public productos ProductoSelecto;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void VisualizarDGV1()
        {
            textBoxCatalogo.Text = textBoxCatalogo.Text.Replace("'", "`");//quita comila
            textBoxMarca.Text = textBoxMarca.Text.Replace("'", "`");//quita comila
            dataGridView1.DataSource = productos.ListaProductos(textBoxCatalogo.Text, textBoxMarca.Text,false);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].Width = 470;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[9].DisplayIndex = 0;
            dataGridView1.Columns[10].Width = 70;
            dataGridView1.Columns[11].Width = 70;
            dataGridView1.Columns[12].Width = 70;
            dataGridView1.Columns[13].Width = 100;  
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            VisualizarDGV1();
        }

        private void FormBuscarProducto_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellDoubleClick+=new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;
            int idPcto = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            ProductoSelecto = new productos(idPcto);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;
            int idPcto = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            ProductoSelecto = new productos(idPcto);
            buttonCopiarProducto.PerformClick();
        }

        private void textBoxCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBuscar.PerformClick();
            }
        }

        private void textBoxMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBuscar.PerformClick();
            }
        }

        private void buttonCopiarProducto_Click(object sender, EventArgs e)
        {

        }
    }
}
