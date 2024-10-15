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
    public partial class Createdlayerlists : Form
    {
        public Createdlayerlists()
        {
            InitializeComponent();
        }
        
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            Commands.makingLayers();
            this.Close();
        }

        private void Createdlayerlists_Load_1(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Layers Created");
            treeView1.Nodes.Add(node);
            foreach (string st in Plugin.lyrName)
            {
                TreeNode childnode = new TreeNode(st);
                node.Nodes.Add(childnode);
            }
        }
    }
}
