using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    class Register
    {
        public static List<string> MenuOptions = new List<string>() { "Login", "Back" };

        public static void PrintRegisterPage()
        {
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("Username:" + new string(' ', 56));
            Console.CursorLeft = 38;
            Console.WriteLine("Password:" + new string(' ', 56));
            Console.CursorLeft = 30;
            Console.WriteLine("Confirm password:" + new string(' ', 53));
        }

        public static List<string> UseRegisterPage()
        {
            List<string> userInput = new List<string>();

            Console.SetCursorPosition(50, 12);
            Console.CursorVisible = true;
            userInput.Add(Console.ReadLine());
            Console.CursorLeft = 50;
            userInput.Add(Console.ReadLine());
            Console.CursorLeft = 50;
            userInput.Add(Console.ReadLine());
            Console.CursorVisible = false;

            return userInput;
        }

        public static void RemoveRegisterMessage()
        {
            Console.SetCursorPosition(25, 18);
            Console.WriteLine(new string(' ', 78));
            Console.CursorLeft = 25;
            Console.WriteLine(new string(' ', 78));
        }
    }
}
