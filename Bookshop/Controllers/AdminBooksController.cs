using Bookshop.Helpers;
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
                    AddBook();
                    break;
                case 1: // Edit book
                    EditBook();
                    break;
                case 2: // Add category
                    break;
                case 3: // Update category
                    break;
                case 4: // Delete category
                    break;
                case 5: // Back
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }

        public void AddBook()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.AddBook.PrintAddBookPage();

            int option = menuController.Menu(Views.AdminBooks.AddBook.MenuOptions);
            switch (option)
            {
                case 0: // Edit book
                    EditBook();
                    break;
                case 1: // Add category
                    break;
                case 2: // Update category
                    break;
                case 3: // Delete category
                    break;
                case 4: // Back
                    Index();
                    break;
                default:
                    break;
            }

            List<(string title, string author, int price, int amount)> userInput = Views.AdminBooks
                .AddBook.UseAddBookPage();
            bool addedBook = GlobalVariables.Api.AddBook(GlobalVariables.User.Id, 
                userInput[0].title, userInput[0].author, userInput[0].price, userInput[0].amount);

            if (addedBook == true)
            {
                Views.AdminBooks.AddBook.Success();
            }
            else
            {
                Views.AdminBooks.AddBook.Failure();
            }

            Index();
        }

        public void EditBook()
        {
            BookComparer comparer = new BookComparer();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.Book.Search.PrintSearchBar();

            int option = menuController.Menu(Views.AdminBooks.EditBook.MenuOptions);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Back
                    Index();
                    break;
                default:
                    break;
            }

            string userInput = Views.Book.Search.UseSearchBar();

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

            GlobalVariables.BookId = menuController.MainContentMenu(filteredSearch);

            BookInfo();
        }

        public void BookInfo()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.BookInfo.PrintBookInfo();

            int option = menuController.Menu(Views.AdminBooks.BookInfo.MenuOptions);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Update book
                    UpdateBook();
                    break;
                case 2: // Remove book
                    RemoveBook();
                    break;
                case 3: // Back
                    EditBook();
                    break;
                default:
                    break;
            }
        }

        public void ChangeAmount()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.ChangeAmount.PrintChangeAmountPage();

            int option = menuController.Menu(Views.AdminBooks.ChangeAmount.MenuOptions);
            switch (option)
            {
                case 0: // Update book
                    UpdateBook();
                    break;
                case 1: // Remove book
                    RemoveBook();
                    break;
                case 2: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            int userInput = Views.AdminBooks.ChangeAmount.UseChangeAmountPage();
            GlobalVariables.Api.SetAmount(GlobalVariables.User.Id, GlobalVariables.BookId, 
                userInput);

            Index();
        }

        public void UpdateBook()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.UpdateBook.PrintUpdateBookPage();

            int option = menuController.Menu(Views.AdminBooks.UpdateBook.MenuOptions);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Remove book
                    RemoveBook();
                    break;
                case 2: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            var userInput = new List<(string title, string author, int price)>();
            userInput = Views.AdminBooks.UpdateBook.UseUpdateBookPage();
            
            bool isUpdated = GlobalVariables.Api.UpdateBook(GlobalVariables.User.Id, 
                GlobalVariables.BookId, userInput[0].title, userInput[0].author, 
                userInput[0].price);

            if (isUpdated == true)
            {
                Views.AdminBooks.UpdateBook.Success();
            }
            else
            {
                Views.AdminBooks.UpdateBook.Failure();
            }

            Index();
        }

        public void RemoveBook()
        {
            Menu menu = new Menu();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.RemoveBook.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminBooks.RemoveBook.MenuOptions);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Update book
                    UpdateBook();
                    break;
                case 2: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isRemoved = GlobalVariables.Api.DeleteBook(GlobalVariables.User.Id, 
                        GlobalVariables.BookId);

                    if (isRemoved == true)
                    {
                        Views.AdminBooks.RemoveBook.Success();
                    }
                    else
                    {
                        Views.AdminBooks.RemoveBook.Failure();
                    }
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
