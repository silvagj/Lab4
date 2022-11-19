using Caliburn.Micro;
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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for ListAll.xaml
    /// </summary>
    public partial class ListAll : Window
    {
       // public List<Customer> CustomerList = new List<Customer>();
        public ListAll()
        {
            InitializeComponent();
            AllCustomers allCustomers = new AllCustomers();
            CustomerList.ItemsSource = allCustomers.CustomerList;
            lblListType.Content = "All Customers!";
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            AllCustomers allCustomers = new AllCustomers();

            CustomerList.ItemsSource = allCustomers.CustomerList;
            lblListType.Content = "All Customers!";
        }

        private void btnShowCanadian_Click(object sender, RoutedEventArgs e)
        {
            CanadaCustomers canadaCustomers = new CanadaCustomers();

            CustomerList.ItemsSource = canadaCustomers.CustomerList;

            lblListType.Content = "Canadian Customers!";
        }

        private void btnBackList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainForm = new MainWindow();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
