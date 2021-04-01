using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminHomeController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminHome.Index.MenuOptions);
            switch (option)
            {
                case 0: // Users
                    AdminUsersController adminUsersController = new AdminUsersController();
                    adminUsersController.Index();
                    break;
                case 1: // Books
                    AdminBooksController adminBooksController = new AdminBooksController();
                    adminBooksController.Index();
                    break;
                case 2: // Statistics
                    break;
                case 3: // Logout
                    HomeController homeController = new HomeController();
                    homeController.Logout();
                    break;
                default:
                    break;
            }
        }
    }
}
