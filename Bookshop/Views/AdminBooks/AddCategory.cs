using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class AddCategory
    {
        public static List<string> MenuOptions = new List<string>() { "Add book", "Edit book",
            "Update category", "Delete category", "Back"};

        public static void PrintAddBookPage()
        {
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("Category name:");
        }

        public static string UseAddCategoryPage()
        {
            Console.SetCursorPosition(55, 18);
            Console.CursorVisible = true;
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        public static void Success()
        {
            Console.SetCursorPosition(43, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully added");
            Console.ResetColor();
            Thread.Sleep(3000);
        }

        public static void Failure()
        {
            Console.SetCursorPosition(48, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The category does already exist");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
