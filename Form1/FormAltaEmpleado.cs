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
    public partial class FormAltaEmpleado : Form
    {
        public FormAltaEmpleado()
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
            if (textboxEmpleado.Text != "")
            {
                empleados c = new empleados();
                c.ID = c.NextID();
                c.NOMBRE = textboxEmpleado.Text;             
                c.Insert();
            }
        }
    }
}
