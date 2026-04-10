

using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        GroupService _groupService = new();

        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Name");
            string groupName = Console.ReadLine();
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Teacher Name");
            string teacherName = Console.ReadLine();
        EnterRoom:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Room");
            string groupRoom = Console.ReadLine();
            int room;
            bool isRoom = int.TryParse(groupRoom, out room);
            if (isRoom)
            {
                CourseGroup group = new CourseGroup { Name = groupName, Teacher = teacherName, Room = room };
                var result = _groupService.Create(group);
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher}, Room : {group.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct room type!");
                goto EnterRoom;
            }
        }
        public void GetById()
        {
            List<CourseGroup> groups = _groupService.GetAll();
            if (groups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found!");
                return;

            }
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to get");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup group = _groupService.GetById(id);
                if (group is null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher}, Room : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Group Id type!");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            List<CourseGroup> groups = _groupService.GetAll();
            if (groups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found!");
                return;

            }
            else
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher}, Room : {group.Room}");
                }
            }
        }
        public void Delete()
        {
            List<CourseGroup> groups = _groupService.GetAll();
            if (groups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found!");
                return;

            }
        EnterId:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to delete");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup group = _groupService.GetById(id);
                if (group is null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto EnterId;
                }
                else
                {
                    _groupService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, $"[{group.Name}] deleted successfully!");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Group Id type for deleting!");
                goto EnterId;
            }
        }
        public void GetAllByTeacher()
        {
            List<CourseGroup> groups1 = _groupService.GetAll();
            if (groups1.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found!");
                return;

            }
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Teacher Name to get all groups by same teacher");
            string teacherName = Console.ReadLine();
            
        }
    }
}
