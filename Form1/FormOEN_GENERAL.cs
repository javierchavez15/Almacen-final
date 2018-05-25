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
    public partial class FormOEN_GENERAL : Form
    {
        public FormOEN_GENERAL()
        {
            InitializeComponent();
        }

        oen_gral OENseleccionada;
        
        private void FormOEN_GENERAL_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            buttonBuscar.PerformClick();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;
            int idOEN = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            string nombreProveedor=dataGridView1.Rows[rowIndex].Cells["PROVEEDOR"].Value.ToString();
            OENseleccionada = new oen_gral(idOEN);
            FormOEN_INDIVIDUAL foenI = new FormOEN_INDIVIDUAL();
            foenI.oenSeleccionada = OENseleccionada;
            foenI.nombreProvedor = nombreProveedor;           
            this.Hide(); 
            foenI.ShowDialog();
            this.Show();
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
            int idOEN=0;
            if (textBoxBuscar.Text != "")
            {
                try
                {
                    idOEN = Convert.ToInt32(textBoxBuscar.Text);
                }
                catch
                {
                    MessageBox.Show("Escriba solo Números");
                    return;
                }
            }
            dataGridView1.DataSource = oen_gral.ListaOEN(idOEN);            
            dataGridView1.Columns[1].Width = 150;
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

        private void textBoxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBuscar.PerformClick();
            }
        }
    }
}
