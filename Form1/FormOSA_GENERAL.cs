using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class FormOSA_GENERAL : Form
    {
        public FormOSA_GENERAL()
        {
            InitializeComponent();
        }

        osa_gral OSAseleccionada;
        public List<clientes> lista;
        public string tc = "";

        private void FormOSA_GENERAL_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            buttonBuscar.PerformClick();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int idOSA = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            string nombreCliente = dataGridView1.Rows[rowIndex].Cells["RAZON_SOCIAL"].Value.ToString();
            string nombreVendedor = dataGridView1.Rows[rowIndex].Cells["VENDEDOR"].Value.ToString();

            OSAseleccionada = new osa_gral(idOSA);

            FormOSA_INDIVIDUAL fosaI = new FormOSA_INDIVIDUAL();
            fosaI.osaSeleccionada = OSAseleccionada;
            fosaI.lista = lista;
            fosaI.tc = tc;
            fosaI.nombreCliente = nombreCliente;
            fosaI.nombreVendedor = nombreVendedor;


            this.Hide();
            fosaI.ShowDialog();
            if(fosaI.DialogResult==DialogResult.OK)
                buttonBuscar.PerformClick();
            this.Show();


        }

        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            int idOSA = 0;
            if (textBoxBuscar.Text != "")
            {
                try
                {
                    idOSA = Convert.ToInt32(textBoxBuscar.Text);
                }
                catch
                {
                    MessageBox.Show("Escriba solo Números");
                    return;
                }
            }
            dataGridView1.DataSource = osa_gral.ListaOSA(idOSA);
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[2].Width = 400;
            filtrar_factura();
        }

        private void textBoxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBuscar.PerformClick();
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void filtrar_factura()
        {

            dataGridView1.CurrentCell = null;
            bool ok;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (textBox1.Text != "")
                {
                    if (fila.Cells[4].Value != null)
                    {
                        ok = fila.Cells[4].Value.ToString().ToUpper().Contains(textBox1.Text.ToUpper());
                        if (ok == true)
                            fila.Visible = true;
                        else
                            fila.Visible = false;
                    }
                    // else
                    //   fila.Visible = false;
                }
                else
                    fila.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar_factura();
        }
    }
}
