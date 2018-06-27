using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class ReportController : BaseController
    {
        public Dictionary<Shop, decimal> GetShopSummaryValues(string begin, string end)
        {
            Dictionary<Shop, decimal> shopsSummary = new Dictionary<Shop, decimal>();
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin + " 00:00:00", out dateBegin);
            DateTime.TryParse(end + " 23:59:59", out dateEnd);

            var query = from entry in db.Entries
                        where entry.Date > dateBegin && entry.Date < dateEnd
                        group entry by entry.ShopID into shopsGroup
                        select new {
                            Shop = shopsGroup.FirstOrDefault().Shop,
                            Price = shopsGroup.Sum(_ => _.Price)
                        };

            foreach (var shop in query)
            {
                System.Console.WriteLine("{0} = {1}", shop.Shop, shop.Price);
                shopsSummary.Add(shop.Shop, shop.Price);
            }

            return shopsSummary;
        }

        public Dictionary<Shop, decimal> GetCategoriesSummaryValues(string begin, string end)
        {
            Dictionary<Shop, decimal> shopsSummary = new Dictionary<Shop, decimal>();
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin + " 00:00:00", out dateBegin);
            DateTime.TryParse(end + " 23:59:59", out dateEnd);

            var query = from category in db.Categories
                        where category.Date > dateBegin && category.Date < dateEnd
                        group entry by entry.ShopID into shopsGroup
                        select new
                        {
                            Shop = shopsGroup.FirstOrDefault().Shop,
                            Price = shopsGroup.Sum(_ => _.Price)
                        };

            foreach (var shop in query)
            {
                System.Console.WriteLine("{0} = {1}", shop.Shop, shop.Price);
                shopsSummary.Add(shop.Shop, shop.Price);
            }

            return shopsSummary;
        }
    }
}
