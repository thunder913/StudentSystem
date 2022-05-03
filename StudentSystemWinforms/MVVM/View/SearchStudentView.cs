using StudentSystemCommon.MVVM.Model;
using StudentSystemWinForms.MVVM.ViewModel;
using StudentSystemWinForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            searchBox.DataBindings.Add("Text", _model, nameof(_model.SearchWord), false, DataSourceUpdateMode.OnPropertyChanged);

            searchResult.Columns.Add("Faculty Number", 88,HorizontalAlignment.Left);
            searchResult.Columns.Add("Name", 88, HorizontalAlignment.Right);
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

            searchBox.GotFocus += (sender, e) => _model.RemoveText(sender, e);
            searchBox.LostFocus += (sender, e) => _model.AddText(sender, e);
            searchButton.Click += (sender, e) => _model.Search();

            searchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            searchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchBox.AutoCompleteCustomSource = _model.AutoCompleteCollection;

            searchBox.KeyDown += (sender, e) => _model.HandleKeyPressed(sender, e);
        }
    }
}
