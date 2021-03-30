using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Index
    {
        public static List<string> MenuOptions = new List<string>() { "Login", "Register", "Books", 
            "Exit"};
        public static List<string> MenuOptionsLoggedIn = new List<string>() { "Logout", "Books", 
            "Exit" };
    }
}
