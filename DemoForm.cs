using System;
using System.Windows.Forms;
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
            MultiScaleCopyForm myForm = new MultiScaleCopyForm();
            myForm.AttachAsTopLevelForm(MyAddin.s_addin, false);
            myForm.Show();
        }
        public static void ToolSettings(string unparsed)
        {
            NoteCoordForm myForm = new NoteCoordForm();
            myForm.AttachToToolSettings(MyAddin.s_addin);
            myForm.Show();
        }
    }
}
