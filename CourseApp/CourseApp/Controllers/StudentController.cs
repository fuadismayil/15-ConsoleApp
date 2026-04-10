using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        public CourseGroupService _courseGroupService = new();
        public StudentService _studentService = new();

        public void Create()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group ID:");
            string courseGroupId = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(courseGroupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group ID cant be empty!");
                goto EnterId;
            }
            int id;
            bool isCourseGroupId = int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {
                var group = _courseGroupService.GetById(id);
                if (group == null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, $"No group found with ID {id}. Please try again.");
                    goto EnterId;
                }
            AddName: Helper.PrintConsole(ConsoleColor.Blue, "Add student name:");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student name cannot be empty.");
                    goto AddName;
                }
            AddSurname: Helper.PrintConsole(ConsoleColor.Blue, "Add student surname:");
                string surname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(surname))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student surname cannot be empty.");
                    goto AddSurname;
                }
            AddAge: Helper.PrintConsole(ConsoleColor.Blue, "Add student age:");
                string studentAge = Console.ReadLine();
                int age;
                bool isStudentAge = int.TryParse(studentAge, out age);
                if (!isStudentAge || age <= 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid age.");
                    goto AddAge;
                }
                else
                {
                    Student student = new Student
                    {
                        Name = name,
                        Surname = surname,
                        Age = age
                    };
                    var result = _studentService.Create(id, student);
                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup.Name}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Failed to create student.");
                    }
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterId;
            }
        }
        public Student Update()
        {
        EnterStudentId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Student ID to update:");
            string studentIdStr = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(studentIdStr))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student ID cant be empty!");
                goto EnterStudentId;
            }
            int studentId;
            if (!int.TryParse(studentIdStr, out studentId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterStudentId;
            }
            var existingStudent = _studentService.GetById(studentId);
            if (existingStudent == null)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"No student found with ID {studentId}.");
                goto EnterStudentId;
            }

        EnterGroupId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the new Group ID:");
            string courseGroupId = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(courseGroupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group ID cant be empty!");
                goto EnterGroupId;
            }
            int groupId;
            if (!int.TryParse(courseGroupId, out groupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterGroupId;
            }
            var group = _courseGroupService.GetById(groupId);
            if (group == null)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"No group found with ID {groupId}.");
                goto EnterGroupId;
            }

        AddName: Helper.PrintConsole(ConsoleColor.Blue, "Add new student name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student name cannot be empty.");
                goto AddName;
            }
        AddSurname: Helper.PrintConsole(ConsoleColor.Blue, "Add new student surname:");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student surname cannot be empty.");
                goto AddSurname;
            }
        AddAge: Helper.PrintConsole(ConsoleColor.Blue, "Add new student age:");
            string studentAge = Console.ReadLine().Trim();
            int age;
            if (!int.TryParse(studentAge, out age) || age <= 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid age.");
                goto AddAge;
            }

            Student updatedStudent = new Student
            {
                Name = name,
                Surname = surname,
                Age = age,
                CourseGroup = group
            };

            var result = _studentService.Update(studentId, updatedStudent);
            if (result != null)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Student updated - ID : {result.Id} , Name : {result.Name} , Surname : {result.Surname}, Age : {result.Age}, Group : {result.CourseGroup.Name}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Failed to update student.");
            }
            return result;
        }
        public Student GetById()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Student ID:");
            string idStr = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student ID cant be empty!");
                goto EnterId;
            }
            int id;
            if (int.TryParse(idStr, out id))
            {
                var student = _studentService.GetById(id);
                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup?.Name}");
                    return student;
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
                    goto EnterId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterId;
            }
        }
        public void Delete()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Student ID to delete:");
            string idStr = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student ID cant be empty!");
                goto EnterId;
            }
            int id;
            if (int.TryParse(idStr, out id))
            {
                var student = _studentService.GetById(id);
                if (student != null)
                {
                    _studentService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, "Student successfully deleted.");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
                    goto EnterId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterId;
            }
        }
        public List<Student> GetAllByAge()
        {
        EnterAge: Helper.PrintConsole(ConsoleColor.Blue, "Enter student age:");
            string ageStr = Console.ReadLine().Trim();
            int age;
            if (!int.TryParse(ageStr, out age) || age <= 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid age.");
                goto EnterAge;
            }

            var students = _studentService.GetAllByAge(age);
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup?.Name}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No students found with this age.");
            }
            return students;
        }
        public List<Student> GetAllByCourseGroupId()
        {
        EnterGroupId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group ID:");
            string groupIdStr = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(groupIdStr))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group ID cant be empty!");
                goto EnterGroupId;
            }
            int id;
            if (int.TryParse(groupIdStr, out id))
            {
                var students = _studentService.GetAllByCourseGroupId(id);
                if (students.Count > 0)
                {
                    foreach (var student in students)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup?.Name}");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No students found in this group.");
                }
                return students;
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Id type!");
                goto EnterGroupId;
            }
        }
        public List<Student> Search()
        {
        EnterSearchText: Helper.PrintConsole(ConsoleColor.Blue, "Enter search text:");
            string searchText = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Search text cannot be empty.");
                goto EnterSearchText;
            }

            var students = _studentService.Search(searchText);
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup?.Name}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No students found matching your search.");
            }
            return students;
        }
        public List<Student> GetAll()
        {
            var students = _studentService.GetAll();
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Student ID : {student.Id} , Name : {student.Name} , Surname : {student.Surname}, Age : {student.Age}, Group : {student.CourseGroup?.Name}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No students found.");
            }
            return students;
        }
    }
}