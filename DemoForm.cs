using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bentley.MicroStation.InteropServices;
using Bentley.Interop.MicroStationDGN;
using BCOM = Bentley.Interop.MicroStationDGN;
using Bentley.MicroStation;

namespace csAddins
{
    class DemoForm
    {
        public static void Toolbar(string unparsed)
        {
            ToolbarForm myForm = new ToolbarForm();
            myForm.AttachAsGuiDockable(MyAddin.s_addin, "toolbar");
            myForm.Show();
        }
        public static void Modal(string unparsed)
        {
            ModalForm myForm = new ModalForm();
            if (DialogResult.OK == myForm.ShowDialog())
                MessageBox.Show(myForm.textBox1.Text.ToString());
        }
        public static void TopLevel(string unparsed)
        {
            Utilities.ComApp.CommandState.StartLocate(new MultiScaleCopyClass());
        }
        public static void ToolSettings(string unparsed)
        {
            BCOM.Application app = Utilities.ComApp;
            if (app.ActiveModelReference.Is3D)
            {
                MessageBox.Show("This tool can only work in 2D model");
                return;
            }
            app.ActiveSettings.AnnotationScaleEnabled = false;
            app.CommandState.StartPrimitive(new NoteCoordClass());
        }

        public static LevelChangedClass myLevelChanged = null;
        public static AddIn.NewDesignFileEventHandler myNewDGNHandler = null;
        private static LevelChangedForm myLevelForm = null;
        public static void LevelChanged(string unparsed)
        {
            if (null == myLevelForm || myLevelForm.IsDisposed)
            {
                myLevelForm = new LevelChangedForm();
                myLevelForm.AttachAsTopLevelForm(MyAddin.s_addin, false);
                myLevelForm.Show(); myLevelChanged = new LevelChangedClass();
                Utilities.ComApp.AddLevelChangeEventsHandler(myLevelChanged); myNewDGNHandler = new AddIn.NewDesignFileEventHandler
                                        (LevelChangedClass.MyAddin_NewDesignFileEvent);
                MyAddin.s_addin.NewDesignFileEvent += myNewDGNHandler;
            }
            else
                myLevelForm.Activate();
        }
    }
    class NoteCoordClass : IPrimitiveCommandEvents
    {
        private BCOM.Application app = Utilities.ComApp;
        private NoteCoordForm myForm = new NoteCoordForm();
        private Point3d[] m_atPoints = new Point3d[3];
        private int m_nPoints = 0;
        public void Cleanup()
        {
            myForm.DetachFromMicroStation();
        }
        public void DataPoint(ref Point3d Point, BCOM.View View)
        {
            if (0 == m_nPoints)
            {
                app.CommandState.StartDynamics();
                m_atPoints[0] = Point;
                m_nPoints = 1;
                app.ShowPrompt("Identify note position");
            }
            else
            {
                Dynamics(ref Point, View, MsdDrawingMode.Normal);
                Reset();
            }
        }
        public void Dynamics(ref Point3d Point, BCOM.View View, MsdDrawingMode DrawMode)
        {
            if (1 != m_nPoints)
                return;
            string[] txtStr = new string[2];
            Point3d[] txtPts = new Point3d[2];
            Element[] elems = new Element[3]; m_atPoints[1] = Point;
            txtStr[0] = (myForm.rdoEN.Checked ? "E=" : "X=") + m_atPoints[0].X.ToString("F2");
            txtStr[1] = (myForm.rdoEN.Checked ? "N=" : "Y=") + m_atPoints[0].Y.ToString("F2");
            double txtLen = app.ActiveSettings.TextStyle.Width * Math.Max(txtStr[0].Length, txtStr[1].Length);
            double txtLineSpacing = app.ActiveSettings.TextStyle.Height;
            if (myForm.rdoHoriz.Checked)
            {
                m_atPoints[2].X = m_atPoints[1].X + (m_atPoints[0].X > m_atPoints[1].X ? -txtLen : txtLen) * 1.2;
                m_atPoints[2].Y = m_atPoints[1].Y;
                txtPts[0].X = (m_atPoints[1].X + m_atPoints[2].X) / 2;
                txtPts[0].Y = m_atPoints[1].Y + txtLineSpacing;
                txtPts[1].X = txtPts[0].X;
                txtPts[1].Y = m_atPoints[1].Y - txtLineSpacing;
            }
            else
            {
                m_atPoints[2].X = m_atPoints[1].X;
                m_atPoints[2].Y = m_atPoints[1].Y + (m_atPoints[0].Y > m_atPoints[1].Y ? -txtLen : txtLen) * 1.2;
                txtPts[0].X = m_atPoints[1].X - txtLineSpacing;
                txtPts[0].Y = (m_atPoints[1].Y + m_atPoints[2].Y) / 2;
                txtPts[1].X = m_atPoints[1].X + txtLineSpacing;
                txtPts[1].Y = txtPts[0].Y;
            }
            elems[0] = app.CreateLineElement1(null, ref m_atPoints);
            elems[0].LineStyle = app.ActiveDesignFile.LineStyles.Find("0");
            Matrix3d rMatrix = app.Matrix3dIdentity();
            for (int i = 1; i < 3; i++)
            {
                elems[i] = app.CreateTextElement1(null, txtStr[i - 1], ref txtPts[i - 1], ref rMatrix);
                elems[i].AsTextElement().TextStyle.Font = app.ActiveDesignFile.Fonts.Find(MsdFontType.MicroStation, "ENGINEERING");
                elems[i].AsTextElement().TextStyle.Justification = MsdTextJustification.CenterCenter;
                if (myForm.rdoVert.Checked)
                    elems[i].RotateAboutZ(txtPts[i - 1], Math.PI / 2);
            }
            CellElement elemCell = app.CreateCellElement1("NoteCoordCell", ref elems, ref m_atPoints[0]);
            elemCell.Redraw(DrawMode);
            if (MsdDrawingMode.Normal == DrawMode)
                app.ActiveModelReference.AddElement(elemCell);
        }
        public void Keyin(string Keyin)
        {
        }
        public void Reset()
        {
            m_nPoints = 0;
            app.CommandState.StartPrimitive(this);
        }
        public void Start()
        {
            //命令

            myForm.AttachToToolSettings(MyAddin.s_addin);
            myForm.Show();

            app.ShowCommand("Note Coordinate");
            app.ShowPrompt("Please identify a point");

            app.CommandState.EnableAccuSnap();
        }
    }
    class MultiScaleCopyClass : ILocateCommandEvents
    {
        private BCOM.Application app = Utilities.ComApp;
        private MultiScaleCopyForm myForm = new MultiScaleCopyForm();
        public void Accept(Element Elem, ref Point3d Point, BCOM.View View)
        {
            Element newEl;
            Point3d orgPnt;
            double dScale = double.Parse(myForm.txtScale.Text);
            Point3d offsetPnt = app.Point3dFromXYZ(double.Parse(myForm.txtXOffset.Text),
                                                   double.Parse(myForm.txtYOffset.Text),
                                                   double.Parse(myForm.txtZOffset.Text));
            for (int i = 0; i < int.Parse(myForm.txtCopies.Text); i++)
            {
                newEl = app.ActiveModelReference.CopyElement(Elem);
                newEl.Move(ref offsetPnt);
                orgPnt.X = (newEl.Range.Low.X + newEl.Range.High.X) * 0.5;
                orgPnt.Y = (newEl.Range.Low.Y + newEl.Range.High.Y) * 0.5;
                orgPnt.Z = (newEl.Range.Low.Z + newEl.Range.High.Z) * 0.5;
                newEl.ScaleAll(ref orgPnt, dScale, dScale, dScale);
                newEl.Redraw(MsdDrawingMode.Normal);
                Elem = newEl.Clone();
            }
        }
        public void Cleanup()
        {
            myForm.DetachFromMicroStation();
        }
        public void Dynamics(ref Point3d Point, BCOM.View View, MsdDrawingMode DrawMode)
        {
        }
        public void LocateFailed()
        {
            app.CommandState.StartLocate(this);
        }
        public void LocateFilter(Element Element, ref Point3d Point, ref bool Accepted)
        {
        }
        public void LocateReset()
        {
        }
        public void Start()
        {
            myForm.AttachToToolSettings(MyAddin.s_addin);
            myForm.Show();
            app.ShowCommand("MultiScaleCopy");
            app.ShowPrompt("Please identify an element");
            app.CommandState.EnableAccuSnap();
        }
    }
    
