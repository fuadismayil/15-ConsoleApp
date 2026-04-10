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
        public CourseGroupService _courseGroupService=new();
        public StudentService _studentService=new();
        public void Create()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group ID:");
            string courseGroupId = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(courseGroupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groupt ID cant be empty!");
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
                }else
                {
                    Student student = new Student
                    {
                        Name = name,
                        Surname = surname,
                        Age = age
                    };
                    var result = _studentService.Create(id, student);
                    if (result!=null)
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
    }
}
