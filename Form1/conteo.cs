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
    public partial class conteo : Form
    {
        public conteo()
        {
            InitializeComponent();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Convert.ToInt32(txtnumero.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch { }
            }
        }
    }
}
