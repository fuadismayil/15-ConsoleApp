using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System.Runtime.InteropServices;

namespace ServiceLayer.Services.Implementations
{
    public class CourseGroupService : ICourseGroupService
    {
        private CourseGroupRepository _courseGroupRepository;
        private int _count = 1;
        public CourseGroupService()
        {
            _courseGroupRepository = new CourseGroupRepository();
        }
        public CourseGroup Create(CourseGroup courseGroup)
        {
            courseGroup.Id = _count;
            _courseGroupRepository.Create(courseGroup);
            _count++;
            return courseGroup;


        }
        public void Delete(int id)
        {
            CourseGroup courseGroup = GetById(id);
            _courseGroupRepository.Delete(courseGroup);
        }
        public List<CourseGroup> GetAll()
        {
            return _courseGroupRepository.GetAll();
        }
        public List<CourseGroup> GetAllByRoom(int room)
        {
            return _courseGroupRepository.GetAll(g => g.Room == room);
        }
        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            return _courseGroupRepository.GetAll(g => g.Teacher.ToUpper() == teacher.ToUpper());
        }
        public CourseGroup GetById(int id)
        {
            CourseGroup courseGroup = _courseGroupRepository.Get(g=>g.Id==id);
            if(courseGroup is null) return null;
            return courseGroup;
        }
        public List<CourseGroup> Search(string name)
        {
            return _courseGroupRepository.GetAll(g => g.Name.ToLower() == name.ToLower().Trim());
        }
        public CourseGroup Update(int id, CourseGroup courseGroup)
        {
            CourseGroup dbCourseGroup = GetById(id);
            if (dbCourseGroup is null) return null;
            courseGroup.Id = id;
            _courseGroupRepository.Update(courseGroup);
            return GetById(id);
        }

    }
}
