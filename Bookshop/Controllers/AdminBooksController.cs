using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminBooksController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminBooks.Index.MenuOptions);
            switch (option)
            {
                case 0: // Add book
                    break;
                case 1: // Change amount
                    break;
                case 2: // Update book
                    break;
                case 3: // Remove book
                    break;
                case 4: // Add category
                    break;
                case 5: // Update category
                    break;
                case 6: // Delete category
                    break;
                case 7: // Back
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }
    }
}
