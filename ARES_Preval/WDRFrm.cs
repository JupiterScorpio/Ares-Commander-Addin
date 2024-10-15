using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.ApplicationServices;
using Teigha.DatabaseServices;
using Teigha.EditorInput;
using Teigha.Runtime;
using Teigha.Geometry;
using Teigha.PlottingServices;
using Teigha.Colors;
using Teigha.Customization;
using Teigha.Windows;
using Teigha.GraphicsSystem;
using Teigha.ApplicationServices.Core;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using Exception = System.Exception;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Globalization;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Application = Teigha.ApplicationServices.Core.Application;
using AcadDocument = Teigha.ApplicationServices.Document;
using AcadWindows = Teigha.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ARES_Preval
{
    public partial class WDRFrm : Form
    {
        public WDRFrm()
        {
            InitializeComponent();
        }

        private void WDRFrm_Load(object sender, EventArgs e)
        {
            TreeNode Wnode = new TreeNode("Windows");
            treeView1.Nodes.Add(Wnode);
            int windex = 0;
            foreach (winrule wrule in Commands.awindowrule)
            {
                TreeNode childnode = new TreeNode("Window" + "--" + windex.ToString() + "->" + wrule.width.ToString() + " X " + wrule.height.ToString());
                Wnode.Nodes.Add(childnode);
                windex++;
            }
            TreeNode Dnode = new TreeNode("Doors");
            treeView1.Nodes.Add(Dnode);
            int dindex = 0;
            foreach (doorrule drule in Commands.adoorrule)
            {
                TreeNode childnode = new TreeNode("Door" + "--" + dindex.ToString() + "->" + drule.width.ToString() + " X " + drule.height.ToString());
                Dnode.Nodes.Add(childnode);
                dindex++;
            }
            TreeNode Rnode = new TreeNode("Rooms");
            treeView1.Nodes.Add(Rnode);
            int rindex = 0;
            //foreach (roomrule rrule in Commands.aroomrule)
            //{
            //    TreeNode childnode = new TreeNode("Room"+rindex.ToString()+"--"+rrule.width.ToString() + " X " + rrule.height.ToString());
            //    Wnode.Nodes.Add(childnode);
            //    rindex++;
            //}
            foreach (roomrule rrule in Commands.aroomrule)
            {
                double width = Math.Round(rrule.width, 2);
                double height = Math.Round(rrule.height, 2);
                TreeNode childnode = new TreeNode("Room" + "--" + rindex.ToString() + "->" + width.ToString() + " X " + height.ToString());
                Rnode.Nodes.Add(childnode);
                rindex++;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = treeView1.SelectedNode.Text;
            ErrorCauseDisplay(nodeText);
        }
        private void ErrorCauseDisplay(string str)
        {
            if (!str.Contains("--"))
                return;
            int pos = str.IndexOf("--");
            int pos1 = str.IndexOf("->");
            string layername = str.Substring(0, pos);
            int number = Convert.ToInt32(str.Substring(pos + 2, pos1 - pos - 2));
            List<string> errStrList = new List<string>();
            switch (layername)
            {
                case "Window":
                    {
                        Document curdoc = Application.DocumentManager.MdiActiveDocument;
                        var database = curdoc.Database;
                        var ed = curdoc.Editor;
                        List<ObjectId> tmpobjlist = new List<ObjectId>();
                        tmpobjlist.Add(Commands.awindowrule[number].objid);
                        using (DocumentLock docLock = curdoc.LockDocument())
                        {
                            using (Transaction acTrans = database.TransactionManager.StartTransaction())
                            {
                                if (tmpobjlist.Count > 0)
                                {
                                    ed.SetImpliedSelection(tmpobjlist.ToArray());
                                    acTrans.Commit();
                                }
                            }
                            ed.UpdateScreen();
                        }
                        break;
                    }
                case "Door":
                    {
                        Document curdoc = Application.DocumentManager.MdiActiveDocument;
                        var database = curdoc.Database;
                        var ed = curdoc.Editor;
                        List<ObjectId> tmpobjlist = new List<ObjectId>();
                        tmpobjlist.Add(Commands.adoorrule[number].objid);
                        using (DocumentLock docLock = curdoc.LockDocument())
                        {
                            using (Transaction acTrans = database.TransactionManager.StartTransaction())
                            {
                                if (tmpobjlist.Count > 0)
                                {
                                    ed.SetImpliedSelection(tmpobjlist.ToArray());
                                    acTrans.Commit();
                                }
                            }
                            ed.UpdateScreen();
                        }
                        break;
                    }
                case "Room":
                    {
                        Document curdoc = Application.DocumentManager.MdiActiveDocument;
                        var database = curdoc.Database;
                        var ed = curdoc.Editor;
                        List<ObjectId> tmpobjlist = new List<ObjectId>();
                        //tmpobjlist.Add(Commands.aroomrule[number].objid);
                        tmpobjlist.Add(Commands.aroomrule[number].objid);
                        using (DocumentLock docLock = curdoc.LockDocument())
                        {
                            using (Transaction acTrans = database.TransactionManager.StartTransaction())
                            {
                                if (tmpobjlist.Count > 0)
                                {
                                    ed.SetImpliedSelection(tmpobjlist.ToArray());
                                    acTrans.Commit();
                                }
                            }
                            ed.UpdateScreen();
                        }
                        break;
                    }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
