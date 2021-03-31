using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Controllers
{
    class BookController
    {
        MenuController menuController = new MenuController();
        HomeController homeController = new HomeController();
        Layout layout = new Layout();
        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.Book.Index.PrintBooks();
            int option = menuController.Menu(Views.Book.Index.MenuOptions);

            switch (option)
            {
                case 0: // Categories
                    Categories();
                    break;
                case 1: // Available books
                    
                    break;
                case 2: // Search
                    Search();
                    break;
                case 3: // Home
                    homeController.Index();
                    break;
                default:
                    break;
            }
        }

        public void Search()
        {
            string userInput;
            BookComparer comparer = new BookComparer();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.Book.Search.PrintSearchBar();

            int option = menuController.Menu(Views.Book.Search.MenuOptions);

            switch (option)
            {
                case 0: // Categories
                    Categories();
                    break;
                case 1: // Back
                    Index();
                    break;
                default:
                    break;
            }

            userInput = Views.Book.Search.UseSearchBar();

            List<Webbutik.Models.Book> books = GlobalVariables.Api.GetBooks(userInput).Distinct()
                .ToList();
            List<Webbutik.Models.Book> author = GlobalVariables.Api.GetAuthors(userInput).Distinct()
                .ToList();
            List<Webbutik.Models.BookCategory> categoryKeyword = GlobalVariables.Api
                .GetCategories(userInput).Distinct().ToList();

            List<Webbutik.Models.Book> categories = new List<Webbutik.Models.Book>();


            for (int i = 0; i < categoryKeyword.Count; i++)
            {
                categories = categories.Union(GlobalVariables.Api.GetCategory(
                    categoryKeyword[i].Id), comparer).ToList();
            }

            List<Webbutik.Models.Book> filteredSearch = books;
            filteredSearch = filteredSearch.Union(author, comparer).ToList();
            filteredSearch = filteredSearch.Union(categories, comparer).ToList();

            Views.Book.Search.ShowSearchResult(filteredSearch);

            option = menuController.Menu(Views.Book.Index.MenuOptions);

            switch (option)
            {
                case 0: // Search
                    Search();
                    break;
                case 1: // Categories
                    Categories();
                    break;
                case 2: // Home
                    Index();
                    break;
                default:
                    break;
            }

            layout.ClearMainContent();
            GlobalVariables.BookId = menuController.MainContentMenu(filteredSearch);
            BookInfo();
        }

        public void BookInfo()
        {
            layout.ClearMenu();

            Views.Book.BookInfo.PrintBookInfo(GlobalVariables.BookId);
            int option = menuController.Menu(Views.Book.BookInfo.MenuOptions);

            switch (option)
            {
                case 0: // BuyBook
                    BuyBook();
                    break;
                case 1: // Search
                    Search();
                    break;
                default:
                    break;
            }
        }

        public void BuyBook()
        {
            layout.ClearMainContent();

            if (GlobalVariables.User.Id > 0)
            {
                layout.ClearMainContent();
                Views.Book.BuyBook.ConfirmPurchase();
                int option = menuController.MessageWindow();

                if (option == 0)
                {
                    GlobalVariables.Api.BuyBook(GlobalVariables.User.Id, GlobalVariables.BookId);
                }
                else
                {
                    BookInfo();
                }
            }
            else
            {
                Messages.NotLoggedIn();
                homeController.Login();
            }
        }

        public void Categories()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.BookCategory> categories = GlobalVariables.Api.GetCategories();
            Views.Book.ListCategories.ListAllCategories(categories);
            int option = menuController.Menu(Views.Book.ListCategories.MenuOptions);
            
            switch (option)
            {
                case 0: // Search
                    Search();
                    break;
                case 1: // Book Index
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(categories);

            layout.ClearMainContent();
            GlobalVariables.BookId = menuController.MainContentMenu(GlobalVariables.Api
                .GetAvailableBooks(option));
            BookInfo();
        }
    }
}
