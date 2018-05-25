using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using libData;

namespace Form1
{
    public partial class FormOREP_GENERAL : Form
    {
        public FormOREP_GENERAL()
        {
            InitializeComponent();
        }

        public orep_gral OREPseleccionada;

        private void FormOREP_GENERAL_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);          
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            buttonBuscar.PerformClick();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int idOREP = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            //   string nombreProveedor = dataGridView1.Rows[rowIndex].Cells["PROVEEDOR"].Value.ToString();

            OREPseleccionada = new orep_gral(idOREP);
 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int idOREP = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            //   string nombreProveedor = dataGridView1.Rows[rowIndex].Cells["PROVEEDOR"].Value.ToString();

            OREPseleccionada = new orep_gral(idOREP);

            FormOREP_INDIVIDUAL forepI = new FormOREP_INDIVIDUAL();
            forepI.orepSeleccionada = OREPseleccionada;
          //  forepI.nombreProvedor = nombreProveedor;


            this.Hide();
            forepI.ShowDialog();
            this.Show();

        }

        private void textBoxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBuscar.PerformClick();
            }
        }

        public bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.descoa.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            int status = 0;
            int idOREP = 0;
            if (textBoxBuscar.Text != "")
            {
                try
                {
                    idOREP = Convert.ToInt32(textBoxBuscar.Text);
                }
                catch
                {
                    MessageBox.Show("Escriba solo Números");
                    return;
                }
            }

            if (comboBoxsStatus.Text == "COMPRAS")
            {
                status = 1;
            }
            else if (comboBoxsStatus.Text == "TRANSITO")
            {
                status = 2;
            }
            else if (comboBoxsStatus.Text == "PARCIALES")
            {
                status = 3;
            }
            else if (comboBoxsStatus.Text == "COMPLETAS")
            {
                status = 4;
            }


            dataGridView1.DataSource = orep_gral.ListaOREP(idOREP,status);
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 200;
        }

        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
