

using DomainLayer.Entities;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICourseGroupService
    {
        CourseGroup Create(CourseGroup courseGroup);
        CourseGroup Update(int id, CourseGroup cousreGroup);
        void Delete(int id);
        CourseGroup GetById(int id);
        List<CourseGroup> GetAll();
        List<CourseGroup> GetAllByTeacher(string teacher);
        List<CourseGroup> GetAllByRoom(int room);
        List<CourseGroup> SearchByName(string name);
    }
}
