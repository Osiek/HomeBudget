using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeBudget.Controllers;
using System.Data.Entity;
using System.Linq;
using HomeBudget.Models;

namespace HomeBudget.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        private CategoryController categoryController;
        private DAL.AppContext db = new DAL.AppContext();
        System.Windows.Data.CollectionViewSource categoryViewSource;

        public CategoriesView()
        {
            InitializeComponent();
            categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            categoryController = new CategoryController();
        }

        private void saveCategoryClick(object sender, RoutedEventArgs e)
        {
            categoryNameInput.IsEnabled = false;
            string categoryText = categoryNameInput.Text.Trim();

            if (categoryText.Length > 0)
            {
                categoryController.Add(categoryText);
            }

            categoryNameInput.Text = "";

            categoryNameInput.IsEnabled = true;

            //Refreshes datagrid, but in documentation they say that categoryDataGrid.Items.Refresh(); should be enough
            RefreshCategoryTable();
            //categoryViewSource.Source = db.Categories.Local;
            //categoryDataGrid.Items.Refresh(); //zbędne, bo db.Categories.Local to ObservableCollection czyli automatycznie powiadamia UI o zmianie zawartosci
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshCategoryTable();

            categoryViewSource.Source = db.Categories.Local;
        }

        private void DeleteCategoryButton(object sender, RoutedEventArgs e)
        {
            Category categoryToDelete = (sender as Button).DataContext as Category;
            if(categoryToDelete != null)
            {
                categoryController.Delete(categoryToDelete.ID);
            }
            
            RefreshCategoryTable();
        }

        private void RefreshCategoryTable()
        {
            categoryViewSource.Source = null;
            db.Categories.Load();
            categoryViewSource.Source = db.Categories.Local;
        }
    }
}
