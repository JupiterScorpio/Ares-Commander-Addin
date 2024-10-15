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
    public partial class LineConversion : Form
    {
        List<Line> onlylinelist = new List<Line>();
        List<ObjectId> objidlist = new List<ObjectId>();
        List<Line> selectedlines = new List<Line>();
        List<ObjectId> selobjs = new List<ObjectId>();
        public LineConversion()
        {
            InitializeComponent();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;
            string layer = listBox1.SelectedItem.ToString();
            if (layer != "")
            {
                foreach (ObjectId oid in selobjs)
                {
                    using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
                    {
                        Line ln = tr.GetObject(oid, OpenMode.ForWrite, false) as Line;
                        ln.Layer = layer;
                        tr.Commit();
                    }
                }
            }
            //listView1.SelectedItems
        }
        public void GetonlyLinelist()
        {
            var documentManager = Application.DocumentManager;
            var currentDocument = documentManager.MdiActiveDocument;
            var db = currentDocument.Database;
            using (var tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                var blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                foreach (ObjectId btrId in blockTable)
                {
                    var btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                    var lineCls = RXObject.GetClass(typeof(Teigha.DatabaseServices.Line));
                    if (btr.IsLayout)
                    {
                        foreach (ObjectId id in btr)
                        {
                            Entity subent = tr.GetObject(id, OpenMode.ForRead) as Entity;
                            if (id.ObjectClass == lineCls)
                            {
                                var line = (Teigha.DatabaseServices.Line)tr.GetObject(id, OpenMode.ForRead);
                                onlylinelist.Add(line);
                            }
                        }
                    }
                }
                tr.Commit();
            }
        }

        private void btn_cancl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LineConversion_Load(object sender, EventArgs e)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            GetonlyLinelist();
            linedisplayer();
            if (Plugin.allLayers.Count == 0)
            {
                Plugin.allLayers = Commands.LayersToList(acCurDb);
            }
            foreach (string layer in Plugin.allLayers)
            {
                listBox1.Items.Add(layer);
            }
        }
        public void linedisplayer()
        {
            foreach (Line ln in onlylinelist)
            {
                objidlist.Add(ln.ObjectId);
                string layername = ln.Layer;
                string[] row = { layername, ln.ObjectId.ToString() };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;
            List<ObjectId> tmpobjlist = new List<ObjectId>();
            string objectstring = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                objectstring = item.SubItems[1].Text;
                //tmpobjlist.Add(objectstring);
                foreach (ObjectId oid in objidlist)
                {
                    if (oid.ToString() == objectstring)
                    {
                        tmpobjlist.Add(oid);
                    }
                }
            }
            selobjs = tmpobjlist;
            using (DocumentLock docLock = acDoc.LockDocument())
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    if (tmpobjlist.Count > 0)
                    {
                        ed.SetImpliedSelection(tmpobjlist.ToArray());
                        acTrans.Commit();
                    }
                }
                ed.UpdateScreen();
            }
        }
    }
}
