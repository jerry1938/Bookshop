using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminStatistics
{
    public static class MoneyEarned
    {
        public static List<string> MenuOptions = new List<string>() { "Sold items", "Best customer",
            "Back"};

        public static void PrintMoneyEarnedPage(int moneyEarned)
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine($"Total money earned: {moneyEarned} kr");
        }
    }
}
