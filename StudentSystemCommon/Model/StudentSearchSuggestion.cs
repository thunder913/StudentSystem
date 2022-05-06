using StudentSystemCommon.Core;

namespace StudentSystemCommon.MVVM.Model
{
    public class StudentSearchSuggestion : ObservableObject
    {
        private string _facultyNumber;
        private string _selectedFacultyNumber;
        private string _firstName;
        private string _lastName;
        public string FacultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; OnPropertyChanged(); }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string SelectedFacultyNumber
        {
            get { return _selectedFacultyNumber; }
            set { _selectedFacultyNumber = value; OnPropertyChanged(); }
        }

        public StudentSearchSuggestion(string facultyNumber, string firstName, string lastName)
        {
            _facultyNumber = facultyNumber;
            _firstName = firstName;
            _lastName = lastName;
        }

        public StudentSearchSuggestion()
        {
            
        }
    }
}
