using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using libData;
using System.Management;
using MySql.Data.MySqlClient;
using Form1.mx.org.banxico.www;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;


namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataBase bdMysql;
         DataBase bdAccess;
         DataBase bd;
         productos productoPrueba;
         productos productoSeleccionado;
        List<clientes> lista;
        public string tc = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();

            sb.Server = "secure199.inmotionhosting.com";
            sb.UserID = "abdsto5_felipe";
            sb.Password = "1945Inadescobi";
            sb.Database = "abdsto5_cotizaciones";


            //PRUEBAS EN LOCALHOST
            /*
            sb.Server = "localhost";
            sb.UserID = "felipe";
            sb.Password = "1945Inadescobi";
            sb.Database = "ejemplo";
            */
            bdMysql = new DataBase();
            bdMysql.DataBaseProvider = TypeOfDataBase.MySqlServer;
            bdMysql.ConnectionString = sb.ToString();
            //   bdMysql.ConnectionString = "Server = localhost; Database = descobi; Uid = felipe; Pwd = 1945Inadescobi";
            bdMysql.CreateConnection();
            DbObject.DefaultDataBaseObject = bdMysql;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            /*
            String mac = "00:12:3F:43:98:52";
            String mac2 = "";
            String tarjeta = "Controladora Gigabit Broadcom NetXtreme 57xx";            
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Name='" + tarjeta + "'");
            ManagementObjectCollection moc = mos.Get();
            if (moc.Count > 0)
            {
                foreach (ManagementObject mo in moc)
                {
                    mac2 = (string)mo["MACAddress"];
                    // MessageBox.Show(mac);
                }
            }
            else
            {
                MessageBox.Show("Esta Aplicacion no coincide con el equipo, Favor de actualizarla");
                this.Close();
            }

            if (mac != mac2)
            {
                MessageBox.Show("Esta Aplicacion no coincide con el equipo, Favor de actualizarla");
                this.Close();
            }
            */
            DbObject db = new DbObject();
            string cambio = db.añoinflacion();
            if (cambio != DateTime.Now.Year.ToString())
            {
                bdMysql.editarinflacion("Update inflacion SET fecha=CURDATE(), cambio='0' WHERE Id=1");
            }

            lista = clientes.GetExistentes();

            DgieWS TCambio = new DgieWS();
            string strTDCambio = TCambio.tiposDeCambioBanxico();
            XElement root = XElement.Parse(@strTDCambio);
            XNamespace bm = "http://www.banxico.org.mx/structure/key_families/dgie/sie/series/compact";
            IEnumerable<XElement> address =
            from el in root.Descendants(bm + "DataSet").Elements(bm + "Series")
            where (string)el.Attribute("IDSERIE") == "SF43718"
            select el;
            foreach (XElement el in address)
            {
                tc = "" + el.Element(bm + "Obs").Attribute("OBS_VALUE").Value;
            }
            try
            {
                Convert.ToDouble(tc);

            }
            catch { tc = "0"; }
        }

        private void aLTABAJAEDICIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaProductos AP = new FormAltaProductos();          
            this.Hide();
            AP.ShowDialog();
            this.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {   

            FormAltaProductos fe = new FormAltaProductos();
           
            fe.ShowDialog();

            if (fe.DialogResult == DialogResult.OK)
            {
                productoPrueba = fe.productoSeleccionado;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaProductos fe = new FormAltaProductos();
            fe.productoSeleccionado = productoPrueba;
            fe.ShowDialog();

        }
        /*
        private DataRow ReconocerCodigo()
        {
            
           string codigo=textBoxCatalogo.Text;
           string query = "SELECT * FROM PRODUCTOS WHERE CODIGODEBARRAS='" + codigo+"'";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
           

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0];
            }

            return null;
            
        }
        */
        private void VisualizarDGV()
        {
            try
            {
                dataGridView1.DataSource = productos.ListaProductos(textBoxCatalogo.Text, textBoxMarca.Text, checkBox1.Checked);
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells[20].Value != null)
                    {
                        if (fila.Cells[20].Value.ToString() == "")
                            fila.Cells[9].Style.BackColor = System.Drawing.Color.Gold;
                        if (fila.Cells[21].Value.ToString() == "")
                            fila.Cells[9].Style.BackColor = System.Drawing.Color.DarkRed;
                    }
                }
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[2].Width = 470;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Width = 60;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[9].DisplayIndex = 0;
                dataGridView1.Columns[10].Width = 70;
                dataGridView1.Columns[10].DisplayIndex = 18;
                dataGridView1.Columns[11].Width = 70;
                dataGridView1.Columns[12].Width = 70;
                dataGridView1.Columns[13].Width = 70;
                dataGridView1.Columns[18].Width = 50;
                dataGridView1.Columns[18].DisplayIndex = 10;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }
            catch
            {
                MessageBox.Show("0 Resultados. Modifique su búsqueda");
            }
        }

        private void AbrirFormProducto(int idPcto, bool oferta)
        {
            productoSeleccionado = new productos(idPcto);

            FormProductoSpec fps = new FormProductoSpec();
            fps.productoSeleccionadoi = productoSeleccionado;
            if (oferta == true)
                fps.productoSeleccionadoi.STOCKMUERTO = 1;
            fps.ShowDialog();

            if (fps.DialogResult == DialogResult.OK)
            {
              //  textBoxCatalogo.Text = "";
                textBoxCatalogo.Focus();
             //   dataGridView1.DataSource = null;
             //   VisualizarDGV();
            }
 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;         
            int rowIndex = e.RowIndex;
            //MessageBox.Show(dataGridView1.Rows[rowIndex].Cells[22].Value.ToString());
            int idPcto = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            AbrirFormProducto(idPcto, (bool)dataGridView1.Rows[rowIndex].Cells[22].Value);
            if (productoSeleccionado.STOCKMUERTO == 1)
                dataGridView1.Rows[rowIndex].Cells[22].Value = true;
            else
                dataGridView1.Rows[rowIndex].Cells[22].Value = false;
            /*
            productoSeleccionado = new PRODUCTOS(idPcto);

            FormProductoSpec fps = new FormProductoSpec();
            fps.productoSeleccionadoi = productoSeleccionado;          

            fps.ShowDialog();
             */
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

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            DataRow dr = ReconocerCodigo.codigoReconocido(textBoxCatalogo.Text);
            if (dr != null)
            {
                AbrirFormProducto(Convert.ToInt32(dr["Id"]), (bool)dr["STOCKMUERTO"]);
            }
            else
            {
                VisualizarDGV();
            }
        }


        private void textBoxCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (e.KeyValue == 13)
            {
                DataRow dr = ReconocerCodigo.codigoReconocido(textBoxCatalogo.Text);
                if (dr != null)
                {                  
                    AbrirFormProducto(Convert.ToInt32(dr["Id"]), (bool)dr["STOCKMUERTO"]);
                }
                else
                {
                    VisualizarDGV();
                }
            }
        }

        private void textBoxMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return;  }
            if (e.KeyValue==13)
            {
                VisualizarDGV();                
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eNTRADASToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void sALIDASToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gENERAROSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSALIDAS SACAS = new FormSALIDAS();
            SACAS.comboBoxClientes.DataSource = lista;            
            SACAS.textBoxTipoCambio.Text = tc;
            this.Hide();
            SACAS.ShowDialog();
            this.Show();
        }

        private void gENERAROREPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOREP REP = new FormOREP();
            this.Hide();
            REP.ShowDialog();
            this.Show();
        }

        private void gENERAROSAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormENTRADAS ENTRY = new FormENTRADAS();
            //ENTRADAS ENTRY = new ENTRADAS();
            this.Hide();
            ENTRY.ShowDialog();
            this.Show();
        }

        private void vERTODASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOEN_GENERAL foenG = new FormOEN_GENERAL();
            this.Hide();
            foenG.ShowDialog();
            this.Show();
        }

        private void vERTODASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOSA_GENERAL fosaG = new FormOSA_GENERAL();
            this.Hide();
            fosaG.lista = lista;
            fosaG.tc = tc;
            fosaG.ShowDialog();
            this.Show();
        }

        private void vEROREPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOREP_GENERAL forepG = new FormOREP_GENERAL();
            this.Hide();
            forepG.ShowDialog();
            this.Show();
        }

        private void textBoxCatalogo_TextChanged(object sender, EventArgs e)
        {
        }

        private void lISTAEXISTENCIASToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormListaExistencias fle = new FormListaExistencias();
            this.Hide();
            fle.ShowDialog();
            this.Show();
        }

        private void pROYECTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void nUEVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FormAltaProyecto ap = new FormAltaProyecto();
            ap.ShowDialog();*/
        }

        private void vERTODOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPROYECTOS p = new FormPROYECTOS();
            p.ShowDialog();
        }

        private void rESPALDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRespaldoCompras fr = new FormRespaldoCompras();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportes reporte = new FormReportes();
            this.Hide();
            reporte.ShowDialog();
            this.Show();
        }

        private void iNFLACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInflacion inf = new FormInflacion();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void cOSTOALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            almacen inf = new almacen();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            //MessageBox.Show("orde");
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells[20].Value != null)
                {
                    if (fila.Cells[20].Value.ToString() == "")
                        fila.Cells[9].Style.BackColor = System.Drawing.Color.Gold;
                    if (fila.Cells[21].Value.ToString() == "")
                        fila.Cells[9].Style.BackColor = System.Drawing.Color.DarkRed;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            VisualizarDGV();
        }
    }
}
