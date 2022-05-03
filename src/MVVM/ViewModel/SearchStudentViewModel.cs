using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.MVVM.Model.DB;
using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    internal class SearchStudentViewModel : ObservableObject, IViewModel
    {
        private StudentService _studentService;
        private SuggestionFileManager _suggestionFileManager;
        private List<StudentSearchSuggestion> _allSuggestions;
        private List<StudentSearchSuggestion> _suggestions;
        private KeyValuePair<object, string> _facultyNumberKeyPair;
        private StudentSearchSuggestion _bestSuggestion;
        private StudentSearchSuggestion _suggestionEntry;
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        private StudentSearchResult _selectedStudent;
        private Student _student;
        public ICommand SearchCommand { get; set; }
        public StudentSearchSuggestion SuggestionEntry
        {
            get => _suggestionEntry;
            set
            {
                _suggestionEntry = value;
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.FacultyNumber != null)
                        Suggestions = _allSuggestions.Where(s => s.FacultyNumber.Contains(_suggestionEntry.FacultyNumber)).ToList();
                }

                OnPropertyChanged();
            }
        }
        public List<StudentSearchSuggestion> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged();
                if (!_suggestions.Any())
                {
                    BestSuggestion = null;
                    return;
                }
                var first = _suggestions.First();
                var inputLengthThreshold =
                    UserInfo.CurrentUser == null ? 3 : UserInfo.CurrentUser.Settings.InputLengthThreshold;
                BestSuggestion = new StudentSearchSuggestion();
                BestSuggestion.FacultyNumber = SuggestionEntry.FacultyNumber.Length >= inputLengthThreshold ? first.FacultyNumber : string.Empty;
            }
        }
        public StudentSearchSuggestion BestSuggestion
        {
            get => _bestSuggestion;
            set
            {
                _bestSuggestion = value;
                OnPropertyChanged();
            }
        }

        public KeyValuePair<object, string> FacultyNumberKeyPair
        {
            get => _facultyNumberKeyPair;
            set
            {
                _facultyNumberKeyPair = value;
                OnPropertyChanged();
            }
        }
        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged();
            }
        }
        public StudentSearchResult SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                this.Student = _studentService.GetStudent(value.FacultyNumber);
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StudentSearchResult> StudentsResults { get; set; } = new ObservableCollection<StudentSearchResult>();
        public IViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public IViewModel CurrentViewModelParent
        {
            get => _currentViewModelParent;
            set
            {
                _currentViewModelParent = value;
                OnPropertyChanged();
            }
        }

        public SearchStudentViewModel() 
        {
            _suggestionFileManager = new SuggestionFileManager();
            _allSuggestions = _suggestionFileManager.GetStudentSearchSuggestion();
            SuggestionEntry = new StudentSearchSuggestion();
            Suggestions ??= new List<StudentSearchSuggestion>();
            FacultyNumberKeyPair = new KeyValuePair<object, string>(_suggestionEntry, "FacultyNumber");
            CurrentViewModelParent = this;
            CurrentViewModel = null;
            _studentService = new StudentService(new StudentContext());
            SearchCommand = new SearchCommand(this);
        }

        public void Search()
        {
            var facNumber = this.SuggestionEntry.FacultyNumber;
            var students = this._studentService.SearchStudentsByFacultyNumber(facNumber);
            this.StudentsResults.Clear();
            foreach (var item in students)
            {
                this.StudentsResults.Add(new StudentSearchResult() { FacultyNumber = item.FacultyNumber, Name = item.FirstName + " " + item.LastName });
            }
            if (students.Count > 0)
            {
                _suggestionFileManager.AddStudentSearchSuggestion(new StudentSearchSuggestion() { FacultyNumber = facNumber });
            }
        }
    }
}
