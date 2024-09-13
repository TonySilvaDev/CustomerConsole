using CustomerConsole.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerConsole
{
    public class App
    {
        private readonly ICustomerDataProvider _dataProvider;
        public App(ICustomerDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void SaveCustomerList()
        {
            Console.WriteLine("############## Populate the list with at least three customers ##############");
            List<Customer> customerList = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Lupita",
                    Age = 20,
                    Email = "lupita@mail.com"
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Tony",
                    Age = 25,
                    Email = "tony@mail.com"
                },
                new Customer()
                {
                    Id = 3,
                    Name = "Fernanda",
                    Age = 30,
                    Email = "fernanda@mail.com"
                },
                new Customer()
                {
                    Id = 4,
                    Name = "Carlos",
                    Age = 35,
                    Email = "carlos@mail.com"
                },
                new Customer()
                {
                    Id = 5,
                    Name = "Fina",
                    Age = 40,
                    Email = "fina@mail.com"
                },
                new Customer()
                {
                    Id = 6,
                    Name = "Doe",
                    Age = 45,
                    Email = "doe@mail.com"
                }
            };

            _dataProvider.SaveCustomerList(customerList);

            Console.WriteLine($"Added {customerList.Count} customers");
            Console.WriteLine("\n");
        }

        public void SaveCustomer()
        {
            Console.WriteLine("############## Populate one customer ##############");
            Customer customer = new Customer()
            {
                Id = 7,
                Name = "Pepe",
                Age = 15,
                Email = "pepe@mail.com"
            };

            _dataProvider.SaveCustomer(customer);
            Console.WriteLine($"Added 1 customer");
            Console.WriteLine("\n");
        }

        public void GetCustomerList()
        {
            Console.WriteLine("############## Show all customers ##############");
            var customerList = _dataProvider.GetCustomerList();
            foreach (var customer in customerList)
            {
                Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("############## Show customers older than 30 years ##############");
            var customersOlderThan30 = customerList.Where(c => c.Age > 30).ToList();

            if (customersOlderThan30.Count > 0)
            {
                foreach (var customer in customersOlderThan30)
                {
                    Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
                }
            }
            else
            {
                Console.WriteLine("No customer older than 30");
            }
            Console.WriteLine("\n");

            Console.WriteLine("############## Customers whose names contains 'Doe' ##############");
            var customerContainsDoe = customerList.Where(c => c.Name.Contains("Doe")).ToList();
            if (customerContainsDoe.Count > 0)
            {
                foreach (var customer in customerContainsDoe)
                {
                    Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
                }
            }
            else
            {
                Console.WriteLine("No name contains 'Doe'");
            }

            Console.WriteLine("\n");

            Console.WriteLine("############## Serialize list of customers to json ##############");
            var serializeCustomerList = JsonSerializer.Serialize(customerList);
            Console.WriteLine(serializeCustomerList);
            Console.WriteLine("\n");

            Console.WriteLine("############## Deserialize json into a list of customer object ##############");
            var deserializeCustomerList = JsonSerializer.Deserialize<List<Customer>>(serializeCustomerList);
            foreach (var customer in deserializeCustomerList)
            {
                Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
            }
            Console.WriteLine("\n");
        }
        public void GetCustomerListByAgeRange()
        {
            Console.WriteLine("############## Customer list by age range ##############");
            int startAge = 35;
            int endAge = 50;
            Console.WriteLine($"Start age: {startAge} | End age: {endAge}");
            if (startAge > endAge)
            {
                Console.WriteLine("Start age must be less than end age");
            }
            else
            {
                var customersByAgeRange = _dataProvider.GetCustomerListByAgeRange(startAge, endAge);
                foreach (var customer in customersByAgeRange)
                {
                    Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
