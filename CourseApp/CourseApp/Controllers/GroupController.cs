using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        GroupService _groupService = new();

        public void CheckGroupEmpty()
        {
            List<CourseGroup> groups1 = _groupService.GetAll();
            if (groups1.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not created or found!");
                return;

            }
        }
        public void Create()
        {
        EnterName:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Name");
            string groupName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(groupName))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group name cant be empty!");
                goto EnterName;
            }
        EnterTeacher:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Teacher Name");
            string teacherName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(teacherName))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group name cant be empty!");
                goto EnterTeacher;
            }
        EnterRoom:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Room");
            string groupRoom = Console.ReadLine().Trim();
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
            CheckGroupEmpty();
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to get");
            string groupId = Console.ReadLine().Trim();
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
            CheckGroupEmpty();
        EnterId:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to delete");
            string groupId = Console.ReadLine().Trim();
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
            CheckGroupEmpty();
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Teacher Name to get all groups by same teacher");
            string teacherName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid teacher name!");
                return;
            }

            List<CourseGroup> groups = _groupService.GetAllByTeacher(teacherName);
            if (groups == null || groups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"No groups found for teacher \"{teacherName}\"!");
                return;
            }

            foreach (var group in groups)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher}, Room : {group.Room}");
            }
        }
        public void GetAllByRoom()
        {
            CheckGroupEmpty();

        EnterRoom:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Room to get all groups by same room");
            string groupRoom = Console.ReadLine().Trim();
            int room;
            bool isGroupRoom = int.TryParse(groupRoom, out room);

            if (isGroupRoom)
            {
                List<CourseGroup> groups = _groupService.GetAllByRoom(room);

                if (groups == null || groups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, $"No groups found in room {room}!");
                    return;
                }

                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher}, Room : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Room type!");
                goto EnterRoom;
            }
        }
        public void SearchByName()
        {


        EnterName: Helper.PrintConsole(ConsoleColor.Blue, "Enter Group name you want to search: ");
            string search = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.PrintConsole(ConsoleColor.Red, "It cant be empty!");
                goto EnterName;
            }

            var results = _groupService.SearchByName(search);
            if (results.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
            }
            else
            {
                results.ForEach(g => Helper.PrintConsole(ConsoleColor.Green, $"ID: {g.Id} | Name: {g.Name}"));
            }

        }
    
        
    }
}