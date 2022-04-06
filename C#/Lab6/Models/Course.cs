using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Course
    {
        // class attributes
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        // class constructor

        public Course(string code, string title, int weeklyHours)
        {
            Code = code;
            Title = title;
            WeeklyHours = weeklyHours;
        }

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }





    }
}
