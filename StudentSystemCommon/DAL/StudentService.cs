﻿using StudentSystemCommon.MVVM.Model.DB;
using StudentSystemCommon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentSystemCommon.DAL
{
    public class StudentService
    {
        private readonly StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public Student GetStudent(string facultyNumber)
        {
            return _studentContext.Students.FirstOrDefault(s => s.FacultyNumber.ToLower() == facultyNumber.ToLower());
        }

        public List<Student> GetStudentsByFacNumber(List<string> facultyNumbers)
        {
            return _studentContext.Students
                .Where(s => facultyNumbers.Contains(s.FacultyNumber))
                .Take(UserInfo.CurrentUser.Settings.SuggestionsCount > 0 ? UserInfo.CurrentUser.Settings.SuggestionsCount : 5)
                .ToList();
        }

        public List<Student> SearchStudentsByFacultyNumber(string facultyNumber)
        {
            return _studentContext.Students
                .Where(s => s.FacultyNumber.ToLower().Contains(facultyNumber.ToLower()))
                .ToList();
        }
        public void AddStudent(string specialty, string stream, string course, string group, string facultyNumber, string firstName, string lastName, string middleName, string phoneNumber, string email, string faculty)
        {
            if (string.IsNullOrWhiteSpace(facultyNumber) || facultyNumber.Length < 5)
            {
                throw new ArgumentException("Невалиден факултетен номер!");
            }
            else if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Името не може да е празно!");
            }
            else if (string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentException("Презимето не може да е празно!");
            }
            else if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Фамилията не може да е празна!");
            }
            else if (string.IsNullOrWhiteSpace(faculty))
            {
                throw new ArgumentException("Факултетът не може да е празна!");
            }
            else if (string.IsNullOrWhiteSpace(specialty))
            {
                throw new ArgumentException("Специалността не може да е празна!");
            }
            else if (string.IsNullOrWhiteSpace(course) || !int.TryParse(course, out var courseParsed) || courseParsed < 1 || courseParsed > 10)
            {
                throw new ArgumentException("Курсът трябва да бъде число от 1 до 10!");
            }
            else if (string.IsNullOrWhiteSpace(group) || !int.TryParse(group, out var groupParsed) || groupParsed <= 0)
            {
                throw new ArgumentException("Групата трябва да бъде положително число!");
            }
            else if (string.IsNullOrEmpty(stream) || !int.TryParse(stream, out var streamParsed) || streamParsed <= 0)
            {
                throw new ArgumentException("Потокът трябва да бъде число!");
            }
            else if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 6)
            {
                throw new ArgumentException("Трябва да се въведе валиден телефонен номер!");
            }
            else if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                throw new ArgumentException("Трябва да се въведе валиден имейл!");
            }
            
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
                Stream = int.Parse(stream),
                Course = int.Parse(course),
                Group = int.Parse(group)
            });
            _studentContext.SaveChanges();
        }
    }
}
