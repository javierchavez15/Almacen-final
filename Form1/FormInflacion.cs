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
    public partial class FormInflacion : Form
    {
        public FormInflacion()
        {
            InitializeComponent();
        }

        private string cambio = "";

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

        private void FormInflacion_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            DbObject db = new DbObject();
            cambio =db.datoinfla();
            if (cambio == "1")
            {
                cmbmarca.DataSource = productos.listamarcas();
                cmbmarca.SelectedIndex = -1;
            }
            else
            {
                cmbmarca.Visible = false;
                label4.Text = "Actualizar precios para todos los productos en stock";
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            double i = 0;
            string s = textBox1.Text;
            bool result = double.TryParse(s, out i); //i now = 108  
            if (result == false)
            {
                MessageBox.Show("Ingrese un porcentaje valido");
                return;
            }
            string status = "Se le aumentara el precio a los productos ¿Desea continuar?";
            string leyenda = "Aumentar precio";
            DialogResult resultado = MessageBox.Show(status, leyenda, MessageBoxButtons.YesNo);
            if (resultado == DialogResult.No)
            {
                return;
            }
            if (Convert.ToDouble(textBox1.Text) > 0)
            {

                double inflacion = 1 + (Convert.ToDouble(textBox1.Text) / 100);
                DbObject prod = new DbObject();
                int año = DateTime.Now.Year;
                año--;
                string fecha = año.ToString() + "-03-01";
                if (cambio == "1")
                {
                    if (cmbmarca.SelectedIndex != -1)
                        prod.actualizarprecio("precioAlmacen", inflacion.ToString(), "MARCA='" + cmbmarca.SelectedItem + "' and STOCK>0 and FECHA_FACTURA>'" + fecha + "' and FECHA_FACTURA<'" + DateTime.Now.Year.ToString() + "06-01'");
                    else
                        return;
                }
                else
                {
                    prod.actualizarprecio("precioAlmacen", inflacion.ToString(), "STOCK>0 and FECHA_FACTURA BETWEEN'" + fecha + "' and  '" + DateTime.Now.Year.ToString() + "-06-01'");
                    prod.actualizarinflacion("Update inflacion SET fecha=CURDATE(), cambio='1' WHERE Id=1");
                }
                this.Close();
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
