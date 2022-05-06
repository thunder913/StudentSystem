using StudentSystemCommon.DAL;
using StudentSystemWinForms.Models;
using StudentSystemCommon.MVVM.Model;
using StudentSystemCommon.MVVM.Model.DB;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public class SearchStudentViewModel : ViewModelBase
    {
        private StudentService _studentService;
        private SuggestionFileManager _suggestionFileManager;
        private List<StudentSearchSuggestion> _allSuggestions;
        private List<StudentSearchSuggestion> _suggestions;
        private KeyValuePair<object, string> _facultyNumberKeyPair;
        private string _bestSuggestion;
        private StudentSearchSuggestion _suggestionEntry;
        private StudentSearchResult _selectedStudent;
        private ListView listView { get; set; }
        private Student _student;
        private string _searchWord;
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
                    if (_suggestionEntry.SelectedFacultyNumber != null)
                    {
                        this.Search();
                        BestSuggestion = _suggestionEntry.FacultyNumber;
                    }
                }

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SuggestionEntry)));
            }
        }
        public List<StudentSearchSuggestion> Suggestions
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
                BestSuggestion = SuggestionEntry.FacultyNumber.Length >= inputLengthThreshold ? first.FacultyNumber : string.Empty;
            }
        }
        public string BestSuggestion
        {
            get => _bestSuggestion;
            set
            {
                _bestSuggestion = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(BestSuggestion)));
            }
        }

        public KeyValuePair<object, string> FacultyNumberKeyPair
        {
            get => _facultyNumberKeyPair;
            set
            {
                _facultyNumberKeyPair = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FacultyNumberKeyPair)));
            }
        }
        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Student)));
            }
        }
        public StudentSearchResult SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                this.Student = _studentService.GetStudent(value.FacultyNumber);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedStudent)));
            }
        }
        public ObservableCollection<StudentSearchResult> StudentsResults { get; set; } = new ObservableCollection<StudentSearchResult>();
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
        public string SearchWord
        {
            get => _searchWord;
            set
            {
                _searchWord = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SearchWord)));
            }
        }

        public SearchStudentViewModel(ListView listView)
        {
            _suggestionFileManager = new SuggestionFileManager();
            _allSuggestions = _suggestionFileManager.GetStudentSearchSuggestion();
            SuggestionEntry = new StudentSearchSuggestion();
            Suggestions ??= new List<StudentSearchSuggestion>();
            FacultyNumberKeyPair = new KeyValuePair<object, string>(_suggestionEntry, "FacultyNumber");
            _studentService = new StudentService(new StudentContext());
            this.listView = listView;
        }
        
        public void SelectedItemEvent(object sender)
        {
            var listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                var selectedItem = listView.SelectedItems[0];
                var student = _studentService.GetStudent(selectedItem.Text);
                FillSelectedData(student);
            }
        }
        
        public void Search()
        {
            var students = this._studentService.SearchStudentsByFacultyNumber(SuggestionEntry.FacultyNumber);
            this.listView.Items.Clear();
            foreach (var item in students)
            {
                var listViewItem = new ListViewItem(item.FacultyNumber, 0);
                listViewItem.SubItems.Add(item.FirstName + " " + item.LastName);
                this.listView.Items.Add(listViewItem);
            }
            if (students.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(this.SuggestionEntry.FacultyNumber))
                {
                    _suggestionFileManager.AddStudentSearchSuggestion(new StudentSearchSuggestion() { FacultyNumber = this.SuggestionEntry.FacultyNumber });
                    _allSuggestions = _suggestionFileManager.GetStudentSearchSuggestion();
                }
            }
        }

        private void FillSelectedData(Student student)
        {
            this.FacultyNumber = student.FacultyNumber;
            this.FirstName = student.FirstName;
            this.MiddleName = student.MiddleName;
            this.LastName = student.LastName;
            this.Faculty = student.Faculty;
            this.Specialty = student.Specialty;
            this.Course = student.Course.ToString();
            this.Group = student.Group.ToString();
            this.Stream = student.Stream.ToString();
            this.PhoneNumber = student.PhoneNumber;
            this.Email = student.Email;
        }
    }
}
