using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Logout
    {
        public static void ConfirmLogout()
        {
            Console.SetCursorPosition(45, 13);
            Console.WriteLine("Are you sure you want to Logout?");
        }
    }
}
