using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminStatisticsController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminStatistics.Index.MenuOptions);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Best customer
                    BestCustomer();
                    break;
                case 2: // Money earned
                    MoneyEarned();
                    break;
                case 3: // Back
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }

        public void SoldItems()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            var soldItems = GlobalVariables.Api.SoldItems(GlobalVariables.User.Id);
            Views.AdminStatistics.SoldItems.PrintSoldItems(soldItems);

            int option = menuController.Menu(Views.AdminStatistics.SoldItems.MenuOptions);
            switch (option)
            {
                case 0: // Best customer
                    BestCustomer();
                    break;
                case 1: // Money earned
                    MoneyEarned();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }

        public void BestCustomer()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            string bestCustomer = GlobalVariables.Api.BestCustomer(GlobalVariables.User.Id);
            Views.AdminStatistics.BestCustomer.PrintBestCustomerPage(bestCustomer);

            int option = menuController.Menu(Views.AdminStatistics.BestCustomer.MenuOptions);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Money earned
                    MoneyEarned();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }

        public void MoneyEarned()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            int moneyEarned = GlobalVariables.Api.MoneyEarned(GlobalVariables.User.Id);
            Views.AdminStatistics.MoneyEarned.PrintMoneyEarnedPage(moneyEarned);

            int option = menuController.Menu(Views.AdminStatistics.MoneyEarned.MenuOptions);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Best customer
                    BestCustomer();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
