using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp600ContactManager
{
    public class Timesheet1
    {
        public Timesheet1(int empId, String startDate , String endDate, float monday, float tuesday, float wednesday, float thursday ,
            float friday, float saturday ,float sunday)
        {
            EmpId = empId;
            StartDate = startDate;
            EndDate = endDate;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;

        }
        public int EmpId { get; set; }

        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public float Monday { get; set; }
        public float Tuesday { get; set; }
        public float Wednesday { get; set; }
        public float Thursday { get; set; }
        public float Friday { get; set; }
        public float Saturday { get; set; }
        public float Sunday {get; set; }



    }
}