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
        static string prevPage = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  {
                prevPage = Request.UrlReferrer.ToString();
                timesheetUtil = new TimesheetUtil();
                Timesheet[] data;
                String empId = Request.QueryString["empId"];
                if (empId != "")
                {
                    empTextBox.Text = empId;
                    strtWeekTextBox.Text = timesheetUtil.getWeekStartDate("current");
                    EndWeekTextBox.Text = timesheetUtil.getWeekEndDate("current");
                    data = timesheetUtil.getCurrentWeekDataFromDB(empId);
                    if (data != null) { 
                    displayPayrollData(data);
                } else
                    {
                        clearTheTextBoxes();
                    }
                    //System.Diagnostics.Debug.WriteLine(" data " + data);
                }
            }
        }

        public void clearTheTextBoxes()
        {
            monTextBox.Text = "";
            tueTextBox.Text = "";
            wedTextBox.Text = "";
            thuTextBox.Text = "";
            friTextBox.Text = "";
            satTextBox.Text = "";
            sunTextBox.Text = "";
            totHrsTextBox.Text = "";
        }

        public void displayPayrollData(Timesheet[] ts)
        {
               for (int i = 0; i < ts.Length; i++)
             {
                //empTextBox.Text = ts[i].EmpId.ToString();
                //strtWeekTextBox.Text = ts[i].StartDate.ToShortDateString();
                //EndWeekTextBox.Text = ts[i].EndDate.ToShortDateString();
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

        protected void submitTimesheetClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" submitTimesheetClick ");
            Timesheet1 t = new Timesheet1(getIntFromString(empTextBox.Text.ToString()), strtWeekTextBox.Text.ToString(), EndWeekTextBox.Text.ToString(),
                getFloatFromString(monTextBox.Text.ToString()), getFloatFromString(tueTextBox.Text.ToString()), getFloatFromString(wedTextBox.Text.ToString()),
                getFloatFromString(thuTextBox.Text.ToString()), getFloatFromString(friTextBox.Text.ToString()), getFloatFromString(satTextBox.Text.ToString()),
                getFloatFromString(sunTextBox.Text.ToString())
                );

            System.Diagnostics.Debug.WriteLine(" empTextBox.Text " + empTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" strtWeekTextBox.Text " + strtWeekTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" satTextBox.Text " + satTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" sunTextBox.Text " + sunTextBox.Text);

            timesheetUtil.insertEmployeeTimesheet(t);
            MessageBox.Show("Employee Timesheet Details Added To Database", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected void backButtonClick(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
        protected void updateTimesheetClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" updateTimesheetClick ");
            Timesheet1 t = new Timesheet1(getIntFromString(empTextBox.Text.ToString()), strtWeekTextBox.Text.ToString(), EndWeekTextBox.Text.ToString(),
                getFloatFromString(monTextBox.Text.ToString()), getFloatFromString(tueTextBox.Text.ToString()), getFloatFromString(wedTextBox.Text.ToString()),
                getFloatFromString(thuTextBox.Text.ToString()), getFloatFromString(friTextBox.Text.ToString()), getFloatFromString(satTextBox.Text.ToString()),
                getFloatFromString(sunTextBox.Text.ToString())
                );

            System.Diagnostics.Debug.WriteLine(" empTextBox.Text " + empTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" strtWeekTextBox.Text " + strtWeekTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" satTextBox.Text " + satTextBox.Text);
            System.Diagnostics.Debug.WriteLine(" sunTextBox.Text " + sunTextBox.Text);

            timesheetUtil.updateEmployeeTimesheet(t);
            MessageBox.Show("Employee Timesheet Details Updated To Database", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private float getFloatFromString(String value)
        {
            return float.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }

        private int getIntFromString(String value)
        {
            return int.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }


      
    protected void selectWeekClick(object sender, EventArgs e)
        {
            String empId = Request.QueryString["empId"];
            Timesheet[] data;
            System.Diagnostics.Debug.WriteLine(" dataselected " + DropDownList1.SelectedValue);
            if(DropDownList1.SelectedValue == "Previous")
            {
                strtWeekTextBox.Text = timesheetUtil.getWeekStartDate("previous");
                EndWeekTextBox.Text = timesheetUtil.getWeekEndDate("previous");
                data = timesheetUtil.getPreviousWeekDataFromDB(empId);

            } else if (DropDownList1.SelectedValue == "Next")
            {
                strtWeekTextBox.Text = timesheetUtil.getWeekStartDate("next");
                EndWeekTextBox.Text = timesheetUtil.getWeekEndDate("next");
                data = timesheetUtil.getNextWeekDataFromDB(empId);
            }
            else
            {
                strtWeekTextBox.Text = timesheetUtil.getWeekStartDate("current");
                EndWeekTextBox.Text = timesheetUtil.getWeekEndDate("current");
                data = timesheetUtil.getCurrentWeekDataFromDB(empId);

            }
            //displayPayrollData(data);
            if (data != null)
            {
                displayPayrollData(data);
            }
            else
            {
                clearTheTextBoxes();
            }
        }

    }
}