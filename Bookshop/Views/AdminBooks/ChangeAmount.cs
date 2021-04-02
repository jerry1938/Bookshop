using Bookshop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class ChangeAmount
    {
        public static List<string> MenuOptions = new List<string>() { "Update book",
            "Remove book", "Change category", "Back"};

        public static void PrintChangeAmountPage()
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine(
                $"Current amount: {GlobalVariables.Api.GetBook(GlobalVariables.BookId).Amount}");
            Console.CursorLeft = 25;
            Console.WriteLine("New amount:");
        }

        public static int UseChangeAmountPage()
        {
            bool isNumeric = false;
            int userInput;

            Console.CursorVisible = true;

            do
            {
                Console.SetCursorPosition(40, 10);
                Console.WriteLine(new string(' ', 63));
                Console.SetCursorPosition(40, 10);
                isNumeric = int.TryParse(Console.ReadLine(), out userInput);
            } while (isNumeric == false);

            Console.CursorVisible = false;

            return userInput;
        }
    }
}
