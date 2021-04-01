using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class ActivateUser
    {
        public static List<string> MenuOptions = new List<string>() { "Add user", "List users",
            "Find user", "Inactivate user", "Promote user", "Demote user", "Back"};

        public static void Confirm()
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(41, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to activate this user?");
            Console.ResetColor();
        }

        public static void IsUserActive(bool isActive)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            if (isActive == true)
            {
                Console.SetCursorPosition(52, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user is now active");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }
    }
}
