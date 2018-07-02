using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Models;
using HomeBudget.Windows;

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
                if (GetNumberOfAssignedItems(categoryToDelete) > 0)
                {
                    List<Category> alteredCategoryList = db.Categories.ToList();
                    alteredCategoryList.Remove(categoryToDelete);

                    var categoryMovePrompt = new MoveItemsToCategoryWindow(alteredCategoryList);
                    categoryMovePrompt.ShowDialog();

                    if (categoryMovePrompt.SelectedCategory != null)
                    {
                        var itemsToMove = db.Items.Where(i => i.CategoryID == categoryToDelete.ID);

                        foreach (var item in itemsToMove)
                        {
                            item.CategoryID = categoryMovePrompt.SelectedCategory.ID;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                db.Categories.Remove(categoryToDelete);
            }
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.OrderByDescending(c => c.Items.Count).ToList();
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

        public int GetNumberOfAssignedItems(Category category)
        {
            var foundCategory = db.Categories.Find(category.ID);

            if (foundCategory != null)
            {
                return foundCategory.Items.Count;
            }

            return 0;
        }
    }
}
