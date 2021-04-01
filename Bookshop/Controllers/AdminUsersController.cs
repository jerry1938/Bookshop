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
                    ListUsers();
                    break;
                case 2: // Find user                    
                    FindUser();
                    break;
                case 3:  // Home
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
                    ListUsers();
                    break;
                case 1: // Find user
                    FindUser();
                    break;
                case 2: // Back
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
                        layout.ClearMainContent();
                        Views.AdminUsers.AddUser.UserSuccessfullyCreated();
                    }
                    else
                    {
                        layout.ClearMainContent();
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

        public void ListUsers()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.User> listOfUsers = GlobalVariables.Api.ListUsers(
                GlobalVariables.User.Id);
            Views.AdminUsers.ListUsers.ListAllUsers(listOfUsers);

            int option = menuController.Menu(Views.AdminUsers.ListUsers.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // Find user
                    FindUser();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(listOfUsers);
            UserInfo(option, listOfUsers);
        }

        public void UserInfo(int userId, List<Webbutik.Models.User> users)
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.UserInfo.PrintUserInfo(userId, users);

            int option = menuController.Menu(Views.AdminUsers.UserInfo.MenuOptions);
            switch (option)
            {
                case 0: // Activate user
                    ActivateUser(userId);
                    break;
                case 1: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 2: // Promote user
                    PromoteUser(userId);
                    break;
                case 3: // Demote user
                    DemoteUser(userId);
                    break;
                case 4: // Back
                    ListUsers();
                    break;
                default:
                    break;
            }
        }

        public void FindUser()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.FindUser.PrintFindUserPage();

            int option = menuController.Menu(Views.AdminUsers.FindUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            string userInput = Views.AdminUsers.FindUser.UseFindUserPage();
            List<Webbutik.Models.User> users = GlobalVariables.Api.FindUser(
                GlobalVariables.User.Id, userInput);

            Views.AdminUsers.FindUser.PrintResult(users);

            option = menuController.Menu(Views.AdminUsers.FindUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(users);
            UserInfo(option, users);
        }

        public void ActivateUser(int userId)
        {
            Menu menu = new Menu();

            layout.ClearMainContent();
            layout.ClearMenu();
            
            Views.AdminUsers.ActivateUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.ActivateUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 4: // Promote user
                    PromoteUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool IsActive = GlobalVariables.Api.ActivateUser(GlobalVariables.User.Id, 
                        userId);
                    Views.AdminUsers.ActivateUser.IsUserActive(IsActive);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        public void InactivateUser(int userId)
        {
            Menu menu = new Menu();
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.InactivateUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.InactivateUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Promote user
                    PromoteUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isInactive = GlobalVariables.Api.InactivateUser(GlobalVariables.User.Id, 
                        userId);
                    Views.AdminUsers.InactivateUser.IsUserInactive(isInactive);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        public void PromoteUser(int userId)
        {
            Menu menu = new Menu();
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.PromoteUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.PromoteUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 5: // Demote user
                    DemoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isPromoted = GlobalVariables.Api.Promote(GlobalVariables.User.Id, userId);
                    Views.AdminUsers.PromoteUser.IsUserPromoted(isPromoted);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        public void DemoteUser(int userId)
        {
            Menu menu = new Menu();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminUsers.DemoteUser.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminUsers.DemoteUser.MenuOptions);
            switch (option)
            {
                case 0: // Add user
                    AddUser();
                    break;
                case 1: // List users
                    ListUsers();
                    break;
                case 2: // Find user
                    FindUser();
                    break;
                case 3: // Activate user
                    ActivateUser(userId);
                    break;
                case 4: // Inactivate user
                    InactivateUser(userId);
                    break;
                case 5: // Promote user
                    PromoteUser(userId);
                    break;
                case 6: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isPromoted = GlobalVariables.Api.Demote(GlobalVariables.User.Id, userId);
                    Views.AdminUsers.DemoteUser.IsUserDemoted(isPromoted);
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
