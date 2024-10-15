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
    public partial class ANBnPropWork : Form
    {
        public ANBnPropWork()
        {
            InitializeComponent();
        }
               

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            if (wing_txt.Text != "" && build_txt.Text != "")
            {
                Plugin.ANBNPbuilding = " (" + build_txt.Text + ")";
                Plugin.ANBNPwing = wing_txt.Text;
                Plugin.bANBNP = false;
                Plugin.bANBNPlnCnt = 0;
                Commands.CallImplement();
                this.Close();
            }
            else
                MessageBox.Show("Please input correct value", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            Plugin.bANBNP = false;
            Plugin.bANBNPlnCnt = 0;
            this.Close();
        }

        private void ANBnPropWork_Load_1(object sender, EventArgs e)
        {
            Plugin.ANBNPbuilding = "";
            Plugin.ANBNPwing = "";
        }
    }
}
