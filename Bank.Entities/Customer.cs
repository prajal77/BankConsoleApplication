  using System;
using Bank.Entities.Contracts;
using Bank.Exceptions;


namespace Bank.Entities
{

    /// <summary>
    /// Represents customer of the bank
    /// </summary>
    public class Customer : ICustomer,ICloneable
    {
        #region Private fields
        private Guid _customerId;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion


        # region Public Properties
        /// <summary>
        /// Guid of Customer for Unique identification
        /// </summary>
        public Guid CustomerId { get => _customerId; set => _customerId = value; }
        /// <summary>
        /// Auto generated code number of the customer
        /// </summary>
        public long CustomerCode
        { 
            get => _customerCode; 
            set
            {
                //Customer code should be positive
                if(value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be positive only.");
                }
            } 
        }
        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName 
        { 
            get => _customerName; 
            set
            {
                if(value.Length <= 40 && string.IsNullOrEmpty(value)==false)
                {
                _customerName = value; 
                }
                else
                {
                    throw new CustomerException("Customer Name should be less than 40 character and shouldn't be null");
                }

            } 
        }
        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Address { get => _address; set => _address = value; }
        /// <summary>
        /// Landmark of the customer's address
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// City of the customer's 
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// Country of the customer's
        /// </summary>
        public string Country { get => _country; set => _country = value; }
        /// <summary>
        /// Mobile number of the customer
        /// </summary>
        public string Mobile
        {
            get => _mobile;
            set
            {
                if (value.Length == 10)
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number should be of 10-digit. ");
                }
            }
        }
        #endregion

        
        #region Methods
        //copy Instance into new instance
        public object Clone()
        {
            return new Customer()
            {
                CustomerId = this.CustomerId,
                CustomerName = this.CustomerName,
                Address = this.Address,
                Landmark = this.Landmark,
                Country = this.Country,
                Mobile = this.Mobile
            };
        }
        #endregion
    }
}
