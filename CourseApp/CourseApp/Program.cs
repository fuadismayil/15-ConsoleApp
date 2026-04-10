using CourseApp.Controllers;
using CourseApp.Helpers;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();

            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group\n2 - Get Group By ID\n3 - Get All Groups\n4 - Get All Groups By Teacher\n5 - Get All Groups By Room\n6 - Search Groups By Name\n7 - Delete Group By Id");

            while (true)
            {
            SelectOption: string selectOption = Console.ReadLine();
                int selectNumber;
                bool isSelectOption = int.TryParse(selectOption, out selectNumber);

                if (isSelectOption)
                {
                    switch (selectNumber)
                    {
                        case 1:
                            groupController.Create();
                            goto SelectOption;
                        case 2:
                            groupController.GetById();
                            goto SelectOption;
                        case 3:
                            groupController.GetAll();
                            goto SelectOption;
                        case 4:
                            groupController.GetAllByTeacher();
                            goto SelectOption;
                        case 5:
                            groupController.GetAllByRoom();
                            goto SelectOption;
                        case 6:
                            groupController.SearchByName();
                            goto SelectOption;
                        case 7:
                            groupController.Delete();
                            goto SelectOption;
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