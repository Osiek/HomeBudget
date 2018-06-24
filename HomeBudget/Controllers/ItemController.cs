using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class ItemController : BaseController
    {
        public void Add(string name, string textPrice, Category category, Entry entry)
        {
            decimal price;

            Decimal.TryParse(textPrice, out price);

            if (category != null && entry != null && name.Length > 0 && price > 0)
            {
                var item = new Item() {
                    CategoryID = category.ID,
                    EntryID = entry.ID,
                    Name = name,
                    Price = price
                };

                db.Items.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(int id, string newName)
        {
            var itemToEdit = db.Items.Find(id);
            if (itemToEdit != null)
            {
                itemToEdit.Name = newName;
                db.SaveChanges();
            }
        }

        public void Delete(Item item)
        {
            var itemToDelete = db.Items.Find(item.ID);
            if (itemToDelete != null)
            {
                db.Items.Remove(itemToDelete);
                db.SaveChanges();
            }
        }

        public List<Item> GetAll()
        {
            return db.Items.Include("Category").OrderByDescending(i => i.ID).ToList();
        }

        public List<Item> GetAllForEntry(Entry entry)
        {
            return db.Items.Include("Category").Where(i => i.EntryID == entry.ID).OrderByDescending(i => i.ID).ToList();
        }
    }
}
