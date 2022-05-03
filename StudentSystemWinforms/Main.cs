using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemWinForms.Models;
using StudentSystemWinForms.MVVM.View;
using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemWinForms.Views;

namespace StudentSystemWinForms
{
    public partial class Main : Form
    {
        private ViewBase _view;      
        private ViewModelBase _model;
        public void SwapView(ViewBase view = null)
        {
            if (view != null)
            {
                this.Controls.Remove(_view);

                if (view is LoginView)
                {
                    _model = new LoginViewModel();
                    _view = new LoginView(_model as LoginViewModel);
                }

                if (view is MainView)
                {
                    _model = new MainViewModel();
                    _view = new MainView(_model as MainViewModel);
                }
            }
            else
            {
                _model = new LoginViewModel();
                _view = new LoginView(_model as LoginViewModel);
            }

            this.Controls.Add(_view);

        }

        public Main(ViewBase view = null)
        {
            SwapView(new LoginView());

            InitializeComponent();
        }
        
        private void btnLoadExampleView_Click(object sender, EventArgs e)
        {
            SwapView(new LoginView());
        }

        private void btnLoadOtherView_Click(object sender, EventArgs e)
        {
            SwapView(new OtherView());
        }
    }
}
