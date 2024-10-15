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
    public partial class TwoPolyTouch : Form
    {
        string directionstr;
        public TwoPolyTouch()
        {
            InitializeComponent();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            Plugin.twopolystr1 = directionstr;
            this.Close();
        }

        private void Btn_cncl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Left1_CheckedChanged(object sender, EventArgs e)
        {
            directionstr = "l1";
        }

        private void Right1_CheckedChanged(object sender, EventArgs e)
        {
            directionstr = "r1";
        }

        private void Top1_CheckedChanged(object sender, EventArgs e)
        {
            directionstr = "t1";
        }

        private void Down1_CheckedChanged(object sender, EventArgs e)
        {
            directionstr = "d1";
        }
        public static void maketwopoly()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            Point3d left1 = Commands.Getleft(Plugin.ANBNPpl1);
            Point3d top1 = Commands.Gettop(Plugin.ANBNPpl1);
            Point3d right1 = Commands.Getright(Plugin.ANBNPpl1);
            Point3d bottom1 = Commands.Getbottom(Plugin.ANBNPpl1);

            Point3d left2 = Commands.Getleft(Plugin.ANBNPpl2);
            Point3d top2 = Commands.Gettop(Plugin.ANBNPpl2);
            Point3d right2 = Commands.Getright(Plugin.ANBNPpl2);
            Point3d bottom2 = Commands.Getbottom(Plugin.ANBNPpl2);
            double distance = 0;
            switch (Plugin.twopolystr1)
            {
                case "l1":
                    {
                        distance = left2.X - right1.X;
                        using (DocumentLock docLock = acDoc.LockDocument())
                        {
                            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                            {
                                BlockTable acBlkTbl;
                                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                                   OpenMode.ForWrite) as BlockTable;
                                BlockTableRecord acBlkTblRec;
                                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                                      OpenMode.ForWrite) as BlockTableRecord;
                                Point3d acPt3d = new Point3d(right1.X, 0, 0);
                                Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(left2.X, 0, 0));
                                Plugin.ANBNPpl1.TransformBy(Matrix3d.Displacement(acVec3d));

                                acBlkTblRec.AppendEntity(Plugin.ANBNPpl1);
                                acTrans.AddNewlyCreatedDBObject(Plugin.ANBNPpl1, true);
                                acTrans.Commit();
                            }
                        }
                        break;
                    }

                case "r1":
                    {
                        distance = left1.X - right2.X;
                        using (DocumentLock docLock = acDoc.LockDocument())
                        {
                            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                            {
                                BlockTable acBlkTbl;
                                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                                   OpenMode.ForWrite) as BlockTable;
                                BlockTableRecord acBlkTblRec;
                                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                                      OpenMode.ForWrite) as BlockTableRecord;
                                Point3d acPt3d = new Point3d(left1.X, 0, 0);
                                Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(right2.X, 0, 0));
                                Plugin.ANBNPpl1.TransformBy(Matrix3d.Displacement(acVec3d));
                                acBlkTblRec.AppendEntity(Plugin.ANBNPpl1);
                                acTrans.AddNewlyCreatedDBObject(Plugin.ANBNPpl1, true);
                                acTrans.Commit();
                            }
                        }
                        break;
                    }
                case "t1":
                    {
                        distance = bottom1.Y - top2.Y;
                        using (DocumentLock docLock = acDoc.LockDocument())
                        {
                            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                            {
                                BlockTable acBlkTbl;
                                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                                   OpenMode.ForWrite) as BlockTable;
                                BlockTableRecord acBlkTblRec;
                                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                                      OpenMode.ForWrite) as BlockTableRecord;
                                Point3d acPt3d = new Point3d(bottom1.Y, 0, 0);
                                Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(top2.Y, 0, 0));
                                Plugin.ANBNPpl1.TransformBy(Matrix3d.Displacement(acVec3d));
                                acBlkTblRec.AppendEntity(Plugin.ANBNPpl1);
                                acTrans.AddNewlyCreatedDBObject(Plugin.ANBNPpl1, true);
                                acTrans.Commit();
                            }
                        }
                        break;
                    }
                case "d1":
                    {
                        distance = bottom2.Y - top1.Y;
                        using (DocumentLock docLock = acDoc.LockDocument())
                        {
                            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                            {
                                BlockTable acBlkTbl;
                                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                                   OpenMode.ForWrite) as BlockTable;
                                BlockTableRecord acBlkTblRec;
                                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                                      OpenMode.ForWrite) as BlockTableRecord;
                                Point3d acPt3d = new Point3d(bottom2.Y, 0, 0);
                                Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(top1.Y, 0, 0));
                                Plugin.ANBNPpl1.TransformBy(Matrix3d.Displacement(acVec3d));
                                acBlkTblRec.AppendEntity(Plugin.ANBNPpl1);
                                acTrans.AddNewlyCreatedDBObject(Plugin.ANBNPpl1, true);
                                acTrans.Commit();
                            }
                        }
                        break;
                    }
            }
        }
    }
}
