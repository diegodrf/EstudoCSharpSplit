using System;
using System.Collections.Generic;
using System.Text;
using Split.Entities.Enums;

namespace Split.Entities
{
    class Customer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Customer()
        {
        }
        public Customer(string name, string identity, string identityType)
        {
            Name = name;
            Identity = identity;
            IdentityType = identityType;
        }

        public Customer(string name, string identity, string identityType, string email) : this(name, identity, identityType)
        {
            Email = email;
        }
        public Customer(string name, string identity, string identityType, string email, string mobile, string phone) : this(name, identity, identityType, email)
        {
            Mobile = mobile;
            Phone = phone;
        }
        public Customer(string name, string identity, string identityType, string email, string mobile, string phone, Address deliveryAddress, Address billingAddress) : this(name, identity, identityType, email, mobile, phone)
        {
            DeliveryAddress = deliveryAddress;
            BillingAddress = billingAddress;
        }
    }
    
}
