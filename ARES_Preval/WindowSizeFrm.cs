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
    public partial class WindowSizeFrm : Form
    {
        bool bwremark = false;
        public WindowSizeFrm()
        {
            InitializeComponent();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Plugin.nCurwidth = Convert.ToSingle(width_txt.Text);
            Plugin.nCurheight = Convert.ToSingle(height_txt.Text);
            Plugin.nCurDepth = Convert.ToSingle(depth_txt.Text);
            Commands.InswindName = Name_txt.Text.ToUpper();
            Commands.bwremark = bwremark;
            //windowrule tmpwind = new windowrule();
            //tmpwind.pl = Commands.curPline;
            //tmpwind.height = Plugin.nCurheight;
            //tmpwind.width = Plugin.nCurwidth;
            //Commands.awindowrule.Add(tmpwind);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bwremark = checkBox1.Checked;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
