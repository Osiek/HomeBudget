using HomeBudget.Controllers;
using HomeBudget.Models;
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
using System.Windows.Shapes;

namespace HomeBudget.Windows
{
    /// <summary>
    /// Interaction logic for TransactionDetailsWindow.xaml
    /// </summary>
    public partial class TransactionDetailsWindow : Window
    {
        private Entry entry;
        private TransactionController transactionController;
        private CategoryController categoryController;
        private ItemController itemController;
        private DAL.AppContext db = new DAL.AppContext();
        bool isManualEditCommit;

        public TransactionDetailsWindow(Entry entry)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.entry = entry;
            this.itemController = new ItemController();
            this.transactionController = new TransactionController();
            this.categoryController = new CategoryController();
            this.FillFields();
        }

        private void FillFields()
        {
            transactionDateTextBox.Text = entry.Date.ToString("dd.MM.yyyy");
            transactionAmountTextBox.Text = entry.Price.ToString("0.00");
            shopComboBox.DataContext = transactionController.GetAllShops();
            shopComboBox.SelectedValue = entry.ShopID;
            transactionDescriptionTextBox.Text = entry.Description;
            itemCategoryComboBox.DataContext = categoryController.GetAll();
            itemsDataGrid.DataContext = itemController.GetAllForEntry(entry);
        }

        private void itemAddButton_Click(object sender, RoutedEventArgs e)
        {
            itemController.Add(itemNameTextBox.Text, itemPriceTextBox.Text, itemCategoryComboBox.SelectedItem as Category, entry);

            RefreshItemsTable();
        }

        private void RefreshItemsTable()
        {
            itemsDataGrid.DataContext = itemController.GetAllForEntry(entry);
            itemsDataGrid.Items.Refresh();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            var itemToDelete = ((Button)sender).DataContext as Item;
            itemController.Delete(itemToDelete);

            RefreshItemsTable();
        }

        private void itemsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }

            itemController.SaveChanges();
        }
    }
}
