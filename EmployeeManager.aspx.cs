using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
//using System.Windows.Forms;

namespace Comp600ContactManager 
{ 
    /*GUI to display employee details*/
    public partial class EmployeeManager : System.Web.UI.Page
    {
        private static EmpUtil empUtil;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                empUtil = new EmpUtil();
                Employee emp = empUtil.getCurrent();
                displayEmployee(emp); // calls displayEmployee function as the class initializes
            }
        }

        //This method display the details of employee in the GUI
        public void displayEmployee(Employee e)
        {
            firstName.Text = e.firstName;
            lastName.Text = e.lastName;
            middleInit.Text = e.middleInit.ToString();
            phoneNo.Text = e.phoneNumber;
            empId.Text = e.employeeNo.ToString();
            jobTitle.Text = e.jobDescription;
            
            Address a = e.address;
            city.Text = a.City;
            province.Text = a.Province;
            street.Text = a.Street;
            postalCode.Text = a.PostalCode;

            String earnings = e.getEarnings().ToString(System.Globalization.CultureInfo.InvariantCulture);
            weeklyEarnings.Text= earnings;
            if (e is SalaryEmployee) {
                getSalaryButton.Text = "Get Salary";
            } else
            {
                getSalaryButton.Text = "Get Hours";
            }

        }

    // method to search and display the employee details by employee ID
        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = empUtil.searchEmployeeById(Int32.Parse(empNoSearch.Text));
                if (emp != null)
                {
                    displayEmployee(emp);
                } else
                {
                    System.Windows.MessageBox.Show("Employee number was not found", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (NullReferenceException npe)
            {
                System.Windows.MessageBox.Show("Employee number was not found", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotFiniteNumberException nfe)
            {
                System.Windows.MessageBox.Show("Employee number shound be in number format", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("An Unexpected Error Occured", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    
    // Method to display hourly employee and monthly employee salary and  working hours details
        protected void getSalaryButton_Click(object sender, EventArgs e)
        {
            Employee emp = empUtil.getCurrent();
            decimal hours = 0;
            decimal monthlySalary = 0;
            //check whether this is an HourlyEmployee 
            if (emp is HourlyEmployee) {
                HourlyEmployee h = (HourlyEmployee)emp;
                hours = h.HoursWorked;
                System.Windows.MessageBox.Show("Hours worked in this period "+ hours, "", MessageBoxButton.OK, MessageBoxImage.Information);
                //check whether this is a Salary Employee
            } else if (emp is SalaryEmployee) {
                SalaryEmployee s = (SalaryEmployee)emp;
                monthlySalary = s.MonthlySalary;
                System.Windows.MessageBox.Show("Monthly Salary "+ monthlySalary, "", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                System.Windows.MessageBox.Show("Employee number was not found", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    // method to display the previous employee details
        protected void previousButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("previousButton_Click");
            System.Diagnostics.Debug.WriteLine("previousButton_Click");
            Employee emp = empUtil.getPrevious();
            //display employee
            displayEmployee(emp);
        }

    // method to display the next employee details
        protected void nextButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("nextButton_Click");
            System.Diagnostics.Debug.WriteLine("nextButton_Click");
            Employee emp1 = empUtil.getNext();
            //display employee
            displayEmployee(emp1);
        }

        // method to display the next employee details
        protected void timeSheetButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("timeSheetButton_Click");
            System.Diagnostics.Debug.WriteLine("timeSheetButton_Click");
            Response.Redirect("TimeSheet.aspx");

        }


        // method to make changes in the existing salary/hourly employee details and save
        protected void saveButton_Click1(object sender, EventArgs e)
        {
            Employee current = empUtil.getCurrent();
            Address a = new Address(street.Text,city.Text,
                    province.Text, postalCode.Text);
            Employee emp = null;
            if (current is SalaryEmployee)
            {
                decimal monthlySalary = ((SalaryEmployee)current).MonthlySalary;

                emp = new SalaryEmployee(monthlySalary, Int32.Parse(empId.Text), jobTitle.Text,
                       lastName.Text, firstName.Text, Char.Parse(middleInit.Text.ToString().Trim()),
                       phoneNo.Text, a);
            }
            else if (current is HourlyEmployee)
            {

                decimal hoursWorked = ((HourlyEmployee)current).HoursWorked;
                decimal hourlyRate = ((HourlyEmployee)current).HoursWorked;

                emp = new HourlyEmployee(hoursWorked, hourlyRate, Int32.Parse(empId.Text), jobTitle.Text,
                      lastName.Text, firstName.Text, Char.Parse(middleInit.Text.ToString().Trim()),
                      phoneNo.Text, a);

            }
            empUtil.updateEmployee(emp); 
        //message box to display the message when the employee data is updated
            System.Windows.MessageBox.Show("Employee Data Updated", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}