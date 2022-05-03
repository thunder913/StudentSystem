using System.ComponentModel;
using System.Windows.Forms;
using StudentSystemWinForms.Interfaces;

namespace StudentSystemWinForms.Views
{
    [TypeDescriptionProvider(typeof(AbstractDescriptionProvider<StudentSystemWinForms.Views.ViewBase, System.Windows.Forms.UserControl>))]
    public abstract class ViewBase : UserControl, IView
    {
        public abstract void PerformBinding();
    }
}
