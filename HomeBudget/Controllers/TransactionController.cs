using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class TransactionController : BaseController
    {
        private ShopController shopController;

        public TransactionController()
        {
            shopController = new ShopController();
        }

        public void Add(string date, string amount, Shop shop, string description)
        { 
            DateTime tmpDate = new DateTime();
            Decimal tmpAmount;

            DateTime.TryParse(date + " 00:00:00", out tmpDate);
            Decimal.TryParse(amount, out tmpAmount);

            var newEntry = new Entry() {
                Date = tmpDate,
                Price = tmpAmount,
                ShopID = shop.ID,
                Description = description
            };

            db.Entries.Add(newEntry);
            db.SaveChanges();
        }

        public List<Entry> GetAll()
        {
            db.Configuration.ProxyCreationEnabled = true;
            return db.Entries.Include(p => p.Shop).ToList();
        }

        public List<Shop> GetAllShops()
        {
            return shopController.GetAll();
        }
    }
}
