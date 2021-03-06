using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    public class AddStudentViewModel : ObservableObject, IViewModelSuggestions
    {
        #region PrivateProperties
        private readonly SuggestionFileManager _suggestionFileManager;
        private StudentService studentService { get; set; }
        private IViewModel _currentViewModel;
        private IViewModel _currentViewModelParent;
        private List<StudentAddSuggestion> _suggestions;
        private List<StudentAddSuggestion> _allSuggestions;
        private StudentAddSuggestion _bestSuggestion;
        private StudentAddSuggestion _suggestionEntry;
        private KeyValuePair<object, string> _suggestedFacultyNumberKeyPair;
        #endregion
        #region PublicProperties
        public ICommand AddCommand { get; set; }
        public ICommand SetSuggestionCommand { get; set; }
        public void SetStudentSuggestion()
        {
            var suggestion = studentService.GetStudentSuggestion(SuggestionEntry.SuggestedFacultyNumber);
            if (suggestion == null)
            {
                MessageBox.Show("Няма студент с такъв факултетен номер!", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SuggestionEntry = suggestion;
                _suggestionFileManager.AddStudentAddSuggestion(new StudentAddSuggestion()
                {
                    Specialty = SuggestionEntry.Specialty,
                    Stream = SuggestionEntry.Stream,
                    Course = SuggestionEntry.Course,
                    Email = SuggestionEntry.Email,
                    Faculty = SuggestionEntry.Faculty,
                    FacultyNumber = SuggestionEntry.FacultyNumber,
                    FirstName = SuggestionEntry.FirstName,
                    Group = SuggestionEntry.Group,
                    LastName = SuggestionEntry.LastName,
                    MiddleName = SuggestionEntry.MiddleName,
                    PhoneNumber = SuggestionEntry.PhoneNumber
                });
                _allSuggestions = _suggestionFileManager.GetStudentAddSuggestions();
            }
        }
        public StudentAddSuggestion SuggestionEntry
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
                if (_suggestionEntry != null && !IsCycling)
                {
                    if (_suggestionEntry.SuggestedFacultyNumber != null)
                        Suggestions = _allSuggestions.Where(s => s.FacultyNumber.Contains(_suggestionEntry.SuggestedFacultyNumber)).ToList();
                    if (_suggestionEntry.FacultyNumber != null)
                        AddSuggestion();
                }



                OnPropertyChanged();
            }
        }
        public List<StudentAddSuggestion> Suggestions
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
                BestSuggestion = new StudentAddSuggestion();
                BestSuggestion.SuggestedFacultyNumber = SuggestionEntry.SuggestedFacultyNumber.Length >= inputLengthThreshold ? first.FacultyNumber : string.Empty;
            }
        }
        public StudentAddSuggestion BestSuggestion
        {
            get => _bestSuggestion;
            set
            {
                _bestSuggestion = value;
                OnPropertyChanged();
            }
        }

        public KeyValuePair<object, string> SuggestedFacultyNumberKeyPair
        {
            get => _suggestedFacultyNumberKeyPair;
            set
            {
                _suggestedFacultyNumberKeyPair = value;
                OnPropertyChanged();
            }
        }

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
        public AddStudentViewModel()
        {
            _suggestionFileManager = new SuggestionFileManager();
            _allSuggestions = _suggestionFileManager.GetStudentAddSuggestions();
            SuggestionEntry = new StudentAddSuggestion();
            Suggestions ??= new List<StudentAddSuggestion>();
            SuggestedFacultyNumberKeyPair = new KeyValuePair<object, string>(_suggestionEntry, "SuggestedFacultyNumber");
            CurrentViewModelParent = this;
            CurrentViewModel = null;
            AddCommand = new AddStudentCommand(this);
            SetSuggestionCommand = new SetSuggestionCommand(this);
            studentService = new StudentService(new StudentContext());
            CycleSuggestionCommand = new CycleSuggestionCommand(this);
        }
        #region Methods
        public void AddStudent()
        {
            try
            {
                studentService.AddStudent(SuggestionEntry.Specialty, SuggestionEntry.Stream, SuggestionEntry.Course, SuggestionEntry.Group, SuggestionEntry.FacultyNumber, SuggestionEntry.FirstName, SuggestionEntry.LastName, SuggestionEntry.MiddleName, SuggestionEntry.PhoneNumber, SuggestionEntry.Email, SuggestionEntry.Faculty);
                AddSuggestion();
                MessageBox.Show("Успешно добави студент!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AddSuggestion()
        {
            _suggestionFileManager.AddStudentAddSuggestion(new StudentAddSuggestion()
            {
                Specialty = SuggestionEntry.Specialty,
                Stream = SuggestionEntry.Stream,
                Course = SuggestionEntry.Course,
                Email = SuggestionEntry.Email,
                Faculty = SuggestionEntry.Faculty,
                FacultyNumber = SuggestionEntry.FacultyNumber,
                FirstName = SuggestionEntry.FirstName,
                Group = SuggestionEntry.Group,
                LastName = SuggestionEntry.LastName,
                MiddleName = SuggestionEntry.MiddleName,
                PhoneNumber = SuggestionEntry.PhoneNumber
            });
            _allSuggestions = _suggestionFileManager.GetStudentAddSuggestions();
        }
        public bool CanExecute()
        {
            return SuggestionEntry != null
                   && !string.IsNullOrEmpty(SuggestionEntry.Faculty)
                   && !string.IsNullOrEmpty(SuggestionEntry.Course)
                   && !string.IsNullOrEmpty(SuggestionEntry.FacultyNumber)
                   && !string.IsNullOrEmpty(SuggestionEntry.FirstName)
                   && !string.IsNullOrEmpty(SuggestionEntry.LastName)
                   && !string.IsNullOrEmpty(SuggestionEntry.Group)
                   && !string.IsNullOrEmpty(SuggestionEntry.Email)
                   && !string.IsNullOrEmpty(SuggestionEntry.PhoneNumber)
                   && !string.IsNullOrEmpty(SuggestionEntry.Specialty)
                   && !string.IsNullOrEmpty(SuggestionEntry.Stream)
                   && !string.IsNullOrEmpty(SuggestionEntry.MiddleName);
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
