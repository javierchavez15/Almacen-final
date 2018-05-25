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
    public partial class codigos : Form
    {
        public codigos()
        {
            InitializeComponent();
        }

        public int codigo = 0;
        public string catalogo = "";

        public DataTable tablacodigos;

        private void codigos_Load(object sender, EventArgs e)
        {
            this.Text = catalogo;
            if(tablacodigos.Rows.Count>0)
            {
                dataGridView1.DataSource = tablacodigos;
            }
            else
            {
                if (codigo != 0)
                {
                    DataRow row = tablacodigos.NewRow();
                    row["Id"] = codigo;
                    row["CODIGO"] = codigo;
                    tablacodigos.Rows.Add(row);
                }
                dataGridView1.DataSource = tablacodigos;
                dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Cells[0].Value = 0;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[0].Value==DBNull.Value)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 0;
        }

        private void dataGridView1_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == DBNull.Value)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 0;
        }
    }
}
