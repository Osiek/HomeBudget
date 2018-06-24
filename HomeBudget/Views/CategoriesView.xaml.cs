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
        private bool isManualEditCommit;

        public CategoriesView()
        {
            InitializeComponent();
            categoryController = new CategoryController();
        }

        private void saveCategoryEvent(object sender, RoutedEventArgs e)
        {
            categoryController.Add(categoryNameInput.Text);
            categoryNameInput.Text = "";

            RefreshCategoryTable();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshCategoryTable();
        }

        private void DeleteCategoryButton(object sender, RoutedEventArgs e)
        {
            Category categoryToDelete = (sender as Button).DataContext as Category;
            categoryController.Delete(categoryToDelete);

            RefreshCategoryTable();
        }

        private void RefreshCategoryTable()
        {
            this.categoryDataGrid.DataContext = categoryController.GetAll();
            this.categoryDataGrid.Items.Refresh();
        }

        private void categoryDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }

            categoryController.SaveChanges();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshCategoryTable();
        }
    }
}
