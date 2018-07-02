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

        public TransactionController()
        {
            shopController = new ShopController();
        }

        public void Add(string date, string amount, Shop shop, string description)
        { 
            DateTime tmpDate = new DateTime();
            Decimal tmpAmount;

            try
            {
                tmpAmount = Decimal.Parse(amount);
                tmpDate = DateTime.Parse(date);
            } catch(Exception e)
            {
                return;
            }

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
            return db.Entries.OrderByDescending(e => e.Date).Include(p => p.Shop).AsNoTracking().ToList();
        }

        public List<Shop> GetAllShops()
        {
            return shopController.GetAll();
        }

        public void Delete(Entry entry)
        {
            var entryToDelete = db.Entries.Find(entry.ID);
            if (entryToDelete != null)
            {
                db.Entries.Remove(entryToDelete);
                db.SaveChanges();
            }
        }


    }
}
