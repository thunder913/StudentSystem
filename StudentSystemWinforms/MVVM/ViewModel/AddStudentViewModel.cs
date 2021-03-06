using StudentSystemCommon.DAL;
using StudentSystemWinForms.Models;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Windows.Input;
using StudentSystem.MVVM.ViewModel;
using StudentSystemWinForms.MVVM.ViewModel.Command;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public class AddStudentViewModel : ViewModelBase, IViewModelSuggestions
    {
        #region PrivateProperties
        private StudentService studentService;
        private SuggestionFileManager _suggestionFileManager;
        private List<StudentAddSuggestion> _suggestions;
        private List<StudentAddSuggestion> _allSuggestions;
        private StudentAddSuggestion _bestSuggestion;
        private StudentAddSuggestion _suggestionEntry;
        private KeyValuePair<object, string> _suggestedFacultyNumberKeyPair;
        private string _bestSuggestionFacultyNumber;
        
        private string _facultyNumber;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private string _faculty;
        private string _specialty;
        private string _group;
        private string _course;
        private string _stream;
        #endregion
        #region PublicProperties
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
                if (_suggestionEntry != null)
                {
                    if (_suggestionEntry.SuggestedFacultyNumber != null && !IsCycling)
                        Suggestions = _allSuggestions.Where(s => s.FacultyNumber.Contains(_suggestionEntry.SuggestedFacultyNumber)).ToList();
                    if (_suggestionEntry.FacultyNumber != null)
                    {
                        FillTextBoxData(_suggestionEntry);
                        AddSuggestionToList();
                        BestSuggestion = _suggestionEntry;
                    }
                }

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SuggestionEntry)));
            }
        }
        public List<StudentAddSuggestion> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Suggestions)));
                if (!_suggestions.Any())
                {
                    BestSuggestion = null;
                    return;
                }
                var first = _suggestions.First();
                var inputLengthThreshold =
                    UserInfo.CurrentUser == null ? 3 : UserInfo.CurrentUser.Settings.InputLengthThreshold;
                BestSuggestion = new StudentAddSuggestion();
                BestSuggestion = SuggestionEntry.SuggestedFacultyNumber.Length >= inputLengthThreshold ? first : new StudentAddSuggestion();
            }
        }
        public StudentAddSuggestion BestSuggestion
        {
            get => _bestSuggestion;
            set
            {
                _bestSuggestion = value;
                BestSuggestionFacultyNumber = _bestSuggestion?.FacultyNumber;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(BestSuggestion)));
            }
        }
        
        public string BestSuggestionFacultyNumber
        {
            get => _bestSuggestionFacultyNumber;
            set
            {
                _bestSuggestionFacultyNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(BestSuggestionFacultyNumber)));
            }
        }
        
        public KeyValuePair<object, string> SuggestedFacultyNumberKeyPair
        {
            get => _suggestedFacultyNumberKeyPair;
            set
            {
                _suggestedFacultyNumberKeyPair = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SuggestedFacultyNumberKeyPair)));
            }
        }
        public string FacultyNumber
        {
            get => _facultyNumber; set
            {
                _facultyNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FacultyNumber)));
            }
        }
        public string FirstName
        {
            get => _firstName; set
            {
                _firstName = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        public string MiddleName
        {
            get => _middleName; set
            {
                _middleName = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(MiddleName)));
            }
        }
        public string LastName
        {
            get => _lastName; set
            {
                _lastName = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
        public string Faculty
        {
            get => _faculty; set
            {
                _faculty = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Faculty)));
            }
        }

        public void SetSuggestion()
        {
            var suggestion = studentService.GetStudentSuggestion(SuggestionEntry.SuggestedFacultyNumber);
            if (suggestion == null)
            {
                MessageBox.Show("Няма студент с такъв факултетен номер!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FillTextBoxData(suggestion);
                AddSuggestionToList();
            }
        }
        
        public string Specialty
        {
            get => _specialty; set
            {
                _specialty = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Specialty)));
            }
        }
        public string Course
        {
            get => _course; set
            {
                _course = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Course)));
            }
        }
        public string Group
        {
            get => _group; set
            {
                _group = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Group)));
            }
        }
        public string Stream
        {
            get => _stream; set
            {
                _stream = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Stream)));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                _phoneNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        }
        public string Email
        {
            get => _email; set
            {
                _email = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Email)));
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
            studentService = new StudentService(new StudentContext());
            SuggestionEntry = new StudentAddSuggestion();
            Suggestions ??= new List<StudentAddSuggestion>();
            SuggestedFacultyNumberKeyPair = new KeyValuePair<object, string>(_suggestionEntry, "SuggestedFacultyNumber");
            CycleSuggestionCommand = new CycleSuggestionCommand(this);
        }
        #region Methods
        
        public void AddStudentClicked()
        {
            try
            {
                studentService.AddStudent(Specialty, Stream, Course, Group, FacultyNumber, FirstName, LastName, MiddleName, PhoneNumber, Email, Faculty);
                AddSuggestionToList();
                MessageBox.Show("Успешно добави студент!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillTextBoxData(StudentAddSuggestion suggestion)
        {
            FacultyNumber = suggestion.FacultyNumber;
            FirstName = suggestion.FirstName;
            MiddleName = suggestion.MiddleName;
            LastName = suggestion.LastName;
            PhoneNumber = suggestion.PhoneNumber;
            Email = suggestion.Email;
            Faculty = suggestion.Faculty;
            Specialty = suggestion.Specialty;
            Course = suggestion.Course;
            Group = suggestion.Group;
            Stream = suggestion.Stream;
        }
        
        private void AddSuggestionToList()
        {
            _suggestionFileManager.AddStudentAddSuggestion(new StudentAddSuggestion()
            {
                Specialty = Specialty,
                Faculty = Faculty,
                FacultyNumber = FacultyNumber,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Group = Group,
                Stream = Stream,
                Course = Course
            });
            _allSuggestions = _suggestionFileManager.GetStudentAddSuggestions();
        }

        void IViewModelSuggestions.ExecuteCycleSuggestions(object parameter)
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
