using StudentSystemCommon.Controls;
using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemWinForms.Utils;
using StudentSystemWinForms.Views;
using System.Windows.Forms;

namespace StudentSystemWinForms.MVVM.View
{
    public partial class SearchStudentView : ViewBase
    {
        private SearchStudentViewModel _model;
        public SearchStudentView(SearchStudentViewModel model = null)
        {
            InitializeComponent();
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new SearchStudentViewModel(searchResult);
            }
            PerformBinding();
        }

        public override void PerformBinding()
        {

            searchResult.Columns.Add("Факултетен номер", 120,HorizontalAlignment.Left);
            searchResult.Columns.Add("Име", 120, HorizontalAlignment.Right);
            searchResult.ItemSelectionChanged += (sender, e) => _model.SelectedItemEvent(sender);
            
            facultyNumberBox.DataBindings.Add("Text", _model, nameof(_model.FacultyNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            nameBox.DataBindings.Add("Text", _model, nameof(_model.FirstName), false, DataSourceUpdateMode.OnPropertyChanged);
            familyBox.DataBindings.Add("Text", _model, nameof(_model.LastName), false, DataSourceUpdateMode.OnPropertyChanged);
            middleNameBox.DataBindings.Add("Text", _model, nameof(_model.MiddleName), false, DataSourceUpdateMode.OnPropertyChanged);
            facultyBox.DataBindings.Add("Text", _model, nameof(_model.Faculty), false, DataSourceUpdateMode.OnPropertyChanged);
            specialtyBox.DataBindings.Add("Text", _model, nameof(_model.Specialty), false, DataSourceUpdateMode.OnPropertyChanged);
            courseBox.DataBindings.Add("Text", _model, nameof(_model.Course), false, DataSourceUpdateMode.OnPropertyChanged);
            groupBox.DataBindings.Add("Text", _model, nameof(_model.Group), false, DataSourceUpdateMode.OnPropertyChanged);
            streamBox.DataBindings.Add("Text", _model, nameof(_model.Stream), false, DataSourceUpdateMode.OnPropertyChanged);
            phoneNumberBox.DataBindings.Add("Text", _model, nameof(_model.PhoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            emailBox.DataBindings.Add("Text", _model, nameof(_model.Email), false, DataSourceUpdateMode.OnPropertyChanged);
            
            var searchSuggest = (searchSuggestBox.Child as SuggestTextBox);
            SuggestionBoxBinderHelper.BindPropertiesToSuggestionBox(searchSuggest, _model, "Търси...", nameof(_model.BestSuggestion),
               nameof(_model.SuggestionEntry), nameof(_model.FacultyNumberKeyPair), nameof(_model.Suggestions), nameof(_model.CycleSuggestionCommand));

            searchButton.Click += (sender, e) => _model.Search();
        }
    }
}
