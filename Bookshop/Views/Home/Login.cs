using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Login
    {
        public static List<string> MenuOptions = new List<string>() { "Register", "Back"};

        public static void PrintLoginPage()
        {
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("Username:" + new string(' ', 56));
            Console.CursorLeft = 38;
            Console.WriteLine("Password:" + new string(' ', 56));
        }

        public static List<string> UseLoginPage()
        {
            List<string> userInput = new List<string>();

            Console.SetCursorPosition(50, 12);
            Console.CursorVisible = true;
            userInput.Add(Console.ReadLine());
            Console.CursorLeft = 50;
            userInput.Add(Console.ReadLine());
            Console.CursorVisible = false;

            return userInput;
        }

        public static void RemoveLoginMessage()
        {
            Console.SetCursorPosition(33, 18);
            Console.WriteLine(new string(' ', 70));
        }
    }
}
