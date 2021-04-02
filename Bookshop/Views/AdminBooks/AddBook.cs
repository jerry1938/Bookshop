using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class AddBook
    {
        public static List<string> MenuOptions = new List<string>() { "Edit book",
            "Add category", "Update category", "Delete category", "Back"};

        public static void PrintAddBookPage()
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine("Title:" + new string(' ', 72));
            Console.CursorLeft = 25;
            Console.WriteLine("Author:" + new string(' ', 71));
            Console.CursorLeft = 25;
            Console.WriteLine("Price:" + new string(' ', 72));
            Console.CursorLeft = 25;
            Console.WriteLine("Amount:" + new string(' ', 71));
        }

        public static List<(string, string, int, int)> UseAddBookPage()
        {
            bool isNumeric = false;
            int price;
            int amount;
            var userInput = new List<(string title, string author, int price, int amount)>();

            Console.SetCursorPosition(50, 9);
            Console.CursorVisible = true;
            string title = Console.ReadLine();
            Console.CursorLeft = 50;
            string author = Console.ReadLine();

            do
            {
                Console.SetCursorPosition(50, 11);
                Console.WriteLine(new string(' ', 53));
                Console.SetCursorPosition(50, 11);
                isNumeric = int.TryParse(Console.ReadLine(), out price);
            } while (isNumeric == false);

            do
            {
                Console.SetCursorPosition(50, 12);
                Console.WriteLine(new string(' ', 53));
                Console.SetCursorPosition(50, 12);
                isNumeric = int.TryParse(Console.ReadLine(), out amount);
            } while (isNumeric == false);

            Console.CursorVisible = false;

            userInput.Add((title, author, price, amount));
            return userInput;
        }

        public static void Success()
        {
            Console.SetCursorPosition(45, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The book has been successfully added");
            Console.ResetColor();
        }

        public static void Failure()
        {
            Console.SetCursorPosition(50, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The book could not be added");
            Console.ResetColor();
        }
    }
}
