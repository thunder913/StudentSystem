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
    public class AddStudentViewModel : ObservableObject, IViewModel
    {
        private StudentService studentService { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SetSuggestionCommand { get; set; }
        private IViewModel _currentViewModel;

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
        

        private IViewModel _currentViewModelParent;
        private List<StudentAddSuggestion> _suggestions;
        private List<StudentAddSuggestion> _allSuggestions;
        private readonly SuggestionFileManager _suggestionFileManager;
        private StudentAddSuggestion _bestSuggestion;
        private StudentAddSuggestion _suggestionEntry;
        private KeyValuePair<object, string> _suggestedFacultyNumberKeyPair;
        public StudentAddSuggestion SuggestionEntry
        {
            get => _suggestionEntry;
            set
            {
                _suggestionEntry = value;
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.SuggestedFacultyNumber != null)
                        Suggestions = _allSuggestions.Where(s => s.FacultyNumber.Contains(_suggestionEntry.SuggestedFacultyNumber)).ToList();
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
        }

        public void AddStudent()
        {
            try
            {
                studentService.AddStudent(SuggestionEntry.Specialty, SuggestionEntry.Stream, SuggestionEntry.Course, SuggestionEntry.Group, SuggestionEntry.FacultyNumber, SuggestionEntry.FirstName, SuggestionEntry.LastName, SuggestionEntry.MiddleName, SuggestionEntry.PhoneNumber, SuggestionEntry.Email, SuggestionEntry.Faculty);
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
                MessageBox.Show("Успешно добави студент!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
    }
}
