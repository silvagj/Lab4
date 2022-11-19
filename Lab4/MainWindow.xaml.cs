using Microsoft.Win32;
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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddMain_Click(object sender, RoutedEventArgs e)
        {
            AddNewCustomer mainForm = new AddNewCustomer();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnUpdateMain_Click(object sender, RoutedEventArgs e)
        {
            EditCustomer mainForm = new EditCustomer();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnAllCustomersMain_Click(object sender, RoutedEventArgs e)
        {
            ListAll mainForm = new ListAll();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnCanadaCustomersMain_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            this.Close();
        }
    }
}
