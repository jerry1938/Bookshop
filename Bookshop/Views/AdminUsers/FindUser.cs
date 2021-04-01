using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class FindUser
    {
        public static List<string> MenuOptions = new List<string>() { "Add user", "List users", 
            "Back"};

        public static void PrintFindUserPage()
        {
            Console.SetCursorPosition(51, 18);
            Console.Write("Find: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter the username");
            Console.ResetColor();
        }

        public static string UseFindUserPage()
        {
            Console.SetCursorPosition(57, 18);
            Console.Write(new string(' ', 46));
            Console.CursorLeft = 57;
            Console.CursorVisible = true;
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        public static void PrintResult(List<Webbutik.Models.User> users)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(27, 9);

            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
                Console.CursorLeft = 27;
            }
        }
    }
}
