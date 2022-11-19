using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        public EditCustomer()
        {
            InitializeComponent();
            lblIncorrectEmailEdit.Visibility = Visibility.Hidden;
            lblPhoneFormatErrorEdit.Visibility = Visibility.Hidden;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var db =new CustomerContext())
            {
                var id = Convert.ToInt32(txtSearchCustomerId.Text);

                var found = false;
                var addressId = 0;
                var queryCust = (from c in db.Customers
                                where c.CustomerId == id
                                select c).Take(1);
               
                    foreach (var item in queryCust)
                    {
                        if (item.CustomerId == id)
                        {
                             found = true;

                            item.NameStyle = txtNameStyle.Text;
                            item.Title = txtTitle.Text;
                            item.FirstName = txtFirstName.Text;
                            item.MiddleName = txtMiddleName.Text;
                            item.LastName = txtLastName.Text;
                            item.CompanyName = txtCompanyName.Text;
                            item.SalesPerson = txtSalesPerson.Text;
                            item.EmailAddress = txtEmailAddress.Text;
                            item.Phone = txtPhone.Text;
                            item.Password = txtPassword.Password;
                           

                            var queryCustAdd = (from ca in db.CustomerAddresses
                                                where ca.CustomerId == item.CustomerId
                                                select ca).Take(1);
                        
                        foreach (var custAdd in queryCustAdd)
                        {
                                addressId = Convert.ToInt32(custAdd.AddressId);

                            custAdd.AddressType = txtAddressType.Text;
                            DateTime value = DateTime.Parse(DateTime.Now.ToString("o"));
                            custAdd.ModifiedDate = value;
                        }

                            var queryAdd = (from a in db.Addresses
                                            where a.AddressId == addressId
                                            select a).Take(1);

                            foreach (var add in queryAdd)
                            {
                                add.AddressLine1 = txtAddress1.Text;
                                add.AddressLine2 = txtAddress2.Text;
                                add.City=txtCity.Text;
                                add.StateProvince = txtStateProvince.Text;
                                add.CountryRegion = txtCountryRegion.Text;
                                add.PostalCode = txtPostalCode.Text;
                            }


                        }

                    }
                    db.SaveChanges();

                    MessageBox.Show($"Customer with id {id} was updated successfuly!");

                    Clear();


                if(found == false)
                {
                    MessageBox.Show("The ID you entered does not exist!");
                }

               
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContext())
            {
                var id = Convert.ToInt32(txtSearchCustomerId.Text);

                var addressId =0;
                var queryCust = (from c in db.Customers
                                where c.CustomerId == id
                                select c).Take(1);


                if(queryCust ==null)
                {
                    MessageBox.Show("The ID you entered does not exist!");
                }
                else
                {
                    foreach (var item in queryCust)
                    {
                        if (item.CustomerId == id)
                        {

                            var queryCustAdd = (from ca in db.CustomerAddresses
                                                where ca.CustomerId == item.CustomerId
                                                select ca).Take(1);

                            foreach (var custAdd in queryCustAdd)
                            {
                                addressId = Convert.ToInt32(custAdd.AddressId);

                                db.CustomerAddresses.Remove(custAdd);
                            }

                            var queryAdd = (from a in db.Addresses
                                            where a.AddressId == addressId
                                            select a).Take(1);

                            foreach (var add in queryAdd)
                            {
                                db.Addresses.Remove(add);
                            }

                            db.Customers.Remove(item);


                        }

                    }
                    db.SaveChanges();
                    MessageBox.Show($"Customer with id {id} was deleted successfuly!");
                    Clear();
                }
                
            }

        }

        private void btnBackEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainForm = new MainWindow();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using( var db = new CustomerContext())
            {
                var id = Convert.ToInt32(txtSearchCustomerId.Text);
                bool found = false;

                var query = from c in db.Customers
                            join ca in db.CustomerAddresses on c.CustomerId equals ca.CustomerId
                            join a in db.Addresses on ca.AddressId equals a.AddressId
                            select new
                            {
                                CustomerId = c.CustomerId,
                                NameStyle = c.NameStyle,
                                Title =c.Title,
                                FirstName = c.FirstName,
                                MiddleName = c.MiddleName,
                                LastName = c.LastName,
                                CompanyName = c.CompanyName,
                                SalesPerson = c.SalesPerson,
                                EmailAddress = c.EmailAddress,
                                Phone = c.Phone,
                                Password = c.Password,
                                
                                AddressId =a.AddressId,
                                AddressLine1=a.AddressLine1,
                                AddressLine2=a.AddressLine2,
                                City =a.City,
                                StateProvince=a.StateProvince,
                                CountryRegion=a.CountryRegion,
                                PostalCode=a.PostalCode,
                                AddressType=ca.AddressType

                            };

                foreach (var item in query)
                {
                    if (item.CustomerId == id)
                    {
                        found = true;
                        txtNameStyle.Text = item.NameStyle;
                        txtTitle.Text = item.Title;
                        txtFirstName.Text = item.FirstName;
                        txtMiddleName.Text = item.MiddleName;
                        txtLastName.Text = item.LastName;
                        txtCompanyName.Text = item.CompanyName;
                        txtSalesPerson.Text = item.SalesPerson;
                        txtEmailAddress.Text = item.EmailAddress;
                        txtPhone.Text = item.Phone;
                        txtPassword.Password = item.Password;



                        txtAddress1.Text = item.AddressLine1;
                        txtAddress2.Text = item.AddressLine2;
                        txtCity.Text = item.City;
                        txtStateProvince.Text = item.StateProvince;
                        txtCountryRegion.Text = item.CountryRegion;
                        txtPostalCode.Text = item.PostalCode;
                        txtAddressType.Text = item.AddressType;
                    }

                }
                if (found == false)
                {
                    MessageBox.Show("The ID you entered does not exist!");
                }
            } 
        }

        private void btnClearEdit_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()

        {
            txtSearchCustomerId.Text = null;
            txtNameStyle.Text = "";
            txtTitle.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtCompanyName.Text = "";
            txtSalesPerson.Text = "";
            txtEmailAddress.Text = "";
            txtPhone.Text = "";
            txtPassword.Password = "";





            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtStateProvince.Text = "";
            txtCountryRegion.Text = "";
            txtPostalCode.Text = "";
            txtAddressType.Text = "";

            lblIncorrectEmailEdit.Visibility = Visibility.Hidden;
            lblPhoneFormatErrorEdit.Visibility = Visibility.Hidden;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex emailRegex = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})");
            // check if regex matches
            if (emailRegex.IsMatch(txtPhone.Text))
            {
                lblPhoneFormatErrorEdit.Visibility = Visibility.Hidden;
                lblPhoneFormatErrorEdit.Content = "";
            }
            else
            {
                lblPhoneFormatErrorEdit.Visibility = Visibility.Visible;
                lblPhoneFormatErrorEdit.Content = "Incorrect format of phone number! (XXX-XXX-XXXX)";
            }
        }

        private void txtEmailAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex emailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            if (!emailRegex.IsMatch(txtEmailAddress.Text))
            {
                lblIncorrectEmailEdit.Visibility = Visibility.Visible;
                lblIncorrectEmailEdit.Content = "Incorrect format of email! (someone@email.com)";

            }
            else
            {
                lblIncorrectEmailEdit.Visibility = Visibility.Hidden;
                lblIncorrectEmailEdit.Content = "";
            }
        }
    }
}
