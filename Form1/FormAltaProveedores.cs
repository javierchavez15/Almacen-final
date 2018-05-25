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
    public partial class FormAltaProveedores : Form
    {
        public FormAltaProveedores()
        {
            InitializeComponent();
        }
        public proveedores proveedorSeleccionado;
        public proveedores Proveedor = new proveedores();   

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (txbRazonSocial.Text != "")
            {
                Proveedor.InsertarProveedor(this);
                Proveedor.Insert();
                if (Proveedor.Error != "")
                {
                    MessageBox.Show(Proveedor.Error);
                }     
                    MessageBox.Show("El proveedor " + Proveedor.NOMBRE + " se dio de ALTA Exitosamente");
                    Reset();                
                //FormProveedor fp = new FormProveedor();
                //fp.listBoxProveedores.DataSource = Proveedores.GetExisting();
            }
        }


        public void Reset()
        {
            txbRazonSocial.Text = "";
            txbMarcas.Text = "";
            txbDireccion.Text = "";
            txbCiudad.Text = "";
            txbEstado.Text = "";
            txbPais.Text = "";
            txbContacto.Text = "";
            txbTelefono.Text = "";
            txbCelular.Text = "";
            txbRadio.Text = "";
            txbEmail.Text = "";
            txbPaginaWeb.Text = "";
            cmbCategoria.Text = "";
            txbMontocredito.Text = "0";
            txbDiascredito.Text = "0";
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un Proveedor");
                return;
            }
            Warning Advertencia = new Warning();
            Advertencia.ShowDialog();
            if (Advertencia.DialogResult == DialogResult.OK)
            {
                Proveedor.EditarProveedor(this, proveedorSeleccionado.ID);
                Proveedor.Update("ID");
                if (Proveedor.Error != "")
                {
                    MessageBox.Show(Proveedor.Error);
                }
                else
                {
                    int indice = cmbListaProveedores.SelectedIndex;
                    MessageBox.Show("El proveedor " + Proveedor.NOMBRE + " se ACTUALIZO Exitosamente");
                    cmbListaProveedores.DataSource = proveedores.GetExisting();
                    cmbListaProveedores.SelectedIndex = indice;
                    proveedorSeleccionado = (proveedores)cmbListaProveedores.SelectedItem;
                    proveedores ProveedorM = new proveedores(proveedorSeleccionado, this);
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un Proveedor");
                return;
            }
            else
            {
                MessageBox.Show(proveedorSeleccionado.NOMBRE+", "+proveedorSeleccionado.ID);
            }

            Warning Advertencia = new Warning();
            Advertencia.label1.Text = "Este Proveedor sera BORRADO permanentemente" +
                                      "Desea continuar?";
            Advertencia.ShowDialog();
            if (Advertencia.DialogResult == DialogResult.OK)
            {
                proveedores ProveedorD = new proveedores(proveedorSeleccionado.ID);
                ProveedorD.Delete("ID = " + proveedorSeleccionado.ID + ";");
                if (Proveedor.Error != "")
                {
                    MessageBox.Show(Proveedor.Error);
                }
                else
                {
                    MessageBox.Show("El proveedor" + Proveedor.NOMBRE + " fue ELIMINADO Exitosamente");
                    cmbListaProveedores.DataSource = proveedores.GetExisting();
                    cmbListaProveedores.SelectedIndex = -1;
                    Reset();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbListaProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            proveedorSeleccionado = null;
            if (cmbListaProveedores.SelectedIndex != -1)
            {
                proveedorSeleccionado = (proveedores)cmbListaProveedores.SelectedItem;
                proveedores ProveedorM = new proveedores(proveedorSeleccionado, this);
            }
        }

    }
}
