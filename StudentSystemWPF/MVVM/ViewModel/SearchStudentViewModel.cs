using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.MVVM.Model.DB;
using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System;

namespace StudentSystem.MVVM.ViewModel
{
    internal class SearchStudentViewModel : ObservableObject, IViewModelSuggestions
    {
        #region PrivateProperties
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
        #endregion
        #region PublicProperties
        public ICommand SearchCommand { get; set; }
        public StudentSearchSuggestion SuggestionEntry
        {
            get => _suggestionEntry;
            set
            {
                if (!_allSuggestions.Contains(value) && IsCycling
                 || _suggestions == null
                 || !_suggestions.Any())
                {
                    IsCycling = false;
                    SuggestionIndex = -1;
                }
                _suggestionEntry = value;
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.FacultyNumber != null && !IsCycling)
                        Suggestions = _allSuggestions.Where(s => s.FacultyNumber.Contains(_suggestionEntry.FacultyNumber)).ToList();
                    if (_suggestionEntry.SelectedFacultyNumber != null)
                    {
                       BestSuggestion = _suggestionEntry;
                        this.Search();
                    }
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

        public ICommand CycleSuggestionCommand { get; set; }
        public int SuggestionIndex { get; set; }
        public bool IsCycling { get; set; }
        #endregion
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
            CycleSuggestionCommand = new CycleSuggestionCommand(this);
        }
        #region Methods
        public void Search()
        {
            var facNumber = this.SuggestionEntry.FacultyNumber;
            var students = this._studentService.SearchStudentsByFacultyNumber(facNumber);
            this.StudentsResults.Clear();
            foreach (var item in students)
            {
                this.StudentsResults.Add(new StudentSearchResult() { FacultyNumber = item.FacultyNumber, Name = item.FirstName + " " + item.LastName });
            }
            if (students.Count > 0 && !string.IsNullOrWhiteSpace(facNumber))
            {
                _suggestionFileManager.AddStudentSearchSuggestion(new StudentSearchSuggestion() { FacultyNumber = facNumber });
                _allSuggestions = _suggestionFileManager.GetStudentSearchSuggestion();
            }
        }

        public void ExecuteCycleSuggestions(object parameter)
        {
            if (!_suggestions.Any()) return;
            int index = SuggestionIndex + int.Parse((string)parameter);
            index = index % Math.Min(UserInfo.CurrentUser.Settings.SuggestionsCount, _suggestions.Count);
            IsCycling = true;
            if (index < 0)
                index = _suggestions.Count - 1;
            SuggestionEntry = _suggestions[index];
            SuggestionIndex = index;
            BestSuggestion = _suggestions[index];
        }
        #endregion
    }
}
