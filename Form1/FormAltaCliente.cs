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
    public partial class FormAltaCliente : Form
    {
        public FormAltaCliente()
        {
            InitializeComponent();
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

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (txbRazonSocial.Text!="")
            {
                clientes c=new clientes();
                c.ID = c.NextID();
                c.RAZON_SOCIAL = txbRazonSocial.Text;
                c.Insert();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAltaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
