using System;
using System.Collections.Generic;
using System.Text;

namespace Split.Entities
{
    class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Address()
        {
        }

        public Address(string street, string number, string complement, string zipCode, string city, string district, string state, string country)
        {
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            City = city;
            District = district;
            State = state;
            Country = country;
        }

        private string CheckFields(string value)
        {
            if (value.Length != 2)
            {
                throw new ArgumentException("This field need to be only 2 characters");
            }
            return value;
        }
    }
}
