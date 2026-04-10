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

            _count++;
            return student;
        }
    }
}
