using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
    /*Salary employee class extends employee with property monthly salary */
    public class SalaryEmployee : Employee
    {
        // constructor that calls parent class ( employee) constructor with base method
        public SalaryEmployee(decimal monthlySalary, int employeeNo, string jobDescription, string lastName, string firstName, char middleInit,
            string phoneNumber, Address address) : base(employeeNo, jobDescription, lastName, firstName, middleInit, phoneNumber, address)
        {
            setMonthlySalary(monthlySalary);
        }
        // getter and setter
        public decimal MonthlySalary { get; private set; }

        public void setMonthlySalary(decimal monthlySalary)
        {
            if(monthlySalary < 0)
            {
                MonthlySalary = 0;
            }
            else
            {
                MonthlySalary = monthlySalary;
            }
        }
        //This method override the parent class abstract method
        public override decimal getEarnings()
        {
            decimal income = (MonthlySalary * 12) / 26;
            decimal earnings = Math.Round(income * 100) / 100;
            return earnings;
        }
    }
}