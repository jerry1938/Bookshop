using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class UpdateCategory
    {
        public static List<string> MenuOptions = new List<string>() { "Add book", "Edit book",
            "Add category", "Delete category", "Back"};

        public static string UseUpdateCategoryPage()
        {
            Console.SetCursorPosition(40, 18);
            Console.CursorVisible = true;
            Console.WriteLine("Enter new category name:");
            Console.SetCursorPosition(65, 18);
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        public static void Success()
        {
            Console.SetCursorPosition(42, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully updated");
            Console.ResetColor();
        }
    }
}
