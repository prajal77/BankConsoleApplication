using Bank.BusinessLogicLayer.BALContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Entities;
using Bank.Exceptions;
using Bank.DataAccessLayer.DALContract;
using Bank.DataAccessLayer;
using Bank.Entities.Contracts;

namespace Bank.BusinessLogicLayer
{
    /// <summary>
    /// Represents customer business logic
    /// </summary>
    public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer
    {
        #region Private fields
        private ICustomersDataAccessLayer _customerDataLogicLayer;
        #endregion

        #region Constructors
        public CustomerBusinessLogicLayer()
        {
            _customerDataLogicLayer = new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Private property that represents reference of CustomersDataAccessLayer
        /// </summary>
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set=> _customerDataLogicLayer = value;
            get => _customerDataLogicLayer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// List all existing Customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //invoke DBL
                return CustomersDataAccessLayer.GetCustomers();
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check </param>
        /// <returns> The list of matching customers</returns>
        public List<Customer> GetCustomersByConditions(Predicate<Customer> predicate)
        {
            try
            {
                //invoke DBL
                return CustomersDataAccessLayer.GetCustomersByConditions(predicate);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add </param>
        /// <returns> Returns true, that indicates the customer is added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //get all customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustCode = 0;
                foreach(var item in allCustomers)
                {
                    if(item.CustomerCode> maxCustCode)
                    {
                        maxCustCode = item.CustomerCode;
                    }
                }

                //generate new customer no
                if(allCustomers.Count > 1)
                {
                    customer.CustomerCode= maxCustCode + 1;
                }
                else
                {
                    customer.CustomerCode = Bank.Configuration.Settings.BaseCustomerNo + 1;
                }

                //invoke DBL
                return CustomersDataAccessLayer.AddCustomer(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update </param>
        /// <returns> Returns true, that indicates the customer is updated successfully </returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //invoke DBL
                return CustomersDataAccessLayer.UpdateCustomer(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Deletes an existing customers
        /// </summary>
        /// <param name="customerId">CustomerId to delete </param>
        /// <returns>Returns true, that indicates the customer is updated successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                //invoke DBL
                return CustomersDataAccessLayer.DeleteCustomer(customerId);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
