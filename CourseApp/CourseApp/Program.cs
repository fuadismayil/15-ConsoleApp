using CourseApp.Controllers;
namespace CourseApp
{
    public class Prooupam
    {
        static readonly ConsoleColor C_Title = ConsoleColor.Cyan;
        static readonly ConsoleColor C_Select = ConsoleColor.Black;
        static readonly ConsoleColor C_Normal = ConsoleColor.White;
        static readonly ConsoleColor C_Dim = ConsoleColor.DarkGray;
        static readonly ConsoleColor C_Accent = ConsoleColor.DarkCyan;
        static readonly ConsoleColor C_BgSel = ConsoleColor.Cyan;       
        static readonly string[] Logo =
        {
            @"  ██████╗ ██████╗ ██╗   ██╗██████╗ ███████╗███████╗ █████╗ ██████╗ ██████╗  ",
            @" ██╔════╝██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔════╝██╔══██╗██╔══██╗██╔══██╗ ",
            @" ██║     ██║   ██║██║   ██║██████╔╝███████╗█████╗  ███████║██████╔╝██████╔╝ ",
            @" ██║     ██║   ██║██║   ██║██╔══██╗╚════██║██╔══╝  ██╔══██║██╔═══╝ ██╔═══╝  ",
            @" ╚██████╗╚██████╔╝╚██████╔╝██║  ██║███████║███████╗██║  ██║██║     ██║      ",
            @"  ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝      ",
        };
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CourseGroupController groupController = new();
            StudentController studentController = new();
            PlayIntro();
            MainMenuLoop(groupController, studentController);
        }
        static void PlayIntro()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            Console.Clear();
            PrintDolphinStatic(2);
            PrintLogo();
            Thread.Sleep(2000);
        }
        static void PrintDolphinStatic(int topRow)
        {
            string[] d =
            {
                @" ",
                @" ",
                @" ",
                @" ",
                @" ",
            };
            int col = (Console.WindowWidth - 20) / 2;
            foreach (var line in d)
            {
                Console.WriteLine(line);
            }
        }
        static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var line in Logo)
            {
                int pad = Math.Max(0, (Console.WindowWidth - line.Length) / 2);
                Console.WriteLine(new string(' ', pad) + line);
            }
            Console.ResetColor();
        }
        static int RunMenu(string[] items, string header, int startRow)
        {
            int selected = 0;
            while (true)
            {
                Console.SetCursorPosition(0, startRow);
                Console.ForegroundColor = C_Dim;
                string h = $"  {header}";
                Console.WriteLine(h);
                Console.WriteLine(new string('─', Math.Min(Console.WindowWidth - 1, 60)));
                Console.ResetColor();
                for (int i = 0; i < items.Length; i++)
                {
                    string prefix = i == selected ? "  >  " : "     ";
                    if (i == selected)
                    {
                        Console.BackgroundColor = C_BgSel;
                        Console.ForegroundColor = C_Select;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = C_Normal;
                    }
                    string line = $"{prefix}{items[i]}";
                    line = line.PadRight(Math.Min(Console.WindowWidth - 1, 60));
                    Console.WriteLine(line);
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected = (selected - 1 + items.Length) % items.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selected = (selected + 1) % items.Length;
                        break;
                    case ConsoleKey.Enter:
                        return selected;
                }
            }
        }
        static void DrawHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int w = Console.WindowWidth;
            string title = "CourseApp";
            string bar = new string('═', Math.Min(w - 1, 70));
            Console.WriteLine(bar);
            int pad = Math.Max(0, (Math.Min(w - 1, 70) - title.Length) / 2);
            Console.WriteLine(new string(' ', pad) + title);
            Console.WriteLine(bar);
            Console.ResetColor();
            Console.WriteLine();
        }
        static void MainMenuLoop(CourseGroupController gc, StudentController sc)
        {
            string[] mainItems = { "GROUP SETTINGS", "STUDENT SETTINGS", "Exit" };
            while (true)
            {
                DrawHeader();
                int headerRows = 5;
                int choice = RunMenu(mainItems, "MAIN MENU", headerRows);
                switch (choice)
                {
                    case 0: GroupSettingsLoop(gc); break;
                    case 1: StudentSettingsLoop(sc); break;
                    case 2: ExitApp(); return;
                }
            }
        }
        static void GroupSettingsLoop(CourseGroupController gc)
        {
            string[] items =
            {
                "Create Group",
                "Get Group By ID",
                "Get All Groups",
                "Get All Groups By Teacher",
                "Get All Groups By Room",
                "Search Groups By Name",
                "Update Group",
                "Delete Group By ID",
                "← Back to Main Menu",
            };
            while (true)
            {
                DrawHeader();
                int choice = RunMenu(items, "GROUP SETTINGS", 5);
                if (choice == items.Length - 1) return;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n  ── {items[choice]} ──\n");
                Console.ResetColor();
                switch (choice)
                {
                    case 0: gc.Create(); break;
                    case 1: gc.GetById(); break;
                    case 2: gc.GetAll(); break;
                    case 3: gc.GetAllByTeacher(); break;
                    case 4: gc.GetAllByRoom(); break;
                    case 5: gc.Search(); break;
                    case 6: gc.Update(); break;
                    case 7: gc.Delete(); break;
                }
                Console.ForegroundColor = C_Dim;
                Console.WriteLine("\n  Press any key to return...");
                Console.ResetColor();
                Console.ReadKey(true);
            }
        }
        static void StudentSettingsLoop(StudentController sc)
        {
            string[] items =
            {
                "Create Student",
                "Update Student",
                "Get Student By ID",
                "Delete Student",
                "Get Students By Age",
                "Get Students By Course Group ID",
                "Search Students",
                "Get All Students",
                "← Back to Main Menu",
            };
            while (true)
            {
                DrawHeader();
                int choice = RunMenu(items, "STUDENT SETTINGS", 5);
                if (choice == items.Length - 1) return;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n  ── {items[choice]} ──\n");
                Console.ResetColor();
                switch (choice)
                {
                    case 0: sc.Create(); break;
                    case 1: sc.Update(); break;
                    case 2: sc.GetById(); break;
                    case 3: sc.Delete(); break;
                    case 4: sc.GetAllByAge(); break;
                    case 5: sc.GetAllByCourseGroupId(); break;
                    case 6: sc.Search(); break;
                    case 7: sc.GetAll(); break;
                }
                Console.ForegroundColor = C_Dim;
                Console.WriteLine("\n  Press any key to return...");
                Console.ResetColor();
                Console.ReadKey(true);
            }
        }
        static void ExitApp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            int w = Console.WindowWidth;
            string msg = "Goodbye! See you next time.";
            int pad = Math.Max(0, (w - msg.Length) / 2);
            Console.SetCursorPosition(0, Console.WindowHeight / 2 - 1);
            Console.WriteLine(new string(' ', pad) + msg);
            Console.ResetColor();
            Thread.Sleep(1200);
            Console.CursorVisible = true;
        }
    }
}