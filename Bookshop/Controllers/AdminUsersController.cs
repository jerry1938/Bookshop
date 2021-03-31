using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminUsersController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();
        public void Index()
        {
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminUsers.Index.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    break;
                case 1: // List users
                    break;
                case 2: // Find user                    
                    break;
                case 3: // Activate user
                    break;
                case 4: // Inactivate User
                    break;
                case 5: // Promote user
                    break;
                case 6: // Demote user
                    break;
                case 7: // Home
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }
    }
}
