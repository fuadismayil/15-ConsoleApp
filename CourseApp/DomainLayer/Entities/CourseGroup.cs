using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class CourseGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
    }
}