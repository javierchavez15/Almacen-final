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
    public partial class FormAjustarStock : Form
    {
        public FormAjustarStock()
        {
            InitializeComponent();
        }

        public productos ProductoEscogido;
        oen_gral oenG;
        oen_indiv oenI;
        osa_gral osaG;
        osa_indiv osaI;

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

        private void FormAjustarStock_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            labelProducto.Text += ProductoEscogido.CATALOGO;
            textBoxStockTeorico.Text = ProductoEscogido.STOCK.ToString();           
            dataGridView1.DataSource = productos.Entradas(ProductoEscogido.Id);
            dataGridView2.DataSource = productos.Salidas(ProductoEscogido.Id);

        }


        private void buttonSAVE_Click(object sender, EventArgs e)
        {
        }

        private void buttonActualizarStock_Click(object sender, EventArgs e)
        {
           
        }

        private void textBoxConteoFisico_TextChanged(object sender, EventArgs e)
        {
            int conteo;
            try
            {
                conteo = Convert.ToInt32(textBoxConteoFisico.Text);
            }
            catch
            {
                MessageBox.Show("ESCRIBA SOLO NUMEROS");
                textBoxConteoFisico.Text = "";
            }
        }

        private void textBoxAjuste_TextChanged(object sender, EventArgs e)
        {
            int conteo;
            try
            {
                conteo = Convert.ToInt32(textBoxAjuste.Text);
            }
            catch
            {
                MessageBox.Show("ESCRIBA SOLO NUMEROS");
                textBoxAjuste.Text = "";
            }
        }

       
    }
}
