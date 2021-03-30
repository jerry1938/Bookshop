using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik.Models;

namespace Bookshop.Helpers
{
    public static class GlobalVariables
    {
        public static User User = new User();
        public static bool IsUserLoggedIn = false;
        public static int BookId = 0;
    }
}
