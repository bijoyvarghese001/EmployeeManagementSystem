using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
    /*person class with details of person - first name , last name, middleinit and address */
    public class Person
    {
        //constructor
        public Person(string lastName, string firstName, char middleInit, string phoneNumber, Address address)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleInit = middleInit;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
        // getters and setters method start
        public string lastName { get; set; }
        public string firstName { get; set; }
        public char middleInit { get; set; }
        public string phoneNumber { get; set; }
        public Address address { get; set; }
        // getters and setters method end

}
}