    class LevelChangedClass : ILevelChangeEvents
    {
        public void LevelChanged(MsdLevelChangeType ChangeType, Level TheLevel, ModelReference TheModel)
        {
            if (MsdLevelChangeType.AfterCreate == ChangeType ||
                MsdLevelChangeType.AfterDelete == ChangeType ||
                MsdLevelChangeType.ChangeName == ChangeType)
                PopulateLevelList();
        }
        public static void MyAddin_NewDesignFileEvent
                           (AddIn sender, AddIn.NewDesignFileEventArgs eventArgs)
        {
            if (AddIn.NewDesignFileEventArgs.When.AfterDesignFileOpen == eventArgs.WhenCode)
                PopulateLevelList();
        }
        private static void PopulateLevelList()
        {
            LevelChangedForm myLevelChangedForm = null;
            foreach (Form myForm in System.Windows.Forms.Application.OpenForms)
                if ("LevelChangedForm" == myForm.Name)
                {
                    myLevelChangedForm = (LevelChangedForm)myForm;
                    break;
                }
            if (null != myLevelChangedForm)
            {
                myLevelChangedForm.listBox1.Items.Clear();
                foreach (Level myLvl in Utilities.ComApp.ActiveDesignFile.Levels)
                    myLevelChangedForm.listBox1.Items.Add(myLvl.Name);
            }
        }
    }
}
