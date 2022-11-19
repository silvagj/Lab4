using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        public AddNewCustomer()
        {
            InitializeComponent();
            lblIncorrectEmail.Visibility = Visibility.Hidden;
            lblPhoneFormatError.Visibility = Visibility.Hidden;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContext())
            {
                var nameStyle = txtNameStyleNew.Text;
                var title = txtTitleNew.Text;
                var firstName = txtFirstNameNew.Text;
                var middleName = txtMiddleNameNew.Text;
                var lastName = txtLastNameNew.Text;
                var companyName = txtCompanyNameNew.Text;
                var salesPerson = txtSalesPersonNew.Text;
                var email = txtEmailAddressNew.Text;
                var phone =txtPhoneNew.Text;
                var password = txtPasswordNew.Password;





                var address1 = txtAddress1New.Text;
                var address2 = txtAddress2New.Text;
                var city = txtCityNew.Text;
                var stateProvince = txtStateProvinceNew.Text;
                var countryRegion = txtCountryRegionNew.Text;
                var postalCode = txtPostalCodeNew.Text;
                var addressType = txtAddressTypeNew.Text;
                

                var customer = new Customer
                {
                    NameStyle = nameStyle,
                    Title = title,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    CompanyName = companyName,
                    SalesPerson = salesPerson,
                    EmailAddress = email,
                    Phone = phone,
                    Password = password
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                int customerId = customer.CustomerId;

                var address = new Address
                {
                    AddressLine1 = address1,
                    AddressLine2 = address2,
                    City = city,
                    StateProvince = stateProvince,
                    CountryRegion = countryRegion,
                    PostalCode = postalCode
                };

                db.Addresses.Add(address);
                db.SaveChanges();

                int addressId = address.AddressId;

                DateTime value = DateTime.Parse(DateTime.Now.ToString("o"));   //new DateTime(2010, 1, 18);   // need to check the date

                var customerAddress = new CustomerAddress { AddressType=addressType, ModifiedDate= value, CustomerId =customerId, AddressId = addressId };

                db.CustomerAddresses.Add(customerAddress);
                db.SaveChanges();

                MessageBox.Show("Customer Added!");
                Clear();


            }

        }

        private void btnClearNew_Click(object sender, RoutedEventArgs e)
        {

            Clear();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainForm = new MainWindow();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void Clear()
        {
            txtNameStyleNew.Text = "";
            txtTitleNew.Text = "";
            txtFirstNameNew.Text = "";
            txtMiddleNameNew.Text = "";
            txtLastNameNew.Text = "";
            txtCompanyNameNew.Text = "";
            txtSalesPersonNew.Text = "";
            txtEmailAddressNew.Text = "";
            txtPhoneNew.Text = "";
            txtPasswordNew.Password = "";





            txtAddress1New.Text = "";
            txtAddress2New.Text = "";
            txtCityNew.Text = "";
            txtStateProvinceNew.Text = "";
            txtCountryRegionNew.Text = "";
            txtPostalCodeNew.Text = "";
            txtAddressTypeNew.Text = "";

            lblIncorrectEmail.Visibility = Visibility.Hidden;
            lblPhoneFormatError.Visibility = Visibility.Hidden;
        }

        private void txtPhoneNew_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex emailRegex = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})");
            // check if regex matches
            if (emailRegex.IsMatch(txtPhoneNew.Text))
            {
                lblPhoneFormatError.Visibility = Visibility.Hidden;
                lblPhoneFormatError.Content = "";
            }
            else
            {
                lblPhoneFormatError.Visibility = Visibility.Visible;
                lblPhoneFormatError.Content = "Incorrect format of phone number! (XXX-XXX-XXXX)";
            }
        }

        private void txtEmailAddressNew_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex emailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            if (!emailRegex.IsMatch(txtEmailAddressNew.Text))
            {
                lblIncorrectEmail.Visibility = Visibility.Visible;
                lblIncorrectEmail.Content = "Incorrect format of email! (someone@email.com)";

            }
            else
            {
                lblIncorrectEmail.Visibility = Visibility.Hidden;
                lblIncorrectEmail.Content = "";
            }
        }
    }
}
