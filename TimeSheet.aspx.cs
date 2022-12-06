using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Windows;

namespace Comp600ContactManager
{
    public partial class TimeSheet : System.Web.UI.Page
    {
        private static TimesheetUtil timesheetUtil; 
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (!Page.IsPostBack)  {
                timesheetUtil = new TimesheetUtil();
                Timesheet[] data;
                String empId = Request.QueryString["empId"];
                if (empId != "")
                {
                    
                    data = timesheetUtil.getCurrentWeekDataFromDB(empId);
                    displayPayrollData(data);
                    System.Diagnostics.Debug.WriteLine(" data " + data);
                }
           // }
        }

        public void displayPayrollData(Timesheet[] ts)
        {
               for (int i = 0; i < ts.Length; i++)
             {
                empTextBox.Text = ts[i].EmpId.ToString();
                strtWeekTextBox.Text = ts[i].StartDate.ToShortDateString();
                EndWeekTextBox.Text = ts[i].EndDate.ToShortDateString();
                monTextBox.Text = ts[i].Monday.ToString();
                tueTextBox.Text = ts[i].Tuesday.ToString();
                wedTextBox.Text = ts[i].Wednesday.ToString();
                thuTextBox.Text = ts[i].Thursday.ToString();
                friTextBox.Text = ts[i].Friday.ToString();
                satTextBox.Text = ts[i].Saturday.ToString();
                sunTextBox.Text = ts[i].Sunday.ToString();
                totHrsTextBox.Text =  getTotalHours(ts).ToString();
            }
        }
        public float getTotalHours(Timesheet[] weeklyData)
        {
            float totalHrs = 0;
            totalHrs = totalHrs + weeklyData[0].Monday + weeklyData[0].Tuesday + weeklyData[0].Wednesday +
                        weeklyData[0].Thursday + weeklyData[0].Friday + weeklyData[0].Saturday + weeklyData[0].Sunday;
            return totalHrs;

        }
        protected void selectWeekClick(object sender, EventArgs e)
        {
            String empId = Request.QueryString["empId"];
            Timesheet[] data;
            System.Diagnostics.Debug.WriteLine(" dataselected " + DropDownList1.SelectedValue);
            if(DropDownList1.SelectedValue == "Previous")
            {
                data = timesheetUtil.getPreviousWeekDataFromDB(empId);
            } else if (DropDownList1.SelectedValue == "Next")
            {
                 data = timesheetUtil.getNextWeekDataFromDB(empId);
            }
            else
            {
                data = timesheetUtil.getCurrentWeekDataFromDB(empId);
                
            }
            displayPayrollData(data);
        }

    }
}