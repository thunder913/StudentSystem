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

namespace StudentSystemWinForms.MVVM.ViewModel
{
    public class SearchStudentViewModel : ViewModelBase
    {
        private const string DefaultSearchTerm = "Търси...";
        private string _searchWord;
        private StudentService _studentService;
        private SuggestionFileManager _suggestionFileManager;
        private List<StudentSearchSuggestion> _suggestions;
        public AutoCompleteStringCollection AutoCompleteCollection { get; set; }
        private ListView listView { get; set; }
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
        public string Stream
        {
            get => _stream; set
            {
                _stream = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Stream)));
            }
        }

        public void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var textBox = sender as TextBox;
                var facNumber = textBox.Text;
                if (AutoCompleteCollection.Contains(textBox.Text))
                {
                    var suggestion = _suggestions.FirstOrDefault(x => x.FacultyNumber == textBox.Text);
                    SearchWord = facNumber;
                    this.Search();
                }
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

        public void RemoveText(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == DefaultSearchTerm)
            {
                SearchWord = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((sender as TextBox).Text))
                SearchWord = DefaultSearchTerm;
        }

        internal void SelectedItemEvent(object sender)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var selectedItem = listView.SelectedItems[0];
                var student = _studentService.GetStudent(selectedItem.Text);
                FillSelectedData(student);
            }
        }

        public SearchStudentViewModel(ListView listView)
        {
            this.listView = listView;
            SearchWord = DefaultSearchTerm;
            _studentService = new StudentService(new StudentContext());
            _suggestionFileManager = new SuggestionFileManager();
            
            _suggestions = _suggestionFileManager.GetStudentSearchSuggestion();
            AutoCompleteCollection = new AutoCompleteStringCollection();
            AutoCompleteCollection.AddRange(_suggestions.Select(x => x.FacultyNumber).ToArray());
        }

        public void Search()
        {
            var students = this._studentService.SearchStudentsByFacultyNumber(SearchWord != DefaultSearchTerm ? SearchWord : null);
            this.listView.Items.Clear();
            foreach (var item in students)
            {
                var listViewItem = new ListViewItem(item.FacultyNumber, 0);
                listViewItem.SubItems.Add(item.FirstName + " " + item.LastName);
                this.listView.Items.Add(listViewItem);
            }
            if (students.Count > 0)
            {
                if (SearchWord != DefaultSearchTerm)
                {
                    _suggestionFileManager.AddStudentSearchSuggestion(new StudentSearchSuggestion() { FacultyNumber = SearchWord });
                    _suggestions = _suggestionFileManager.GetStudentSearchSuggestion();
                    AutoCompleteCollection.Clear();
                    AutoCompleteCollection.AddRange(_suggestions.Select(x => x.FacultyNumber).ToArray());
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
