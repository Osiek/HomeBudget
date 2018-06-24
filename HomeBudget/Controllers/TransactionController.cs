using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeBudget.Controllers
{
    class TransactionController : BaseController
    {
        private ShopController shopController;
        public event EventHandler MyControlBroughtToView;

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
            return db.Entries.Include(p => p.Shop).AsNoTracking().ToList();
        }

        public List<Shop> GetAllShops()
        {
            return shopController.GetAll();
        }


    }
}
