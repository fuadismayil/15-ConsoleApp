using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories.Implementations
{
    public class GroupRepository : IRepository<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!");
                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the group: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
