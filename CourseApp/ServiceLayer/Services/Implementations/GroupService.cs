using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System.Runtime.InteropServices;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count = 1;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public CourseGroup Create(CourseGroup group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;


        }

        public void Delete(int id)
        {
            CourseGroup group=GetById(id);
            _groupRepository.Delete(group);
        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<CourseGroup> GetAllByRoom(int room)
        {
            return _groupRepository.GetAll(g => g.Room == room);
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            return _groupRepository.GetAll(g => g.Teacher.ToUpper() == teacher.ToUpper());
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup group = _groupRepository.Get(g=>g.Id==id);
            if(group is null) return null;
            return group;
        }

        public List<CourseGroup> SearchByName(string name)
        {
            return _groupRepository.GetAll(g => g.Name.ToLower() == name.ToLower().Trim());
        }

        public CourseGroup Update(int id, CourseGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
