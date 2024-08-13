using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Entities;
using Bank.Exceptions;
using Bank.BusinessLogicLayer;
using Bank.BusinessLogicLayer.BALContracts;
using System.Deployment.Internal;

namespace BankPresentation
{
    static class CustomerPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //create an object of Customer
                Customer customer = new Customer();

                //read all details from the user
                Console.WriteLine("\n******ADD CUSTOMER*****");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();

                Console.Write("Address: ");
                customer.Address = Console.ReadLine();

                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();

                Console.Write("City: ");
                customer.City = Console.ReadLine();

                Console.Write("Country: ");
                customer.Country = Console.ReadLine();

                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                //Create BL object
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();
                Guid newGuid = customerBusinessLogicLayer.AddCustomer(customer);

                List<Customer> matchingCustomers = customerBusinessLogicLayer.GetCustomersByConditions(item => item.CustomerId == newGuid);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code:" + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                {
                    Console.WriteLine("Customer Not added");
                }
                Console.WriteLine("Customer Added.\n");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }
        internal static void ViewCustomers()
        {
            try
            {
                //Create BL object
                ICustomerBusinessLogicLayer customersBusinessLogicLayer = new CustomerBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();

                Console.WriteLine("\n********* All Customers*******");
                //read all customers
                foreach (var item in allCustomers)
                {
                    Console.WriteLine("Customer Code:" + item.CustomerCode);
                    Console.WriteLine("Customer Name:" + item.CustomerName);
                    Console.WriteLine("Landmark:" + item.Landmark);
                    Console.WriteLine("City:" + item.City);
                    Console.WriteLine("Country:" + item.Country);
                    Console.WriteLine("Mobile:" + item.Mobile);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
