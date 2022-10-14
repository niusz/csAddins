using System;
using System.Windows.Forms;
using Bentley.MicroStation.InteropServices;
using Bentley.MicroStation.WinForms;

namespace csAddins
{
    public partial class ToolbarForm : 
        //Form
        Adapter, IGuiDockable
    {
        private Bentley.Interop.MicroStationDGN.Application app = null;
        public ToolbarForm()
        {
            InitializeComponent();
            app = Utilities.ComApp;
        }
        // The below two methods come from IGuiDockable
        public bool GetDockedExtent(GuiDockPosition dockPosition, ref GuiDockExtent extentFlag, ref System.Drawing.Size dockSize)
        {
            return false;
        }
        public bool WindowMoving(WindowMovingCorner corner, ref System.Drawing.Size newSize)
        {
            newSize = new System.Drawing.Size(118, 34);
            return true;
        }
        private void btnModal_Click(object sender, EventArgs e)
        {
            app.CadInputQueue.SendKeyin("csAddins DemoForm Modal");
        }

        private void btnTopLevel_Click(object sender, EventArgs e)
        {
            app.CadInputQueue.SendKeyin("csAddins DemoForm TopLevel");
        }

        private void btnToolSettings_Click(object sender, EventArgs e)
        {
            app.CadInputQueue.SendKeyin("csAddins DemoForm ToolSettings");
        }
    }
}
