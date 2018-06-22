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
using HomeBudget.Models;

namespace HomeBudget.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        private TransactionController transactionController;

        public TransactionView()
        {
            InitializeComponent();
            transactionController = new TransactionController();
        }

        private void shopComboBox_DropDownOpened(object sender, EventArgs e)
        {
            shopComboBox.DataContext = transactionController.GetAllShops();
        }

        private void saveTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            Shop selectedShop = shopComboBox.SelectedItem as Shop;
            transactionController.Add(transactionDateTextBox.Text, amountTextBox.Text, selectedShop, descriptionTextBox.Text);
        }

        private void RefreshTransactionsTable()
        {
            this.entryDataGrid.DataContext = transactionController.GetAll();
            this.entryDataGrid.Items.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTransactionsTable();
        }
    }
}
