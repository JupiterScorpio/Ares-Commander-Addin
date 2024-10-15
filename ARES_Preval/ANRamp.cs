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
    public partial class ANRamp : Form
    {
        string strSelitem;
        public ANRamp()
        {
            InitializeComponent();
        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            if (width_txt.Text != "" && strSelitem != "" && height_txt.Text != "" && length_txt.Text != "")
            {
                Plugin.ANrmpitem = strSelitem;
                Plugin.ANRmpwidth = width_txt.Text + " mt. Wide ";
                Plugin.ANRmphght = height_txt.Text + " mt. Height ";
                Plugin.ANRmplngh = length_txt.Text + " mt. Length ";
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

        private void ANRamp_Load_1(object sender, EventArgs e)
        {

        }
    }
}
