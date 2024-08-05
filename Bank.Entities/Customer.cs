﻿using System;
using Bank.Entities.Contracts;


namespace Bank.Entities
{
    public class Customer : ICustomer
    {
        private Guid _customerId;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;

        public Guid CustomerId { get => _customerId; set => _customerId = value; }
        public long CustomerCode { get => _customerCode; set => _customerCode = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string Address { get => _address; set => _address = value; }
        public string Landmark { get => _landmark; set => _landmark = value; }
        public string City { get => _city; set => _city = value; }
        public string Country { get => _country; set => _country = value; }
        public string Mobile { get => _mobile; set => _mobile = value; }
    }
}
