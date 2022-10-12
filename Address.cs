using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
   /*Address class with properties : Street, City, Province, Postal code*/
    public class Address    
    {
        //constructor
        public Address(string street, string city, string province, string postalCode)
        {
            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }
        //getters and setters method start
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        // getters and setters method end
    }
}
