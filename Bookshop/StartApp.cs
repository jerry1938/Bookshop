using Bookshop.Controllers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop
{
    class StartApp
    {
        WebbShopAPI api = new WebbShopAPI();
        Layout layout = new Layout();
        public void Start()
        {
            layout.PrintLayout();

            for (int i = 0; i < 100; i++)
            {
                api.Logout(i);
            }
            HomeController hc = new HomeController();
            hc.Index();
        }
    }
}
