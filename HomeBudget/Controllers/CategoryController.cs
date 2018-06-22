using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{


    class CategoryController : BaseController
    {
        public void Add(string categoryName)
        {
            if (categoryName.Trim().Length > 0)
            {
                var category = new Category();

                if (FindIfNameExists(categoryName) != true)
                {
                    category.Name = categoryName;

                    db.Categories.Add(category);
                    db.SaveChanges();
                }
            }
        }

        public void Edit(int id, string newName)
        {
            Category categoryToEdit = db.Categories.Find(id);
            if (categoryToEdit != null && FindIfNameExists(newName) != true)
            {
                categoryToEdit.Name = newName;
                db.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            //TODO: Move Items from delted shop or something.
            Category categoryToDelete = db.Categories.Find(category.ID);
            if (categoryToDelete != null)
            {
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        private bool FindIfNameExists(string name)
        {
            //Save only unique
            var category = db.Categories
                .Where(c => c.Name == name)
                .FirstOrDefault();

            if (category != null)
            {
                return true;
            }

            return false;
        }
    }
}
