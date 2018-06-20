using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class ShopController
    {
        private DAL.AppContext db = new DAL.AppContext();

        public void Add(string categoryName)
        {
            var shop = new Shop();

            if (FindIfNameExists(categoryName) != true)
            {
                shop.Name = categoryName;

                db.Shops.Add(shop);
                db.SaveChanges();
            }
        }

        public void Edit(int id, string newName)
        {
            Shop shopToEdit = db.Shops.Find(id);
            if (shopToEdit != null && FindIfNameExists(newName) != true)
            {
                shopToEdit.Name = newName;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Shop shopToDelete = db.Shops.Find(id);
            if (shopToDelete != null)
            {
                db.Shops.Remove(shopToDelete);
                db.SaveChanges();
            }
        }

        public List<Shop> GetAll()
        {
            List<Shop> list = new List<Shop>();
            var shopList = db.Shops.ToList();

            foreach (var shop in shopList)
            {
                list.Add(shop);
            }

            return list;
        }

        private bool FindIfNameExists(string name)
        {
            //Save only unique
            var shop = db.Shops
                .Where(c => c.Name == name)
                .FirstOrDefault();

            if (shop != null)
            {
                return true;
            }

            return false;
        }
    }
}
