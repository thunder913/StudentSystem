using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemCommon.Utils;
using StudentSystemWinForms.Views;
using System.Windows.Forms;

namespace StudentSystemWinForms.MVVM.View
{
    public partial class HomeView : ViewBase
    {
        private HomeViewModel _model;        
        public HomeView(HomeViewModel model = null)
        {
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new HomeViewModel();
            }            
            InitializeComponent();
            PerformBinding();
        }

        public override void PerformBinding()
        {
            suggestionsCountBox.DataBindings.Add("Text", _model, nameof(_model.SuggestionCount), false, DataSourceUpdateMode.OnPropertyChanged);
            nameLabel.Text = UserInfo.CurrentUser.Username;
            saveButton.Click += (sender, e) => _model.ButtonClicked();
        }
    }
}
