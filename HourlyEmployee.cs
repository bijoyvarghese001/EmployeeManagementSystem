using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
    /*Hourly employee class extends employee with properties hourly rate and hours worked */
    public class HourlyEmployee : Employee
    {
        // constructor that calls parent class ( employee) constructor with base method
        public HourlyEmployee(decimal hourlyRate, decimal hoursWorked, int employeeNo, string jobDescription, string lastName, string firstName, char middleInit,
            string phoneNumber, Address address) : base(employeeNo, jobDescription, lastName, firstName, middleInit, phoneNumber, address)
        {
            HourlyRate = hourlyRate;
            setHoursWorked(hoursWorked);
        }
        // getter and setter
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; private set; }

        public void setHoursWorked(decimal hoursWorked)
        {
            if(hoursWorked < 0)
            {
                HoursWorked = 0;
            }
            else
            {
                HoursWorked = hoursWorked;
            }
        }
        //This method override the parent class abstract method
        public override decimal getEarnings()
        {
            decimal earnings = 0;

            if (this.HoursWorked > 80)
            {
                earnings = ((HoursWorked - 80) * HourlyRate * (decimal)1.5) + 80 * HourlyRate;
            }
            else
            {
                earnings = HoursWorked * HourlyRate;
            }
            return earnings;
        }
    }
}