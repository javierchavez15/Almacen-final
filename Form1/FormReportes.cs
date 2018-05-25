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
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }


        private void FormReportes_Load(object sender, EventArgs e)
        {
            dataGridSalidas.DataSource = reporteSalidas();
            dataGridEntradas.DataSource = reporteEntradas();
            dataGridProyectos.DataSource = reporteProyectos();

        }


        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            dataGridSalidas.DataSource = reporteSalidas();
            dataGridEntradas.DataSource = reporteEntradas();
        }

        private DataTable reporteSalidas()
        {
            String query = "SELECT og.Id as OSA, v.RAZON_SOCIAL as CLIENTE, og.FACTURA, og.TC, og.REMISION, og.PROYECTO_ID, p.CATALOGO, oi.QTY2, p.PrecioAlmacen, og.FECHA FROM  clientes v, productos p, osa_gral og, osa_indiv oi WHERE oi.QTY2 > 0 AND oi.ID_PRODUCTO2 = p.Id  AND oi.ID_OSAGRAL = og.Id AND og.ID_CLIENTE = v.ID ORDER BY og.Id ASC";

            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable reporteEntradas()
        {
            String query = "SELECT og.Id as OEN, v.NOMBRE as PROVEEDOR, oi.FACTURA_PROVEEDOR AS FACTURA, p.CATALOGO, oi.QTY, oi.PU, oi.MONEDA, oi.TC, og.FECHA FROM proveedores v, productos p, oen_gral og, oen_indiv oi WHERE oi.QTY > 0 AND oi.ID_PRODUCTO = p.Id  AND oi.ID_OENGRAL = og.Id AND og.ID_PROVEEDOR = v.ID ORDER BY og.Id ASC";

            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable reporteProyectos()
        {
            String query = "SELECT  y.ID, y.NOMBRE, og.Id as OSA, v.RAZON_SOCIAL as CLIENTE, p.CATALOGO, oi.QTY2, p.PrecioAlmacen, og.FECHA FROM proyectos y, clientes v, productos p, osa_gral og, osa_indiv oi WHERE oi.QTY2 > 0 AND oi.ID_PRODUCTO2 = p.Id  AND oi.ID_OSAGRAL = og.Id AND og.ID_CLIENTE = v.ID AND og.PROYECTO_ID = y.ID ORDER BY y.ID ASC";

            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }
    }
}
