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
    public partial class AddStudentView : ViewBase
    {
        private AddStudentViewModel _model;
        public AddStudentView(AddStudentViewModel model = null)
        {
            if (model != null)
            {
                _model = model;
            }
            else
            {
                _model = new AddStudentViewModel();
            }
            InitializeComponent();
            PerformBinding();
        }

        public override void PerformBinding()
        {
            facultyNumberBox.DataBindings.Add("Text", _model, nameof(_model.FacultyNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            nameBox.DataBindings.Add("Text", _model, nameof(_model.FirstName), false, DataSourceUpdateMode.OnPropertyChanged);
            lastNameBox.DataBindings.Add("Text", _model, nameof(_model.LastName), false, DataSourceUpdateMode.OnPropertyChanged);
            middleNameBox.DataBindings.Add("Text", _model, nameof(_model.MiddleName), false, DataSourceUpdateMode.OnPropertyChanged);
            facultyBox.DataBindings.Add("Text", _model, nameof(_model.Faculty), false, DataSourceUpdateMode.OnPropertyChanged);
            specialtyBox.DataBindings.Add("Text", _model, nameof(_model.Specialty), false, DataSourceUpdateMode.OnPropertyChanged);
            courseBox.DataBindings.Add("Text", _model, nameof(_model.Course), false, DataSourceUpdateMode.OnPropertyChanged);
            groupBox.DataBindings.Add("Text", _model, nameof(_model.Group), false, DataSourceUpdateMode.OnPropertyChanged);
            streamBox.DataBindings.Add("Text", _model, nameof(_model.Stream), false, DataSourceUpdateMode.OnPropertyChanged);
            phoneNumberBox.DataBindings.Add("Text", _model, nameof(_model.PhoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            emailBox.DataBindings.Add("Text", _model, nameof(_model.Email), false, DataSourceUpdateMode.OnPropertyChanged);
            addButton.Click += (sender, e) => _model.AddStudentClicked();
            
            suggestedFacultyNumberBox.DataBindings.Add("Text", _model, nameof(_model.SuggestedFacultyNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            suggestedFacultyNumberBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            suggestedFacultyNumberBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            suggestedFacultyNumberBox.AutoCompleteCustomSource = _model.AutoCompleteCollection;

            suggestedFacultyNumberBox.KeyDown += (sender, e) => _model.HandleKeyPressed(sender, e);
        }
    }
}
