using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARES_Preval
{
    public partial class ANPassage : Form
    {
        string strSelitem;
        public ANPassage()
        {
            InitializeComponent();
        }

        private void ANPassage_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            if (width_txt.Text != "" && strSelitem != "")
            {
                Plugin.ANPgeitem = strSelitem;
                Plugin.ANPgewidth = width_txt.Text + " mt. Wide ";
                Plugin.bANPge = true;
                this.Close();
            }
            else
                MessageBox.Show("Please input correct value", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            strSelitem = comboBox1.SelectedItem.ToString();
        }
    }
}
