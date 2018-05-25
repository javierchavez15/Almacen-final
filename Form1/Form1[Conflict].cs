using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libData;
using System.Management;


namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         DataBase bdAccess;
         DataBase bd;
         PRODUCTOS productoPrueba;
         PRODUCTOS productoSeleccionado;
        
        private void Form1_Load(object sender, EventArgs e)
        {
/*
            bd = new DataBase();
            bd.DataBaseProvider = TypeOfDataBase.MicrosoftSqlServer;
            bd.ConnectionString = "server=idea-PC; DataBase=DBI; User Id=sa; Password=1945sqlserver";
            bd.CreateConnection();
            DbObject.DefaultDataBaseObject = bd;
*/

            bdAccess = new DataBase();
            bdAccess.DataBaseProvider = TypeOfDataBase.MicrosoftAccess;
            bdAccess.ConnectionString = "Provider=Microsoft.jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\descoBI.mdb;Jet OLEDB:Database Password=1945Inadescobi";
            bdAccess.CreateConnection();
            DbObject.DefaultDataBaseObject = bdAccess;

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
        }

        private void aLTABAJAEDICIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaProductos AP = new FormAltaProductos();
          
            AP.ShowDialog();

            if (AP.DialogResult == DialogResult.OK)
            {
              
            }
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
                dataGridView1.DataSource = PRODUCTOS.ListaProductos(textBoxCatalogo.Text, textBoxMarca.Text);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[2].Width = 470;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Width = 60;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[9].DisplayIndex = 0;
                dataGridView1.Columns[10].Width = 70;
                dataGridView1.Columns[11].Width = 70;
                dataGridView1.Columns[12].Width = 70;
                dataGridView1.Columns[13].Width = 100;
            }
            catch
            {
                MessageBox.Show("0 Resultados. Modifique su búsqueda");
            }
        }

        private void AbrirFormProducto(int idPcto)
        {
            productoSeleccionado = new PRODUCTOS(idPcto);

            FormProductoSpec fps = new FormProductoSpec();
            fps.productoSeleccionadoi = productoSeleccionado;

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

            int idPcto = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            AbrirFormProducto(idPcto);

            /*
            productoSeleccionado = new PRODUCTOS(idPcto);

            FormProductoSpec fps = new FormProductoSpec();
            fps.productoSeleccionadoi = productoSeleccionado;          

            fps.ShowDialog();
             */        
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DataRow dr = ReconocerCodigo.codigoReconocido(textBoxCatalogo.Text);
            if (dr != null)
            {
                AbrirFormProducto(Convert.ToInt32(dr["Id"]));
            }
            else
            {
                VisualizarDGV();
            }
        }


        private void textBoxCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == 13)
            {
                DataRow dr = ReconocerCodigo.codigoReconocido(textBoxCatalogo.Text);
                if (dr != null)
                {                  
                    AbrirFormProducto(Convert.ToInt32(dr["Id"]));
                }
                else
                {
                    VisualizarDGV();
                }
            }
        }

        private void textBoxMarca_KeyDown(object sender, KeyEventArgs e)
        {           
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
            SACAS.ShowDialog();
        }

        private void gENERAROREPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOREP REP = new FormOREP();
            REP.ShowDialog();
        }

        private void gENERAROSAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ENTRADAS ENTRY = new ENTRADAS();
            ENTRY.ShowDialog();
        }

        private void vERTODASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOEN_GENERAL foenG = new FormOEN_GENERAL();
            foenG.ShowDialog();
        }

        private void vERTODASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOSA_GENERAL fosaG = new FormOSA_GENERAL();
            fosaG.ShowDialog();
        }

        private void vEROREPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOREP_GENERAL forepG = new FormOREP_GENERAL();
            forepG.ShowDialog();
        }

        private void textBoxCatalogo_TextChanged(object sender, EventArgs e)
        {
            
 
        }

       

        private void lISTAEXISTENCIASToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormListaExistencias fle = new FormListaExistencias();
            fle.ShowDialog();
        }   
        
      
    }
}
