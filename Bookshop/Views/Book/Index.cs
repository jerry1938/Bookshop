using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Views.Book
{
    public static class Index
    {
        private static WebbShopAPI api = new WebbShopAPI();
        public static List<string> MenuOptions = new List<string>() { "Categories", 
            "Available books", "Search", "Back" };

        public static void PrintBooks()
        {
            Console.SetCursorPosition(26, 9);
            List<Webbutik.Models.Book> books = new List<Webbutik.Models.Book>();
            List<Webbutik.Models.Book> filteredBooks = new List<Webbutik.Models.Book>();

            books = api.GetBooks(" ").Distinct().ToList();

            foreach (var item in books)
            {
                Console.Write(item.Title);
                Console.CursorLeft = 50;
                Console.WriteLine($"{item.Price} kr");
                Console.CursorLeft = 26;
            }
        }
    }
}
