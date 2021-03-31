using Bookshop.Helpers;
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
            layout.ClearMainContent();

            int option = menuController.Menu(Views.AdminUsers.Index.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
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

        public void AddUser()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            List<string> userInput = new List<string>();

            Views.AdminUsers.AddUser.PrintAddUserPage();

            int option = menuController.Menu(Views.AdminUsers.AddUser.MenuOptions);
            switch (option)
            {
                case 0: // List users
                    break;
                case 1: // Find user
                    break;
                case 2: // Activate user
                    break;
                case 3: // Inactivate user
                    break;
                case 4: // Promote user
                    break;
                case 5: // Demote user
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            userInput = Views.AdminUsers.AddUser.UseAddUserPage();
            Views.AdminUsers.AddUser.Confirm();
            option = menuController.MessageWindow();
            switch (option)
            {
                case 0: // Create user and go to Index
                    bool isCreated = false;
                    if (userInput[1] == string.Empty)
                    {
                        isCreated = GlobalVariables.Api.AddUser(
                            GlobalVariables.User.Id, userInput[0]);
                    }
                    else
                    {
                        isCreated = GlobalVariables.Api.AddUser(
                            GlobalVariables.User.Id, userInput[0], userInput[1]);
                    }

                    if (isCreated == true)
                    {
                        Views.AdminUsers.AddUser.UserSuccessfullyCreated();
                    }
                    else
                    {
                        Views.AdminUsers.AddUser.UserDoesAlreadyExist();
                    }
                    Index();
                    break;
                case 1: // Index
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
