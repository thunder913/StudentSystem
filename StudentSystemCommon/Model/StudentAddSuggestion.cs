using StudentSystemCommon.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemCommon.MVVM.Model
{
    public class StudentAddSuggestion : ObservableObject
    {
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
        private string _suggestedFacultyNumber;

        public string SuggestedFacultyNumber
        {
            get => _suggestedFacultyNumber; set
            {
                _suggestedFacultyNumber = value;
                OnPropertyChanged();
            }
        }
        public string FacultyNumber
        {
            get => _facultyNumber; set
            {
                _facultyNumber = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => _firstName; set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string MiddleName
        {
            get => _middleName; set
            {
                _middleName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName; set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Faculty
        {
            get => _faculty; set
            {
                _faculty = value;
                OnPropertyChanged();
            }
        }
        public string Specialty
        {
            get => _specialty; set
            {
                _specialty = value;
                OnPropertyChanged();
            }
        }
        public string Course
        {
            get => _course; set
            {
                _course = value;
                OnPropertyChanged();
            }
        }
        public string Group
        {
            get => _group; set
            {
                _group = value;
                OnPropertyChanged();
            }
        }
        public string Stream
        {
            get => _stream; set
            {
                _stream = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email; set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public StudentAddSuggestion()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is StudentAddSuggestion other)
            {
                return FacultyNumber == other.FacultyNumber;
            }

            return false;
        }
    }
}
