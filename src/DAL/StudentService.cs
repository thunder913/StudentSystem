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
    }
}
