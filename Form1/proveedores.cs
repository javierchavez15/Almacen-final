using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class proveedores : hmiObject
    {
        
        public proveedores()
        {

        }

        public proveedores(proveedores proveedorSeleccionado, FormAltaProveedores Alta)
        {
            Alta.txbRazonSocial.Text = proveedorSeleccionado.NOMBRE;
            Alta.txbMarcas.Text = proveedorSeleccionado.MARCAS;
            Alta.txbDireccion.Text = proveedorSeleccionado.DIRECCION;
            Alta.txbCiudad.Text = proveedorSeleccionado.CIUDAD;
            Alta.txbEstado.Text = proveedorSeleccionado.ESTADO;
            Alta.txbPais.Text = proveedorSeleccionado.PAIS;
            Alta.txbContacto.Text = proveedorSeleccionado.CONTACTO;
            Alta.txbTelefono.Text = proveedorSeleccionado.TELEFONO;
            Alta.txbCelular.Text = proveedorSeleccionado.CELULAR;
            Alta.txbRadio.Text = proveedorSeleccionado.RADIO;
            Alta.txbEmail.Text = proveedorSeleccionado.EMAIL;
            Alta.txbPaginaWeb.Text = proveedorSeleccionado.PAGINAWEB;
            Alta.cmbCategoria.Text = proveedorSeleccionado.CATEGORIA;
            Alta.txbMontocredito.Text = proveedorSeleccionado.MONTOCREDITO.ToString();
            Alta.txbDiascredito.Text = proveedorSeleccionado.DIASCREDITO.ToString();
        }


        public proveedores(int id)
        {
            this.LoadMembers("ID=" + id);
        }


        public proveedores(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int ID;
        public string NOMBRE = "";
        public string MARCAS = "";
        public string DIRECCION = "";
        public string CIUDAD = "";
        public string ESTADO = "";
        public string PAIS = "";
        public string CONTACTO = "";
        public string TELEFONO = "";
        public string CELULAR = "";
        public string RADIO = "";
        public string EMAIL = "";
        public string PAGINAWEB = "";
        public string CATEGORIA = "";
        public int MONTOCREDITO = 0;
        public int DIASCREDITO = 0;
        public int ID_CONTACTO = 0;


        public void InsertarProveedor(FormAltaProveedores PROVEEDOR)
        {
            ID = base.NextID();
            NOMBRE = PROVEEDOR.txbRazonSocial.Text;
            MARCAS = PROVEEDOR.txbMarcas.Text;
            DIRECCION = PROVEEDOR.txbDireccion.Text;
            CIUDAD = PROVEEDOR.txbCiudad.Text;
            ESTADO = PROVEEDOR.txbEstado.Text;
            PAIS = PROVEEDOR.txbPais.Text;
            CONTACTO = PROVEEDOR.txbContacto.Text;
            TELEFONO = PROVEEDOR.txbTelefono.Text;
            CELULAR = PROVEEDOR.txbCelular.Text;
            RADIO = PROVEEDOR.txbRadio.Text;
            EMAIL = PROVEEDOR.txbEmail.Text;
            PAGINAWEB = PROVEEDOR.txbPaginaWeb.Text;
            CATEGORIA = PROVEEDOR.cmbCategoria.Text;
            MONTOCREDITO = int.Parse(PROVEEDOR.txbMontocredito.Text);
            DIASCREDITO = int.Parse(PROVEEDOR.txbDiascredito.Text);

        }

        public void EditarProveedor(FormAltaProveedores PROVEEDOR, int id)
        {
            ID = id;
            NOMBRE = PROVEEDOR.txbRazonSocial.Text;
            MARCAS = PROVEEDOR.txbMarcas.Text;
            DIRECCION = PROVEEDOR.txbDireccion.Text;
            CIUDAD = PROVEEDOR.txbCiudad.Text;
            ESTADO = PROVEEDOR.txbEstado.Text;
            PAIS = PROVEEDOR.txbPais.Text;
            CONTACTO = PROVEEDOR.txbContacto.Text;
            TELEFONO = PROVEEDOR.txbTelefono.Text;
            CELULAR = PROVEEDOR.txbCelular.Text;
            RADIO = PROVEEDOR.txbRadio.Text;
            EMAIL = PROVEEDOR.txbEmail.Text;
            PAGINAWEB = PROVEEDOR.txbPaginaWeb.Text;
            CATEGORIA = PROVEEDOR.cmbCategoria.Text;
            MONTOCREDITO = int.Parse(PROVEEDOR.txbMontocredito.Text);
            DIASCREDITO = int.Parse(PROVEEDOR.txbDiascredito.Text);
        }

        public override string ToString()
        {
            return NOMBRE;
        }


        public static List<proveedores> GetExisting()
        {

            List<proveedores> existing = new List<proveedores>();

            string query = "SELECT * FROM proveedores where ID>0 and NOMBRE<>'' and NOMBRE<>' ' ORDER BY Nombre ASC";

           

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    existing.Add(new proveedores(dr));
                }
            }


            return existing;

        }

    }
}
