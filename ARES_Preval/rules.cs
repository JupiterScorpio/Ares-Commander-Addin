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
    public class winrule
    {
        public Polyline pl;
        public float width;
        public float height;
        public float depth;
        public ObjectId objid;
        public string hnd;
        public string kind;
    }
    public class doorrule
    {
        public Polyline pl;
        public float width;
        public float height;
        public float depth;
        public ObjectId objid;
        public string hnd;
        public string kind;
    }
    public class Gaterule
    {
        public Polyline pl;
        public float width;
        public float height;
        public float depth;
        public ObjectId objid;
        public Handle hnd;
        public string kind;
    }
    public class roomrule
    {
        public Polyline pl;
        public double width;
        public double height;
        public ObjectId objid;
        public string hnd;
        public string kind;
    }
    public class mroadrule
    {
        public Polyline pl;
        public float width;
        public float height;
        public ObjectId objid;
        public string hnd;
        public string kind;
        public mroadrule()
        {
            this.pl = new Polyline();
            this.width = 0;
            this.height = 0;
            this.objid = new ObjectId();
            this.hnd = "0";
            this.kind = "";
        }
    }
    public class intRoadrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class plotrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class indvSubPlotrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class openspacerule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class amenityrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aMortrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aSplayrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class abufferzonerule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class awaterbodyrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class awaterlinerule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aelectriclinerule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aLeftownersrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aSurroundtoAuthorityrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aCmpWallrule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aelinerule
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aFlorInSec
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aStair
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class aPassage
    {
        public Polyline pl;
        public float width;
        public float height;
    }
    public class ruleError
    {
        public string lyrname;
        public int errorCnt;
        public string errcause;
        public List<ObjectId> objIdlist = null;
    }
    public class JsonItems
    {
        public string layer { get; set; }
        public string OId { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public string hndle { get; set; }
        public string projtype { get; set; }
        public string bpass { get; set; }
        public string kind { get; set; }
        public ResultBuffer ToResultBuffer()
        {
            if (kind == null)
                kind = "";
            if (OId == null)
                OId = "0";
            if (bpass == null)
                if (Plugin.bRulePass)
                    bpass = "PASSED";
                else
                    bpass = "FAILED";
            return new ResultBuffer(
            new TypedValue((int)DxfCode.XTextString, layer),
            new TypedValue((int)DxfCode.Handle, OId),//OId should not be "", should have some value which could be converted into Int64 value
            new TypedValue((int)DxfCode.Real, width),
            new TypedValue((int)DxfCode.Real, height),
            new TypedValue((int)DxfCode.Real, depth),
            new TypedValue((int)DxfCode.Handle, hndle),
            new TypedValue((int)DxfCode.XTextString, projtype),
            new TypedValue((int)DxfCode.XTextString, bpass),
            new TypedValue((int)DxfCode.XTextString, kind));
        }
    }
}
