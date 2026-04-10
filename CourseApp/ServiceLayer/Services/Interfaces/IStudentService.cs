using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int courseGroupId, Student student);
        Student GetById(int id);
        void Delete(int id);
        List<Student> GetAllByAge(int age);
        List<Student> GetAllByCourseGroupId(int courseGroupId);
        List<Student> Search(string name);
        Student Update(int id, Student student);
        List<Student> GetAll();

    }
}