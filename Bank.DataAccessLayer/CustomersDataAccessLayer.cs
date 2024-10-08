﻿using System;
using System.Collections.Generic;
using Bank.Entities;
using Bank.Exceptions;
using Bank.DataAccessLayer.DALContract;
namespace Bank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {

        #region Fields
        private static List<Customer> _customers;
        #endregion

        #region Constructors
         static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents source customers collection
        /// </summary>
        private static List<Customer> Customers
        {
            set => _customers = value; 
            get => _customers;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers List</returns>
        public  List<Customer> GetCustomers()
        {
            try
            {
                //create a new customer list
                List<Customer> customersList = new List<Customer>();
                //copy all customers from the source collection into the newCustomers list
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns> List of matching customers</returns>

        public  List<Customer> GetCustomersByConditions(Predicate<Customer> predicate)
        {
            try
            {
                //create a new customer list
                List<Customer> customersList = new List<Customer>();

                //filer the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                //copy all customers from the source collection into the newCustomers list
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new customer to the existing list
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns Guid of newly created customer</returns>

        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new GUID
                customer.CustomerId = Guid.NewGuid();

                //add customer
                Customers.Add(customer);

                return customer.CustomerId;
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
        /// Updates an existing customer's details
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Determines whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find existing customer by CustomerId
                Customer existingCustomer = Customers.Find(item => item.CustomerId == customer.CustomerId);

                //update all details of customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.Mobile = customer.Mobile;

                    return true;//customer is updated
                }
                else
                {
                    return false; //customer not updated
                }
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
        /// Delete an existing customer based on Customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                //delete customer by CustomerId
                if (Customers.RemoveAll(item => item.CustomerId == customerId) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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