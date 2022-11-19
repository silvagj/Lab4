using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Lab4
{
    public class AllCustomers
    {
        public List<ListCustomers> CustomerList = new List<ListCustomers>();

        public AllCustomers()
        {
            using (var db = new CustomerContext())
            {


                CustomerList = (from c in db.Customers
                                join ca in db.CustomerAddresses on c.CustomerId equals ca.CustomerId
                                join a in db.Addresses on ca.AddressId equals a.AddressId
                                orderby c.FirstName
                                select new ListCustomers
                                {
                                    CustomerId = c.CustomerId,
                                    FirstName = c.FirstName,
                                    MiddleName = c.MiddleName,
                                    LastName = c.LastName,
                                    CompanyName = c.CompanyName,

                                    EmailAddress = c.EmailAddress,
                                    Phone = c.Phone,

                                    AddressLine1 = a.AddressLine1,
                                    AddressLine2 = a.AddressLine2,
                                    City = a.City,
                                    StateProvince = a.StateProvince,
                                    CountryRegion = a.CountryRegion,
                                    PostalCode = a.PostalCode,


                                }).ToList<ListCustomers>(); ;

            };


        }
    }

    public class CanadaCustomers
    {
        public List<ListCustomers> CustomerList = new List<ListCustomers>();

        public CanadaCustomers()
        {
        

                using (var db = new CustomerContext())
                {


                    CustomerList = (from c in db.Customers
                                join ca in db.CustomerAddresses on c.CustomerId equals ca.CustomerId
                                join a in db.Addresses on ca.AddressId equals a.AddressId
                                    where a.CountryRegion == "Canada"
                                    orderby c.CompanyName
                                    select new ListCustomers
                                    {

                                    CustomerId = c.CustomerId,  
                                    FirstName = c.FirstName,
                                    MiddleName = c.MiddleName,
                                    LastName = c.LastName,
                                    CompanyName = c.CompanyName,
                                  
                                    EmailAddress = c.EmailAddress,
                                    Phone = c.Phone,
                              
                                    AddressLine1 = a.AddressLine1,
                                    AddressLine2 = a.AddressLine2,
                                    City = a.City,
                                    StateProvince = a.StateProvince,
                                    CountryRegion = a.CountryRegion,
                                    PostalCode = a.PostalCode,
                                   

                                }).ToList<ListCustomers>(); ;

                };
        
        }
    }

    public class ListCustomers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }

    }
}
