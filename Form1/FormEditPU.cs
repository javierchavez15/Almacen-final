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
    public partial class FormEditPU : Form
    {
        public FormEditPU()
        {
            InitializeComponent();
        }

        public productos productoElegido;
        public cotizacionproveedor cotizacionElegida;
        double precioNew = 0;

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

        private void FormEditPU_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            labelPRODUCTO.Text = productoElegido.CATALOGO +" "+ productoElegido.DESCRIPCION;
            labelPrecioActual.Text = productoElegido.PrecioAlmacen.ToString();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sat.gob.mx/informacion_fiscal/tablas_indicadores/Paginas/tipo_cambio.aspx/");
        }

        private void buttonAdjuntar_Click(object sender, EventArgs e)
        {
             OpenFileDialog ofd = new OpenFileDialog();
          //  ofd.Filter = "PDF files (*.pdf, *.PDF) | *.pdf; *.PDF";
            string ruta = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(ofd.FileName);
                ruta = ofd.FileName;
                //  MessageBox.Show(ruta);
                try
                {
                   // SimpleFileCopy.Copiar("CotizaconId"+cotizacionElegida.Id+","+ofd.SafeFileName, ruta, @"cotizacionProveedor\");
                    SimpleFileCopy.Copiar(cotizacionElegida.Id+ext, ruta, @"cotizacionProveedor\");   
                }
                catch
                {
                    MessageBox.Show("El archivo no se reemplazo con exito, verifique que sea un PDF antes de reemplazarlo");
                }
            }
        }

        private void buttonCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            try
            {
                if (numeroCotizacion.Text == "" || moneda2.Text == "" || precioUnitario.Text == "0" || tipoCambio.Text == "0")
                {
                    MessageBox.Show("Favor de llenar todos los campos");
                    return;
                }
                double preciou = Convert.ToDouble(precioUnitario.Text);
                double tipocambio = Convert.ToDouble(tipoCambio.Text);
                if (moneda2.Text == "PMX")
                {
                    precioNew = Math.Round((preciou / tipocambio), 2);
                }
                else
                {
                    precioNew = preciou;
                }
                textBoxNuevoPrecio.Text = precioNew.ToString();
            }
            catch { MessageBox.Show("Escriba un precio correcto"); }
        }

        private void precioUnitario_TextChanged(object sender, EventArgs e)
        {
            double numero = 0;
            try
            {
                numero = Convert.ToDouble(precioUnitario.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese solo numeros");
                precioUnitario.Text = "0";
            }
        }

        private void tipoCambio_TextChanged(object sender, EventArgs e)
        {
            double numero = 0;
            try
            {
                numero = Convert.ToDouble(tipoCambio.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese solo numeros");
                tipoCambio.Text = "0";
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (textBoxNuevoPrecio.Text == "")
            {
                MessageBox.Show("Actualice la informacion");
                return;
            }            
            if (!cotizacionElegida.AsignarValores(this))
            {
                labelError.Visible = true;
                return;
            }           
            cotizacionElegida.idProducto = productoElegido.Id;
            cotizacionElegida.fecha = fecha2.Value;
            cotizacionElegida.tipoMoneda = moneda2.Text;
            labelError.Visible = false;
            cotizacionElegida.Insert();
            if (cotizacionElegida.Error != "")
            {
                MessageBox.Show(cotizacionElegida.Error);
                return;
            }
            productoElegido.PrecioAlmacen = precioNew;
            productoElegido.FECHA_FACTURA = fecha2.Value.Date;
            productoElegido.Update("Id");
        }        
    }
}
