using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Collections;
using System.Windows.Forms;

namespace Comp600ContactManager
{
    public class EmployeeDAO
    {

        public SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                
                String connectionURL = "Server=LAPTOP-KG0A7HJB;Database=EmployessDB;User ID=EmpDBApps;Password=java1;Trusted_Connection=False;";
                conn = new SqlConnection(connectionURL);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return conn;
        }
        public ArrayList getEmployees()
        {
            ArrayList employee = new ArrayList();
            try
            {
                System.Diagnostics.Debug.WriteLine(" DAO 3 ");
                SqlConnection conn = getConnection();
                SqlCommand sqlcmd = new SqlCommand("Select * from Employee e INNER JOIN SalaryEmployee s ON e.EmpId = s.EmpId", conn);
                using (SqlDataReader r = sqlcmd.ExecuteReader())
                {
                    System.Diagnostics.Debug.WriteLine(" Inside ExecuteReader 1 ");
                    while (r.Read())
                    {
                        Address address = new Address(r["Street"].ToString(), r["City"].ToString(), r["Province"].ToString(), r["PostalCode"].ToString());
                        SalaryEmployee se = new SalaryEmployee(decimal.Parse(r["MonthlySalary"].ToString()), (int)r["EmpId"], r["JobDescription"].ToString(), r["FirstName"].ToString(), r["LastName"].ToString(), char.Parse(r["MiddleInit"].ToString().Trim()), r["PhoneNumber"].ToString(), address);

                        employee.Add(se);
                    }
                }

                sqlcmd = new SqlCommand("Select * from Employee e INNER JOIN HourlyEmployee h ON e.EmpId = h.EmpId", conn);
                using (SqlDataReader r = sqlcmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address address = new Address(r["Street"].ToString(), r["City"].ToString(), r["Province"].ToString(), r["PostalCode"].ToString());
                        HourlyEmployee he = new HourlyEmployee(decimal.Parse(r["HourlyRate"].ToString()), decimal.Parse(r["HoursWorked"].ToString()), (int)r["EmpId"], r["JobDescription"].ToString(), r["FirstName"].ToString(), r["LastName"].ToString(), char.Parse(r["MiddleInit"].ToString().Trim()), r["PhoneNumber"].ToString(), address);
                        employee.Add(he);
                    }
                }
                conn.Close();
                System.Diagnostics.Debug.WriteLine(" Employee count " + employee.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return employee;
        }


        public void updateEmployeeDB(Employee e)
        {
            SqlConnection conn = getConnection();
            Address a = e.address;

            try
            {
             
                String cmdText = "Update Employee set LastName ='" + e.lastName + "', FirstName = '" + e.firstName
                    + "', MiddleInit = '" + e.middleInit + "', Street ='" + a.Street + "', City ='" + a.City
                    + "', Province='" + a.Province + "', PostalCode='" + a.PostalCode
                    + "', PhoneNumber='" + e.phoneNumber + "', JobDescription='" + e.jobDescription
                    + "' WHERE EmpId=" + e.employeeNo;

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.ExecuteNonQuery();

                if (e is HourlyEmployee)
                {
                    HourlyEmployee h = (HourlyEmployee)e;
                    cmdText = "Update HourlyEmployee set Hours=" + h.HoursWorked + ", HourlyRate=" + h.HourlyRate
                        + " WHERE EmpId = " + h.employeeNo;
                }
                else if (e is SalaryEmployee)
                {
                    SalaryEmployee s = (SalaryEmployee)e;
                    cmdText = "Update SalaryEmployee Set MonthlySalary=" + s.MonthlySalary
                        + " WHERE EmpId = " + s.employeeNo;
                }
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}