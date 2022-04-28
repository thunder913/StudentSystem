using StudentSystem.MVVM.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DAL
{
    public class StudentService
    {
        private readonly StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public List<Student> GetStudentsByFacNumber(List<string> facultyNumbers)
        {
            return _studentContext.Students.Where(s => facultyNumbers.Contains(s.FacultyNumber)).ToList();
        }

        public void AddStudent(string specialty, int stream, int course, int group, string facultyNumber, string firstName, string lastName, string middleName, string phoneNumber, string email, string faculty)
        {
            _studentContext.Students.Add(new Student
            {
                Specialty = specialty,
                FacultyNumber = facultyNumber,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                PhoneNumber = phoneNumber,
                Email = email,
                Faculty = faculty,
                Stream = stream,
                Course = course,
                Group = group
            });
            _studentContext.SaveChanges();
        }
    }
}
