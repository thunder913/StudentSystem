using System.ComponentModel.DataAnnotations;

namespace StudentSystem.MVVM.Model.DB
{
    public class Student
    {
        [Key]
        public string FacultyNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int Stream { get; set; }
        public decimal AverageGrade { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }   
    }
}
