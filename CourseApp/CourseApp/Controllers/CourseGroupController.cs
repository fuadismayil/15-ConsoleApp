using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;

namespace CourseApp.Controllers
{
    public class CourseGroupController
    {
        CourseGroupService _courseGroupService = new();

        public void Create()
        {
        EnterName:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Name");
            string courseGroupName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(courseGroupName))
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
            string courseGroupRoom = Console.ReadLine().Trim();
            int room;
            bool isRoom = int.TryParse(courseGroupRoom, out room);
            if (isRoom)
            {
                CourseGroup courseGroup = new CourseGroup { Name = courseGroupName, Teacher = teacherName, Room = room };
                var result = _courseGroupService.Create(courseGroup);
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {courseGroup.Id}, Name : {courseGroup.Name}, Teacher: {courseGroup.Teacher}, Room : {courseGroup.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct room type!");
                goto EnterRoom;
            }
        }
        public void GetById()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to get");
            string courseGroupId = Console.ReadLine().Trim();
            int id;
            bool isCourseGroupId = int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {
                CourseGroup courseGroup = _courseGroupService.GetById(id);
                if (courseGroup is null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {courseGroup.Id}, Name : {courseGroup.Name}, Teacher: {courseGroup.Teacher}, Room : {courseGroup.Room}");
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
            List<CourseGroup> courseGroups = _courseGroupService.GetAll();
            if (courseGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found!");
                return;

            }
            else
            {
                foreach (var courseGroup in courseGroups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {courseGroup.Id}, Name : {courseGroup.Name}, Teacher: {courseGroup.Teacher}, Room : {courseGroup.Room}");
                }
            }
        }
        public void Delete()
        {
        EnterId:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group Id you want to delete");
            string courseGroupId = Console.ReadLine().Trim();
            int id;
            bool isCourseGroupId = int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {
                CourseGroup courseGroup = _courseGroupService.GetById(id);
                if (courseGroup is null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto EnterId;
                }
                else
                {
                    _courseGroupService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, $"[{courseGroup.Name}] deleted successfully!");
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
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Teacher Name to get all groups by same teacher");
            string teacherName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid teacher name!");
                return;
            }

            List<CourseGroup> courseGroups = _courseGroupService.GetAllByTeacher(teacherName);
            if (courseGroups == null || courseGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"No groups found for teacher \"{teacherName}\"!");
                return;
            }

            foreach (var courseGroup in courseGroups)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {courseGroup.Id}, Name : {courseGroup.Name}, Teacher: {courseGroup.Teacher}, Room : {courseGroup.Room}");
            }
        }
        public void GetAllByRoom()
        {
        EnterRoom:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter the Room to get all groups by same room");
            string courseGroupRoom = Console.ReadLine().Trim();
            int room;
            bool isCourseGroupRoom = int.TryParse(courseGroupRoom, out room);

            if (isCourseGroupRoom)
            {
                List<CourseGroup> courseGroups = _courseGroupService.GetAllByRoom(room);

                if (courseGroups == null || courseGroups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, $"No groups found in room {room}!");
                    return;
                }

                foreach (var courseGroup in courseGroups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {courseGroup.Id}, Name : {courseGroup.Name}, Teacher: {courseGroup.Teacher}, Room : {courseGroup.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Room type!");
                goto EnterRoom;
            }
        }
        public void Search()
        {

        EnterName: Helper.PrintConsole(ConsoleColor.Blue, "Enter Group name you want to search: ");
            string search = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.PrintConsole(ConsoleColor.Red, "It cant be empty!");
                goto EnterName;
            }

            var results = _courseGroupService.Search(search);
            if (results.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
            }
            else
            {
                results.ForEach(g => Helper.PrintConsole(ConsoleColor.Green, $"ID: {g.Id} | Name: {g.Name}"));
            }

        }
        public void Update()
        {
        EnterId: Helper.PrintConsole(ConsoleColor.Blue, "Enter the Group ID you want to update");
            string courseGroupId = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(courseGroupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groupt ID cant be empty!");
                goto EnterId;
            }
            int id;
            bool isCourseGroupId = int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {
                CourseGroup findCourseGroup = _courseGroupService.GetById(id);
                if (findCourseGroup is null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto EnterId;
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $"Current Name : {findCourseGroup.Name} , Enter new name if you want to change it:");
                    string courseGroupNewName = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(courseGroupNewName)) findCourseGroup.Name = courseGroupNewName;
                    Helper.PrintConsole(ConsoleColor.Yellow, $"Current Teacher : {findCourseGroup.Teacher} , Enter new teacher if you want to change it:");
                    string courseGroupNewTeacher = Console.ReadLine().Trim();
                EnterRoom: Helper.PrintConsole(ConsoleColor.Yellow, $"Current Room : {findCourseGroup.Room} , Enter new room if you want to change it:");
                    string courseGroupNewRoom = Console.ReadLine().Trim();
                    int courseGroupOldRoom = findCourseGroup.Room;
                    if (!string.IsNullOrWhiteSpace(courseGroupNewName))
                    {
                        bool isRoom = int.TryParse(courseGroupNewRoom, out int room);
                        if (!isRoom)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Please enter correct room type!");
                            goto EnterRoom;
                        }
                        CourseGroup courseGroup = new CourseGroup { Id = id, Name = courseGroupNewName, Teacher = courseGroupNewTeacher, Room = room };
                        var updateCourseGroup=_courseGroupService.Update(id,courseGroup);
                        if(updateCourseGroup is null)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Group not updated, try again!");
                        }
                        else { Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {updateCourseGroup.Id}, Name : {updateCourseGroup.Name}, Teacher: {updateCourseGroup.Teacher}, Room : {updateCourseGroup.Room} updated"); }
                    }
                    else { findCourseGroup.Room = courseGroupOldRoom; }
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct Group Id type!");
                goto EnterId;
            }

        }
    }
}