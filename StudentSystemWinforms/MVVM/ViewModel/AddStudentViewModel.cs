using StudentSystemCommon.DAL;
using StudentSystemWinForms.Models;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public class AddStudentViewModel : ViewModelBase
    {
        private StudentService studentService;
        private string _suggestedFacultyNumber;
        private List<StudentAddSuggestion> _suggestions;
        private SuggestionFileManager _suggestionFileManager;
        public AutoCompleteStringCollection AutoCompleteCollection { get; set; }

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

        internal void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var textBox = sender as TextBox;
                SuggestedFacultyNumber = textBox.Text;
                if (AutoCompleteCollection.Contains(textBox.Text))
                {
                    var suggestion = _suggestions.FirstOrDefault(x => x.FacultyNumber == textBox.Text);
                    FillTextBoxData(suggestion);
                }
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
        public string SuggestedFacultyNumber
        {
            get { return _suggestedFacultyNumber; }
            set
            {
                _suggestedFacultyNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SuggestedFacultyNumber)));
            }
        }

        public AddStudentViewModel()
        {
            _suggestionFileManager = new SuggestionFileManager();
            _suggestions = _suggestionFileManager.GetStudentAddSuggestions();
            AutoCompleteCollection = new AutoCompleteStringCollection();
            AutoCompleteCollection.AddRange(_suggestions.Select(x => x.FacultyNumber).ToArray());
            studentService = new StudentService(new StudentContext());
        }

        public void AddStudentClicked()
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
            studentService.AddStudent(Specialty, int.Parse(Stream), int.Parse(Course), int.Parse(Group), FacultyNumber, FirstName, LastName, MiddleName, PhoneNumber, Email, Faculty);
            _suggestions = _suggestionFileManager.GetStudentAddSuggestions();
            //TODO make all the necessary checks whether the student is already in the database and all the data is correct
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
    }
}
