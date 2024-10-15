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
    public partial class RuleCheckForm : Form
    {
        public RuleCheckForm()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeViewEventArgs e)
        {
            string nodeText = treeView1.SelectedNode.Text;
            ErrorCauseDisplay(nodeText);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RuleCheckForm_Load(object sender, EventArgs e)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;
            int allErrCnt = 0;
            foreach (ruleError re in Commands.errlist)
            {
                if (re.errorCnt > 0)
                {
                    TreeNode node = new TreeNode(re.lyrname);
                    treeView1.Nodes.Add(node);
                    for (int i = 0; i < re.errorCnt; i++)
                    {
                        TreeNode childnode = new TreeNode(re.lyrname + "--" + i.ToString());
                        node.Nodes.Add(childnode);
                    }
                    allErrCnt++;
                }
            }
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                   OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                      OpenMode.ForWrite) as BlockTableRecord;
                foreach (DBText txt in Plugin.aZeroTxt)
                {
                    DBText dbText = acTrans.GetObject(txt.ObjectId, OpenMode.ForRead) as DBText;
                    string str = dbText.TextString;
                    //string str = txt.TextString;
                    if (str.Contains("RULE-"))
                    {
                        Entity ent = (Entity)acTrans.GetObject(txt.ObjectId, OpenMode.ForWrite);
                        ent.Erase();
                        ent.UpgradeOpen();
                    }
                }
                ed.UpdateScreen();
                acTrans.Commit();
            }
            if (allErrCnt == 0)
            {
                textBox1.Text = "There are no Errors in this drawing.";
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the Block table for read
                    BlockTable acBlkTbl;
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                       OpenMode.ForRead) as BlockTable;
                    // Open the Block table record Model space for write
                    BlockTableRecord acBlkTblRec;
                    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                          OpenMode.ForWrite) as BlockTableRecord;
                    // Create a single-line text object
                    DBText acText = new DBText();
                    acText.SetDatabaseDefaults();
                    acText.Position = new Point3d(2, 2, 0);
                    acText.Height = 30;
                    acText.TextString = "RULE-PASSED.-" + DateTime.Now.ToString();
                    acText.Layer = "0";
                    acBlkTblRec.AppendEntity(acText);
                    acTrans.AddNewlyCreatedDBObject(acText, true);
                    Plugin.bRulePass = true;
                    // Save the changes and dispose of the transaction


                    List<JsonItems> jsonlists = new List<JsonItems>();
                    jsonlists.Add(new JsonItems()
                    {
                        layer = "0",
                        OId = acText.ObjectId.ToString(),
                        width = 0,
                        height = 0,
                        hndle = acText.Handle.ToString(),
                        projtype = Commands.ProjecttypeTostring(Plugin.projtypestate),
                        bpass = "PASSED"
                    });
                    var nod = (DBDictionary)acTrans.GetObject(acCurDb.NamedObjectsDictionaryId, OpenMode.ForWrite);
                    DBDictionary prevaldict;
                    if (nod.Contains("PrevalData"))
                    {
                        prevaldict = (DBDictionary)acTrans.GetObject(nod.GetAt("PrevalData"), OpenMode.ForWrite);
                    }
                    else
                    {
                        acTrans.GetObject(acCurDb.NamedObjectsDictionaryId, OpenMode.ForWrite);
                        prevaldict = new DBDictionary();
                        nod.SetAt("PrevalData", prevaldict);
                        acTrans.AddNewlyCreatedDBObject(prevaldict, true);
                    }
                    for (int i = 0; i < jsonlists.Count; i++)
                    {
                        Xrecord myXrecord = new Xrecord();
                        prevaldict.SetAt(i.ToString(), myXrecord);
                        acTrans.AddNewlyCreatedDBObject(myXrecord, true);
                        ResultBuffer resbuf = jsonlists[i].ToResultBuffer();
                        myXrecord.Data = resbuf;
                    }
                    acTrans.Commit();
                }

            }
            else
            {
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the Block table for read
                    BlockTable acBlkTbl;
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                       OpenMode.ForRead) as BlockTable;
                    // Open the Block table record Model space for write
                    BlockTableRecord acBlkTblRec;
                    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                          OpenMode.ForWrite) as BlockTableRecord;
                    // Create a single-line text object
                    DBText acText = new DBText();
                    acText.SetDatabaseDefaults();
                    acText.Position = new Point3d(2, 2, 0);
                    acText.Height = 30;
                    acText.TextString = "RULE-FAILED.-" + DateTime.Now.ToString();
                    acText.Layer = "0";
                    acBlkTblRec.AppendEntity(acText);
                    acTrans.AddNewlyCreatedDBObject(acText, true);
                    Plugin.bRulePass = false;
                    // Save the changes and dispose of the transaction

                    List<JsonItems> jsonlists = new List<JsonItems>();
                    jsonlists.Add(new JsonItems()
                    {
                        layer = "0",
                        OId = "",
                        width = 0,
                        height = 0,
                        hndle = acText.Handle.ToString(),
                        projtype = Commands.ProjecttypeTostring(Plugin.projtypestate),
                        bpass = "FAILED"
                    });
                    var nod = (DBDictionary)acTrans.GetObject(acCurDb.NamedObjectsDictionaryId, OpenMode.ForWrite);
                    DBDictionary prevaldict;
                    if (nod.Contains("PrevalData"))
                    {
                        prevaldict = (DBDictionary)acTrans.GetObject(nod.GetAt("PrevalData"), OpenMode.ForWrite);
                    }
                    else
                    {

                        acTrans.GetObject(acCurDb.NamedObjectsDictionaryId, OpenMode.ForWrite);
                        prevaldict = new DBDictionary();
                        nod.SetAt("PrevalData", prevaldict);
                        acTrans.AddNewlyCreatedDBObject(prevaldict, true);
                    }

                    for (int i = 0; i < jsonlists.Count; i++)
                    {
                        Xrecord myXrecord = new Xrecord();
                        prevaldict.SetAt(i.ToString(), myXrecord);
                        acTrans.AddNewlyCreatedDBObject(myXrecord, true);
                        ResultBuffer resbuf = jsonlists[i].ToResultBuffer();
                        myXrecord.Data = resbuf;
                    }
                    acTrans.Commit();
                }
            }

        }
        private void ErrorCauseDisplay(string str)
        {
            if (!str.Contains("--"))
                return;
            int pos = str.IndexOf("--");
            string layername = str.Substring(0, pos);
            int number = Convert.ToInt32(str.Substring(pos + 2));
            List<string> errStrList = new List<string>();
            foreach (ruleError err in Commands.errlist)
            {
                if (err.lyrname == layername)
                {
                    Document curdoc = Application.DocumentManager.MdiActiveDocument;
                    var database = curdoc.Database;
                    var ed = curdoc.Editor;
                    List<ObjectId> tmpobjlist = new List<ObjectId>();
                    if (err.objIdlist.Count > 0)
                    {
                        tmpobjlist.Add(err.objIdlist[number]);

                        //Application.ShowAlertDialog(layername+":_"+err.errcause + ":_" + err.objIdlist.Count.ToString());
                        //if (layername == "_Amenity")
                        //    tmpobjlist = err.objIdlist;
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

                        string strtemp = err.errcause;
                        while (strtemp != "")
                        {
                            int postrim = strtemp.IndexOf("-", 1);
                            if (postrim != -1)
                            {
                                string strbuf = strtemp.Substring(0, postrim);
                                strtemp = strtemp.Remove(0, postrim);
                                errStrList.Add(strbuf);
                            }
                            else
                            {
                                errStrList.Add(strtemp);
                                strtemp = "";
                            }
                        }
                        textBox1.Text = errStrList[number];
                    }
                    else
                    {
                        string strtemp = err.errcause;
                        textBox1.Text = strtemp;
                    }
                }
            }
        }
        public void AddingErrors()
        {
            //int allErrCnt = 0;
            //foreach (ruleError re in Commands.errlist)
            //{
            //    if (re.errorCnt != 0)
            //    {
            //        TreeNode node = new TreeNode(re.lyrname);
            //        this.treeView1.Nodes.Add(node);
            //        for (int i = 0; i < re.errorCnt; i++)
            //        {
            //            TreeNode childnode = new TreeNode(re.lyrname + "--" + i.ToString());
            //            node.Nodes.Add(childnode);
            //        }
            //        allErrCnt++;
            //    }
            //}
            //if (allErrCnt == 0)
            //    this.textBox1.Text = "There are no Errors in this drawing.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int allErrCnt = 0;
            //foreach (ruleError re in Commands.errlist)
            //{
            //    if (re.errorCnt != 0)
            //    {
            //        TreeNode node = new TreeNode(re.lyrname);
            //        treeView1.Nodes.Add(node);
            //        for (int i = 0; i < re.errorCnt; i++)
            //        {
            //            TreeNode childnode = new TreeNode(re.lyrname + "--" + i.ToString());
            //            node.Nodes.Add(childnode);
            //        }
            //        allErrCnt++;
            //    }
            //}
            //if (allErrCnt == 0)
            //    textBox1.Text = "There are no Errors in this drawing.";
        }
    }
}
