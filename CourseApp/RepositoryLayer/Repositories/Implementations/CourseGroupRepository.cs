using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories.Implementations
{
    public class CourseGroupRepository : IRepository<CourseGroup>
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
                Console.WriteLine($"An error occurred while creating the course group: {ex.Message}");
            }
        }

        public void Delete(CourseGroup data)
        {
            AppDbContext<CourseGroup>.datas.Remove(data);
        }

        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.Find(predicate) : null;
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate = null)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : AppDbContext<CourseGroup>.datas;
        }

        public void Update(CourseGroup data)
        {
            CourseGroup dbCourseGroup = Get(courseGroup => courseGroup.Id == data.Id);
            dbCourseGroup.Name = data.Name;
            dbCourseGroup.Teacher = data.Teacher;
            dbCourseGroup.Room = data.Room;
        }
    }
}