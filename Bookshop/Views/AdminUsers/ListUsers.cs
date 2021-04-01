using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class ListUsers
    {
        public static List<string> MenuOptions = new List<string>() { "Add user", "Find user", 
            "Back"};

        public static void ListAllUsers(List<Webbutik.Models.User> listOfUsers)
        {
            Console.SetCursorPosition(27, 9);
            foreach (var item in listOfUsers)
            {
                Console.Write(item.Name);
                Console.CursorLeft = 55;
                Console.Write(item.IsAdmin);
                Console.CursorLeft = 80;
                Console.WriteLine(item.IsActive);
                Console.CursorLeft = 27;
            }
        }
    }
}
