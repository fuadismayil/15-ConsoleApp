using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Student not found!");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the student: {ex.Message}");
            }
        }
        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }
        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }
        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }
        public void Update(Student data)
        {
            Student dbStudent = Get(student => student.Id == data.Id);

            if (dbStudent != null)
            {
                dbStudent.Name = data.Name;
                dbStudent.Surname = data.Surname;
                dbStudent.Age = data.Age;
                dbStudent.CourseGroup = data.CourseGroup;
            }
        }
    }
}