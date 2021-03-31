﻿using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Controllers
{
    class HomeController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            if (GlobalVariables.IsUserLoggedIn == true)
            {
                int option = menuController.Menu(Views.Home.Index.MenuOptionsLoggedIn);
                switch (option)
                {
                    case 0: // Logout
                        Logout();
                        break;
                    case 1: // Books
                        BookController bookController = new BookController();
                        bookController.Index();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                int option = menuController.Menu(Views.Home.Index.MenuOptions);

                switch (option)
                {
                    case 0: // Login
                        Login();
                        break;
                    case 1: // Register
                        Register();
                        break;
                    case 2: // Books
                        BookController bookController = new BookController();
                        bookController.Index();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Login()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            List<string> userInput = new List<string>();

            Views.Home.Login.PrintLoginPage();

            int option = menuController.Menu(Views.Home.Login.MenuOptions);

            switch (option)
            {
                case 0: // Register
                    Register();
                    break;
                case 1: // Home
                    Index();
                    break;
                default:
                    break;
            }

            do
            {
                userInput = Views.Home.Login.UseLoginPage();
                GlobalVariables.User = GlobalVariables.Api.Login(userInput[0], userInput[1]);
                if (GlobalVariables.User != null)
                {
                    Messages.SuccessfullLogin();
                    GlobalVariables.IsUserLoggedIn = true;
                    Index();
                }
                else
                {
                    Messages.LoginError();
                    Views.Home.Login.RemoveLoginMessage();
                    Views.Home.Login.PrintLoginPage();
                }
            } while (GlobalVariables.User == null);
        }

        public void Register()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            List<string> userInput = new List<string>();
            bool accountCreated = false;

            Views.Home.Register.PrintRegisterPage();

            int option = menuController.Menu(Views.Home.Register.MenuOptions);

            switch (option)
            {
                case 0: // Login
                    Login();
                    break;
                case 1: // Home
                    Index();
                    break;
                default:
                    break;
            }

            do
            {
                userInput = Views.Home.Register.UseRegisterPage();
                accountCreated = GlobalVariables.Api.Register(userInput[0], userInput[1], 
                    userInput[2]);

                if (accountCreated == true)
                {
                    Messages.AccountSuccessfullyCreated();
                }
                else
                {
                    Messages.AccountCouldNotBeCreated();
                    Views.Home.Register.RemoveRegisterMessage();
                    Views.Home.Register.PrintRegisterPage();
                }

            } while (accountCreated == false);
        }

        public void Logout()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.Home.Logout.ConfirmLogout();
            int option = menuController.MessageWindow();

            switch (option)
            {
                case 0: // Logout
                    GlobalVariables.Api.Logout(GlobalVariables.User.Id);
                    GlobalVariables.IsUserLoggedIn = false;
                    Index();
                    break;
                case 1: // Cancel logout
                    Index();
                    break;
            }
        }
    }
}
