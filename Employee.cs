using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
    /*Employee class which inherits from person class with properties employee no and job description*/
    public abstract class Employee : Person
    {
        //constructor which call parent class(person)constructor with base method
        protected Employee(int employeeNo, string jobDescription, string lastName, string firstName, char middleInit,
            string phoneNumber, Address address) : base(lastName, firstName, middleInit, phoneNumber, address)
        {
            this.employeeNo = employeeNo;
            this.jobDescription = jobDescription;
        }
        // getters and setters method start
        public int employeeNo { get; set; }
        public string jobDescription { get; set; }
        // getters and setters method end

        //abstract method
        public abstract decimal getEarnings();
    }
}