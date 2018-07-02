using HomeBudget.Controllers;
using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Item> Items { get; set; }
        public List<Category> Categories { get; set; }

        public TransactionDetailsWindow(Entry entry)
        {
            InitializeComponent();
            this.Items = new ObservableCollection<Item>();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.entry = entry;
            this.itemController = new ItemController();
            this.transactionController = new TransactionController();
            this.categoryController = new CategoryController();
            this.FillFields();
            
            DataContext = this;
        }

        private void FillFields()
        {
            transactionDateTextBox.Text = entry.Date.ToString("dd.MM.yyyy");
            transactionAmountTextBox.Text = entry.Price.ToString("0.00");
            shopComboBox.DataContext = transactionController.GetAllShops();
            shopComboBox.SelectedValue = entry.ShopID;
            transactionDescriptionTextBox.Text = entry.Description;
            LoadItems();
            Categories = categoryController.GetAll();
            CategoryComboBoxColumn.ItemsSource = Categories;
        }

        private void itemAddButton_Click(object sender, RoutedEventArgs e)
        {
            itemController.Add(itemNameTextBox.Text, itemPriceTextBox.Text, itemCategoryComboBox.SelectedItem as Category, entry);
            itemPriceTextBox.Clear();
            itemNameTextBox.Clear();
            RefreshItemsTable();
        }

        private void RefreshItemsTable()
        {
            LoadItems();
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

        private void LoadItems()
        {
            var tmpItems = itemController.GetAllForEntry(entry);
            Items.Clear();

            foreach(var item in tmpItems)
            {
                Items.Add(item);
            }
        }
    }
}
