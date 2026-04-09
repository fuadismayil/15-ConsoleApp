using CourseApp.Helpers;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group\n2 - Get Group\n3 - Get All Groups\n4 - Delete Group\n5 - Update Group\n");
        }
    }
}