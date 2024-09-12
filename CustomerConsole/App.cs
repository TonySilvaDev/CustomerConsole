using CustomerConsole.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Age = 20,
                    Email = "fernanda@mail.com"
                },
                new Customer()
                {
                    Id = 4,
                    Name = "Carlos",
                    Age = 20,
                    Email = "carlos@mail.com"
                },
                new Customer()
                {
                    Id = 5,
                    Name = "Fina",
                    Age = 20,
                    Email = "fina@mail.com"
                },
            };

            _dataProvider.SaveCustomerList(customerList);

            Console.WriteLine($"Added {customerList.Count} customers");
            Console.WriteLine("\n");
        }
    }
}
