using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    

    class CategoryController
    {
        private DAL.AppContext db = new DAL.AppContext();

        public void Add(string categoryName)
        {
            var category = new Category();
            
            if (FindIfNameExists(categoryName) != true)
            {
                category.Name = categoryName;

                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void Edit(int id, string newName)
        {
            Category categoryToEdit = db.Categories.Find(id);
            if(categoryToEdit != null && FindIfNameExists(newName) != true)
            {
                categoryToEdit.Name = newName;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Category categoryToDelete = db.Categories.Find(id);
            if(categoryToDelete != null)
            {
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            var categoryList = db.Categories.ToList();

            foreach(var categpry in categoryList)
            {
                list.Add(categpry);
            }

            return list;
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
