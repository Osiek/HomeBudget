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
    }
}
