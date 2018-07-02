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
        public Dictionary<string, decimal> GetShopSummaryValues(string begin, string end)
        {
            Dictionary<string, decimal> shopsSummary = new Dictionary<string, decimal>();
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin, out dateBegin);
            DateTime.TryParse(end, out dateEnd);

            var query = from entry in db.Entries
                        where entry.Date >= dateBegin && entry.Date <= dateEnd
                        group entry by entry.ShopID into shopsGroup
                        select new
                        {
                            Shop = shopsGroup.FirstOrDefault().Shop.Name,
                            Price = shopsGroup.Sum(_ => _.Price)
                        };

            foreach (var shop in query)
            {
                System.Console.WriteLine("{0} = {1}", shop.Shop, shop.Price);
                shopsSummary.Add(shop.Shop, shop.Price);
            }

            return shopsSummary;
        }

        public Dictionary<string, decimal> GetCategoriesSummaryValues(string begin, string end)
        {
            Dictionary<string, decimal> shopsSummary = new Dictionary<string, decimal>();
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin, out dateBegin);
            DateTime.TryParse(end, out dateEnd);

            var query = from item in db.Items
                        where item.Entry.Date >= dateBegin && item.Entry.Date <= dateEnd
                        group item by item.CategoryID into itemsGroup
                        select new
                        {
                            Category = itemsGroup.FirstOrDefault().Category.Name,
                            Amount = itemsGroup.Sum(_ => _.Price)
                        };

            foreach (var category in query)
            {
                System.Console.WriteLine("{0} = {1}", category.Category, category.Amount);
                shopsSummary.Add(category.Category, category.Amount);
            }

            return shopsSummary;
        }
    }
}
