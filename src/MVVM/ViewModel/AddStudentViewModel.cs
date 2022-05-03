using StudentSystem.MVVM.ViewModel.Command;
using StudentSystemCommon.Core;
using StudentSystemCommon.DAL;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSystem.MVVM.ViewModel
{
    internal class AddStudentViewModel : ObservableObject, IViewModel
    {
        private StudentService studentService { get; set; }
        public ICommand AddCommand { get; set; }
        private IViewModel _currentViewModel;
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
            studentService = new StudentService(new StudentContext());
        }

        public void AddStudent()
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
            studentService.AddStudent(SuggestionEntry.Specialty, int.Parse(SuggestionEntry.Stream), int.Parse(SuggestionEntry.Course), int.Parse(SuggestionEntry.Group), SuggestionEntry.FacultyNumber, SuggestionEntry.FirstName, SuggestionEntry.LastName, SuggestionEntry.MiddleName, SuggestionEntry.PhoneNumber, SuggestionEntry.Email, SuggestionEntry.Faculty);
            //TODO make all the necessary checks whether the student is already in the database and all the data is correct
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
