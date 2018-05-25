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
    public partial class FormCostos : Form
    {
        private int g_id;
        private string g_catalogo, g_costo;
        public FormCostos(int id, string catalogo, string costo)
        {
            InitializeComponent();
            g_id = id;
            g_catalogo = catalogo;
            g_costo = costo;
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

        private void FormCostos_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            DataTable union;
            txtcatalogo.Text = g_catalogo;
            txtcosto.Text = g_costo;
            union=cotizacionproveedor.listacostos(g_id);
            union.Merge(inventariocostos.listacostos(g_id));
            dataGridView1.DataSource = union;
            dataGridView1.Columns[0].Width = 60;//tipo
            dataGridView1.Columns[1].Width = 70;//fecha
            dataGridView1.Columns[2].Width = 55;//precio
            dataGridView1.Columns[3].Width = 56;//moneda
            dataGridView1.Columns[4].Width = 45;//tc
            //dataGridView1.Columns[5].Width = 150;//url1
            //dataGridView1.Columns[6].Width = 150;//url2
            //dataGridView1.Columns[7].Width = 150;//url3
            dataGridView1.Columns[8].Width = 80;//coti
            dataGridView1.Columns[9].Width = 70;//factura
            //dataGridView1.Columns[10].Width = 150;//prov
            //dataGridView1.Columns[11].Width = 100;//cont
            dataGridView1.Columns[12].Width = 80;//modifi
            //dataGridView1.Columns[3].Visible = false;
            dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
