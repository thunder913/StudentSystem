using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemWinForms.Models;

namespace StudentSystemWinForms.Views
{
    public sealed partial class OtherView : ViewBase
    {
        private OtherViewModel _model;

        public OtherView(OtherViewModel model = null)
        {
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new OtherViewModel();
            }

            InitializeComponent();

            PerformBinding();
        }
        
        public sealed override void PerformBinding()
        {
            lblOtherFunText.DataBindings.Add("Text", _model, nameof(_model.OtherFunText), false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
