using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Views.Book
{
    public static class ListCategories
    {
        public static List<string> MenuOptions = new List<string>() { "Search", "Back" };

        public static void ListAllCategories(List<Webbutik.Models.BookCategory> categories)
        {
            Console.SetCursorPosition(27, 9);

            foreach (var item in categories)
            {
                Console.WriteLine(item.Name);
                Console.CursorLeft = 27;
            }
        }
    }
}
