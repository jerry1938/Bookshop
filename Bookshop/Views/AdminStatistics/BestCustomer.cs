using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminStatistics
{
    public static class BestCustomer
    {
        public static List<string> MenuOptions = new List<string>() { "Sold items", "Money earned",
            "Back"};

        public static void PrintBestCustomerPage(string bestCustomer)
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine($"The best customer is: {bestCustomer}");
        }
    }
}
