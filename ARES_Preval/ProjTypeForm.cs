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
using static ARES_Preval.Plugin;
using static System.Net.WebRequestMethods;
using System.Globalization;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Application = Teigha.ApplicationServices.Core.Application;
using AcadDocument = Teigha.ApplicationServices.Document;
using AcadWindows = Teigha.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using Teigha.LayerManager;

namespace ARES_Preval
{
    public partial class ProjTypeForm : Form
    {
        public ProjTypeForm()
        {
            InitializeComponent();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            Plugin.projtypestate = (uint)cmb_projtype.SelectedIndex;
            WritetoNODProjType();
            this.Close();
        }
        public static void WritetoNODProjType()
        {
            var documentManager = Application.DocumentManager;
            var currentDocument = documentManager.MdiActiveDocument;
            var db = currentDocument.Database;
            var ed = currentDocument.Editor;
            try
            {
                using (DocumentLock docLock = currentDocument.LockDocument())
                {
                    using (Transaction trans = db.TransactionManager.StartTransaction())
                    {
                        var nod = (DBDictionary)trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite);
                        DBDictionary prevaldict;
                        if (nod.Contains("PrevalProjectType"))
                        {
                            prevaldict = (DBDictionary)trans.GetObject(nod.GetAt("PrevalProjectType"), OpenMode.ForWrite);
                        }
                        else
                        {
                            trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite);
                            prevaldict = new DBDictionary();
                            nod.SetAt("PrevalProjectType", prevaldict);
                            trans.AddNewlyCreatedDBObject(prevaldict, true);
                        }

                        Xrecord myXrecord = new Xrecord();
                        prevaldict.SetAt("ProjectType", myXrecord);
                        string projtype = Commands.ProjecttypeTostring(Plugin.projtypestate);
                        ResultBuffer resbuf = new ResultBuffer(new TypedValue(5, projtype));
                        myXrecord.Data = resbuf;
                        trans.AddNewlyCreatedDBObject(myXrecord, true);
                        trans.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                //Application.ShowAlertDialog(e.ToString());
            }

        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_projtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plugin.projtypestate = (uint)cmb_projtype.SelectedIndex;
        }
    }
}
