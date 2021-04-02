using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class RemoveBook
    {
        public static List<string> MenuOptions = new List<string>() { "Change amount",
            "Update book", "Back"};

        public static void Confirm()
        {
            Console.SetCursorPosition(42, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to remove this book?");
            Console.ResetColor();
        }

        public static void Success()
        {
            Console.SetCursorPosition(44, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The book has been successfully removed");
            Console.ResetColor();
            Thread.Sleep(3000);
        }

        public static void Failure()
        {
            Console.SetCursorPosition(49, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The book could not be removed");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
