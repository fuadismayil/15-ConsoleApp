using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;

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
            throw new NotImplementedException();
        }

        public CourseGroup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Update(int id, CourseGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
