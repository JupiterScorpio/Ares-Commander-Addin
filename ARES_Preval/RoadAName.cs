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
    public partial class RoadAName : Form
    {
        public RoadAName()
        {
            InitializeComponent();
            Plugin.ANexistRdwidth = "";
            Plugin.ANpropRdwidth = "";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (existing_txt.Text != "" && Prop_txt.Text != "")
            {
                Plugin.ANexistRdwidth = existing_txt.Text + " MT WIDE EXISTING";
                Plugin.ANpropRdwidth = Prop_txt.Text + " MT WIDE PROPOSED";
                Plugin.bANRd = true;
                this.Close();
            }
            else
                MessageBox.Show("Please input correct value", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void btn_cncl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void existing_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prop_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
