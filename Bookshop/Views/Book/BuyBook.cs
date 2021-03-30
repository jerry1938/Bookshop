using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Book
{
    public static class BuyBook
    {
        public static void ConfirmPurchase()
        {
            Console.SetCursorPosition(49, 18);
            Console.WriteLine("Do you want to buy this book?");
        }
    }
}
