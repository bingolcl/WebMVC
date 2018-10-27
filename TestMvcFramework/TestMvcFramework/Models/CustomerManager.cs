using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMvcFramework.Models
{
    public class CustomerManager
    {
        private static List<Customer> _customers;
        static CustomerManager()
        {
            _customers = new List<Customer>();
            var cust1 = new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                City = "Calgary",
                Phone = "403-555-1234"
            };
            var cust2 = new Customer
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                City = "Calgary",
                Phone = "403-555-1234"
            };
            var cust3 = new Customer
            {
                Id = 3,
                FirstName = "Ken",
                LastName = "Know",
                City = "Calgary",
                Phone = "403-555-1234"
            };

            _customers = new List<Customer> { cust1, cust2, cust3 };
        }
        public static List<Customer> GetAll()
        {
            return _customers;
             
        }

        public static void Add(Customer customer)
        {
            //set the id
            var lastIdValue = _customers.Max(c => c.Id);
            customer.Id = ++lastIdValue;
            //add to the collection
            _customers.Add(customer);

        }

        public static Customer Get(int id)
        {
            //set the customer
            return _customers.Find(c => c.Id == id);

        }
    }
}