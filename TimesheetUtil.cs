using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


namespace Comp600ContactManager
{
    public class TimesheetUtil
    {
        private Timesheet[] timesheetData;
        EmployeeDAO empDAO = new EmployeeDAO();

        //Update the Timesheet in the DB
        public void updateEmployeeTimesheet(Timesheet1 timesheet)
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            empDAO.updateTimesheetDB(timesheet);

        }

        public void insertEmployeeTimesheet(Timesheet1 timesheet)
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            empDAO.insertTimesheetDB(timesheet);

        }
        public Timesheet[] getCurrentWeekDataFromDB(String empNo)
        {
            
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            String WeekStart = thisWeekStart.ToString("yyyy-MM-dd");
            System.Diagnostics.Debug.WriteLine("thisWeekStart" + thisWeekStart);
            var thisWeekEnd = (thisWeekStart.AddDays(7).AddSeconds(-1)).ToString("yyyy-MM-dd");
            ArrayList data = empDAO.getWeekRangeDataDAO(Int32.Parse(empNo), WeekStart , thisWeekEnd);

            if (data == null || data.Count == 0)
                return null;

            timesheetData = new Timesheet[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                timesheetData[i] = (Timesheet)data[i];
            }
            return timesheetData;

        }

        public Timesheet[] getPreviousWeekDataFromDB(String empNo)
        {
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var lastWeekStart = thisWeekStart.AddDays(-7).ToString("yyyy-MM-dd");
            var lastWeekEnd = thisWeekStart.AddSeconds(-1).ToString("yyyy-MM-dd");

            ArrayList data = empDAO.getWeekRangeDataDAO(Int32.Parse(empNo), lastWeekStart, lastWeekEnd);
            if (data == null || data.Count == 0)
                return null;

            timesheetData = new Timesheet[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                timesheetData[i] = (Timesheet)data[i];
            }
            return timesheetData;
        }

        public Timesheet[] getNextWeekDataFromDB(String empNo)
        {
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var nxtweek = thisWeekStart.AddDays(7);
            var nextWeekStart = nxtweek.ToString("yyyy-MM-dd");
            var nextWeekEnd = (nxtweek.AddDays(7).AddSeconds(-1)).ToString("yyyy-MM-dd");

            ArrayList data = empDAO.getWeekRangeDataDAO(Int32.Parse(empNo), nextWeekStart, nextWeekEnd);
            if (data == null || data.Count == 0)
                return null;

            timesheetData = new Timesheet[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                timesheetData[i] = (Timesheet)data[i];
            }
            return timesheetData;
        }

        public String getWeekStartDate(String weekType)
        {
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            String CurrentWeekStart = thisWeekStart.ToString("yyyy-MM-dd");
            var previousWeekStart = thisWeekStart.AddDays(-7).ToString("yyyy-MM-dd");
            var nxtweek = thisWeekStart.AddDays(7);
            var nextWeekStart = nxtweek.ToString("yyyy-MM-dd");
            if(weekType == "previous")
            {
                return previousWeekStart;
            } else if (weekType == "next")
            {
                return nextWeekStart;
            } 
            return CurrentWeekStart;
        }

        public String getWeekEndDate(String weekType)
        {
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var currentWeekEnd = (thisWeekStart.AddDays(7).AddSeconds(-1)).ToString("yyyy-MM-dd");
            var previousWeekEnd = thisWeekStart.AddSeconds(-1).ToString("yyyy-MM-dd");
            var nxtweek = thisWeekStart.AddDays(7);
            var nextWeekEnd = (nxtweek.AddDays(7).AddSeconds(-1)).ToString("yyyy-MM-dd");
            if(weekType == "previous")
            {
                return previousWeekEnd;
            }
            else if (weekType == "next")
            {
                return nextWeekEnd;
            }
            return currentWeekEnd;
        }


    }
}