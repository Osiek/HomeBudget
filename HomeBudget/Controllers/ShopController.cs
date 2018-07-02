using HomeBudget.Models;
using HomeBudget.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class ShopController : BaseController
    {
        public void Add(string shopName)
        {
            if (shopName.Trim().Length > 0)
            {
                var shop = new Shop();

                if (FindIfNameExists(shopName) != true)
                {
                    shop.Name = shopName;

                    db.Shops.Add(shop);
                    db.SaveChanges();
                }
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

        public void Delete(Shop shop)
        {
            //TODO: Move Entries from delted shop or something.
            Shop shopToDelete = db.Shops.Find(shop.ID);
            if (shopToDelete != null)
            {
                if (GetNumberOfAssignedEntries(shopToDelete) > 0)
                {
                    var alteredShops = db.Shops.ToList();
                    alteredShops.Remove(shopToDelete);

                    var promptWindow = new MoveEntriesToShopWindow(alteredShops);
                    promptWindow.ShowDialog();

                    if (promptWindow.SelectedShop != null)
                    {
                        var entriesToMove = db.Entries.Where(e => e.ShopID == shopToDelete.ID);

                        foreach (var entry in entriesToMove)
                        {
                            entry.ShopID = promptWindow.SelectedShop.ID;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                db.Shops.Remove(shopToDelete);

            }

            db.SaveChanges();
        }

        public List<Shop> GetAll()
        {
            return db.Shops.OrderByDescending(s => s.Entries.Count).ToList();
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

        public int GetNumberOfAssignedEntries(Shop shop)
        {
            var foundShop = db.Shops.Find(shop.ID);

            if (foundShop != null)
            {
                return foundShop.Entries.Count;
            }

            return 0;
        }
    }
}
