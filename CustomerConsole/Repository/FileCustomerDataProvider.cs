using CustomerConsole.Data;
using CustomerConsole.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole.Repository
{
    public class FileCustomerDataProvider : ICustomerDataProvider
    {
        private static List<Customer> _customerList = CustomerData.CustomerList;


        public List<Customer> GetCustomerList()
        {
            return _customerList;
        }

        public List<Customer> GetCustomerListByAgeRange(int startAge, int endAge)
        {
            return _customerList.Where(c => c.Age >= startAge && c.Age <= endAge).ToList();
        }

        public void SaveCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void SaveCustomerList(List<Customer> customerList)
        {
            _customerList.AddRange(customerList);
        }
    }
}
