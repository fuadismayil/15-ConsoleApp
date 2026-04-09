

using DomainLayer.Entities;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);

        Group GetById(int id);
    }
}
