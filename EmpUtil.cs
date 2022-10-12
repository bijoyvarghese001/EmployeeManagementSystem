using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace Comp600ContactManager
{
    /*Utility class to get data and make seperation between presentation logic and business logic*/
    public class EmpUtil
    {
        private Employee[] employees;
        private int current;
        public EmpUtil()
        {
            System.Diagnostics.Debug.WriteLine(" In EmpUtil " );
            current = 0;
            getDataFromDB();
        }

        // method to fetch data from database
        public void getDataFromDB()
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            ArrayList emp = empDAO.getEmployees();
                      
            employees = new Employee[emp.Count];
            for (int i = 0; i < emp.Count; i++)
            {
                employees[i] = (Employee)emp[i];
            }
        }

        //Initialise the employees array with five employees and their address
        public void getData()
        {
            Address[] addresses = new Address[5];
            addresses[0] = new Address("123 Some St.", "Moose Jaw", "SK", "S6H-4R4");
            addresses[1] = new Address("321 Other St.", "Moose Jaw", "SK", "S6H-1V1");
            addresses[2] = new Address("555 Spooky St.", "Regina", "SK", "T6K-4R4");
            addresses[3] = new Address("123 East St.", "Kingston", "ON", "K7M-4G6");
            addresses[4] = new Address("678 West St", "Calgary", "AB", "Q3W-1S2");
            employees = new Employee[5];
            employees[0] = new SalaryEmployee(4000, 101, "Assisstant Manager", "Osborne", "Gavin", 'T', "306.691.1212",
                    addresses[0]);
            employees[1] = new HourlyEmployee((decimal)12.50, 30, 102, "Cook", "Goodwin", "Jane", 'S', "306.691.5567",
                    addresses[1]);
            employees[2] = new HourlyEmployee(10, 41, 103, "Bar Tender", "Jayesh ", "Sukhdeep",
                    'S', "306.694.2122", addresses[2]);
            employees[3] = new SalaryEmployee(5000, 104, "Manager", "Rina", "Meera ", 'K', "306.691.1213",
                    addresses[3]);
            employees[4] = new HourlyEmployee(10, 40, 105, "Bouncer", "Abhilash ", "Chandrakanta",
                    'C', "306.694.2139", addresses[4]);
        }


        //Search an employee by his ID/employee number
        public Employee searchEmployeeById(int empNo)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].employeeNo == empNo)
                {
                    return employees[i];
                }
            }
            return null;
        }

        //Update the current employee in the DB
        public void updateEmployee(Employee e)
        {
            employees[current] = e;
            EmployeeDAO empDAO = new EmployeeDAO();
            empDAO.updateEmployeeDB(e);

        }

        //Returns the current employee from the array of Employees
        public Employee getCurrent()
        {
            return employees[current];
        }

        //Returns the next employee from the array of Employees
        public Employee getNext()
        {
            current++;
            if (current > (employees.Length - 1))
            {
                current = 0;
            }
            return employees[current];
        }

        //Returns the previous employee from the array of Employees
        public Employee getPrevious()
        {
            current--;
            if (current < 0)
            {
                current = employees.Length - 1;
            }
            return employees[current];
        }
    }
}