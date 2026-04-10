using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private CourseGroupRepository _courseGroupRepository;
        private StudentRepository _studentRepository;
        private int _count = 1;

        public StudentService()
        {
            _courseGroupRepository = new CourseGroupRepository();
            _studentRepository = new StudentRepository();
        }

        public Student Create(int courseGroupId, Student student)
        {
            var courseGroup = _courseGroupRepository.Get(g => g.Id == courseGroupId);
            if (courseGroup is null) return null;

            student.Id = _count;
            student.CourseGroup = courseGroup;
            _studentRepository.Create(student);

            _count++;
            return student;
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            if (student != null)
            {
                _studentRepository.Delete(student);
            }
        }

        public List<Student> GetAllByAge(int age)
        {
            return _studentRepository.GetAll(s => s.Age == age);
        }

        public List<Student> GetAllByCourseGroupId(int courseGroupId)
        {
            return _studentRepository.GetAll(s => s.CourseGroup != null && s.CourseGroup.Id == courseGroupId);
        }

        public Student GetById(int id)
        {
            Student student = _studentRepository.Get(s => s.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> Search(string name)
        {
            return _studentRepository.GetAll(s => s.Name.ToLower() == name.ToLower().Trim());
        }

        public Student Update(int id, Student student)
        {
            Student dbStudent = GetById(id);
            if (dbStudent is null) return null;

            student.Id = id;
            _studentRepository.Update(student);

            return GetById(id);
        }
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
    }
}