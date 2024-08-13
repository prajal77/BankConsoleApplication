﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Entities;

namespace Bank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents customers business logic
    /// </summary>
    public interface ICustomerBusinessLogicLayer
    {
        /// <summary>
        /// List all existing Customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check </param>
        /// <returns> The list of matching customers</returns>
        List<Customer> GetCustomersByConditions(Predicate<Customer> predicate);

        /// <summary>
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add </param>
        /// <returns> Returns true, that indicates the customer is added successfully</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update </param>
        /// <returns> Returns true, that indicates the customer is updated successfully </returns>
        bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Deletes an existing customers
        /// </summary>
        /// <param name="customerId">CustomerId to delete </param>
        /// <returns>Returns true, that indicates the customer is updated successfully</returns>
        bool DeleteCustomer(Guid customerId);

    }
}
