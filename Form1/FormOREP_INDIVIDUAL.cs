using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form1
{
    public partial class FormOREP_INDIVIDUAL : Form
    {
        public FormOREP_INDIVIDUAL()
        {
            InitializeComponent();
        }

        public orep_gral orepSeleccionada;

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

        private void FormOREP_INDIVIDUAL_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (orepSeleccionada == null)
            {
                orepSeleccionada = new orep_gral();
            }

            textBoxFecha.Text = orepSeleccionada.Fecha.ToString("dd/MMMM/yyyy");
            textBoxOrep.Text = orepSeleccionada.Id.ToString();
           

            VerDGV(orepSeleccionada.Id);
        }


        private void VerDGV(int orepG)
        {
            dataGridView1.DataSource = orep_indiv.PartidasOREP(orepG);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 550;



        }


        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int w = 0;
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (w == 0)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = true;
              //  dataGridView1.Columns[1].ReadOnly = true;
              //  dataGridView1.Columns[2].ReadOnly = true;
             //   dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                buttonEditar.BackColor = Color.Yellow;
                buttonEditar.Text = "Actualizar";

                w++;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                buttonEditar.BackColor = Color.LightGray;
                buttonEditar.Text = "Editar";

                w = 0;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
