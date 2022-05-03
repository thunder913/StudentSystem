using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemWinForms.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentSystemWinForms.MVVM.View
{
    public partial class MainView : ViewBase
    {
        private MainViewModel _model;
        public MainView(MainViewModel model = null)
        {
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new MainViewModel();
            }
            InitializeComponent();
            mainPanel.Controls.Add(new HomeView());
            PerformBinding();
        }

        public override void PerformBinding()
        {
        }

        private void AddStudentButtonClicked(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(new AddStudentView());
        }

        private void HomeButtonClicked(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(new HomeView());
        }

        private void SearchButtonClicked(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(new SearchStudentView());
        }
    }
}
