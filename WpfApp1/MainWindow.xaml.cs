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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User MyUser;
        public MainWindow()
        {
            InitializeComponent();

            MyUser = new User();
            MyUser.FirstName = "Mark";
            this.DataContext = new User() {
                FirstName = "TestImie",
                LastName = "TestNazwisko"
            };
            this.UserFirstNameTextBlock.DataContext = MyUser;
        }

        private void ChangeFirstName_Click(object sender, RoutedEventArgs e)
        {
            MyUser.FirstName = UserFirstNameTextBox.Text;
        }
    }
}
