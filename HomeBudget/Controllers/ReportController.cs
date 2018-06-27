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
                        where entry.Date >= dateBegin && entry.Date <= dateEnd
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

        public Dictionary<Category, decimal> GetCategoriesSummaryValues(string begin, string end)
        {
            Dictionary<Category, decimal> shopsSummary = new Dictionary<Category, decimal>();
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin + " 00:00:00", out dateBegin);
            DateTime.TryParse(end + " 23:59:59", out dateEnd);

            var query = from item in db.Items
                        where item.Entry.Date >= dateBegin && item.Entry.Date <= dateEnd
                        group item by item.CategoryID into itemsGroup
                        select new
                        {
                            Category = itemsGroup.FirstOrDefault().Category,
                            Amount = itemsGroup.Sum(_ => _.Price)
                        };

            foreach (var category in query)
            {
                System.Console.WriteLine("{0} = {1}", category.Category.Name, category.Amount);
                shopsSummary.Add(category.Category, category.Amount);
            }

            return shopsSummary;
        }
    }
}
