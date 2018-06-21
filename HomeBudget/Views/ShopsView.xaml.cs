using HomeBudget.Controllers;
using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace HomeBudget.Views
{
    /// <summary>
    /// Interaction logic for ShopsView.xaml
    /// </summary>
    public partial class ShopsView : UserControl
    {
        private ShopController shopController;
        private bool isManualEditCommit;

        public ShopsView()
        {
            InitializeComponent();
            shopController = new ShopController();
        }

        private void saveShopButton_Click(object sender, RoutedEventArgs e)
        {
            shopController.Add(shopNameTextBox.Text);
            shopNameTextBox.Text = "";

            RefreshShopsTable();
        }

        private void DeleteShopButton(object sender, RoutedEventArgs e)
        {
            Shop shopToDelete = (sender as Button).DataContext as Shop;
            shopController.Delete(shopToDelete);

            RefreshShopsTable();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshShopsTable();
        }

        private void RefreshShopsTable()
        {
            this.shopDataGrid.DataContext = shopController.GetAll();
            this.shopDataGrid.Items.Refresh();

        }

        private void shopDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Stolen from here:
            // http://codefluff.blogspot.com/2010/05/commiting-bound-cell-changes.html

            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }

            shopController.SaveChanges();
        }
    }
}
