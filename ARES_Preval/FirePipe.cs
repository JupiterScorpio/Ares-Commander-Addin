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
    public partial class FirePipe : Form
    {
        int selindex = 0;
        public FirePipe()
        {
            InitializeComponent();
        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            Plugin.linewgt = selindex;
        }

        private void btn_cncl_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selindex = listBox1.SelectedIndex;
        }
    }
}
