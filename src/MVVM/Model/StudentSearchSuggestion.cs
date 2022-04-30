using StudentSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.MVVM.Model
{
    public class StudentSearchSuggestion : ObservableObject
    {
        private string _facultyNumber;
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
