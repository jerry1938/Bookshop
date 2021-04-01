using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class DemoteUser
    {
        public static List<string> MenuOptions = new List<string>() { "Add user", "List users",
            "Find user", "Activate user", "Inactivate user", "Promote user", "Back"};

        public static void Confirm()
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(42, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to demote this user?");
            Console.ResetColor();
        }

        public static void IsUserDemoted(bool isPromoted)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            if (isPromoted == true)
            {
                Console.SetCursorPosition(49, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user has now been demoted");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }
    }
}
