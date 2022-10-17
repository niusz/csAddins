using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BCOM = Bentley.Interop.MicroStationDGN;
using Bentley.MicroStation.InteropServices;

namespace csAddins
{
    [Bentley.MicroStation.AddInAttribute
        (KeyinTree = "csAddins.commands.xml", MdlTaskID = "CSADDINS")]
        
    internal sealed class MyAddin: Bentley.MicroStation.AddIn
    {
        public static MyAddin s_addin = null;
        private MyAddin(System.IntPtr mdlDesc)
            : base(mdlDesc)
            {
            s_addin = this;
        }
        protected override int Run(string[] commandLine)
        {
            //string sWinFrameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            //MessageBox.Show("Framework Path =" + sWinFrameworkPath);
            //CreateElement.LineAndLineString();
            //CreateElement.ShapeAndComplexShape();
            //CreateElement.TextAndTextNode();
            //CreateElement.CellAndSharedCell();
            //CreateElement.LinearAndAngularDimension();
            //CreateElement.CurveAndBsplineCurve();
            //CreateElement.ConeAndBsplineSurface();
            BCOM.Application app = Utilities.ComApp;
            app.CadInputQueue.SendKeyin("csAddins DemoForm Toolbar");
            return 0;
        }

    }
}
