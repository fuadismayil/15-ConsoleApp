using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupService _groupService = new();
            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group\n2 - Get Group\n3 - Get All Groups\n4 - Delete Group\n5 - Update Group\n");

            while (true) {
                SelectOption: string selectOption = Console.ReadLine();
                int selectNumber;
                bool isSelectOption=int.TryParse(selectOption, out selectNumber);

                if (isSelectOption)
                {
                    switch(selectNumber)
                    {
                        case 1:
                            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Name");
                            string groupName = Console.ReadLine();
                            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Teacher Name");
                            string teacherName = Console.ReadLine();
                            EnterRoom:
                            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Room");
                            string groupRoom= Console.ReadLine();
                            int room;
                            bool isRoom=int.TryParse(groupRoom, out room);
                            if (isRoom)
                            {
                                CourseGroup group = new CourseGroup { Name=groupName, Teacher=teacherName,Room=room };
                                var result = _groupService.Create(group);
                                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Room : {group.Room}");
                                goto SelectOption;
                            }
                            else
                            {
                                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct room type!");
                                goto EnterRoom;
                            }

                                break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct option type!");
                    goto SelectOption;
                }
            }
        }
    }
}