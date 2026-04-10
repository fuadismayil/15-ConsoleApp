

using DomainLayer.Entities;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        CourseGroup Create(CourseGroup group);
        CourseGroup Update(int id, CourseGroup group);
        void Delete(int id);

        CourseGroup GetById(int id);
    }
}
