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
    public partial class almacen : Form
    {
        public almacen()
        {
            InitializeComponent();
        }

        private void almacen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productos.ListaProductos();
            double suma = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                suma += Convert.ToDouble(row.Cells["TOTAL"].Value);
            }
            txtcosto.Text = suma.ToString("###,###.##");
            dataGridView1.Columns["ID"].Visible = false;
        }
        private DataTable facturas1;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBox1.Text = "";
            if(e.RowIndex>-1)
            { string id = dataGridView1["ID", e.RowIndex].Value.ToString();
                facturas1 = productos.ListaProductos(id);
                comboBox1.Items.Clear();
                foreach (DataRow a in facturas1.Rows)
                {
                    comboBox1.Items.Add(a[0]);
                }
            }
        }
    }
}
