using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Appointment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Beginning { get;set; }
        public TimeSpan Ending { get;set; }

        public Appointment(String title, String descr, TimeSpan begin, TimeSpan end)
        {
            Title = title;
            Description = descr;
            Beginning = begin;
            Ending = end;
        }

        public Appointment()
        {
            Title = String.Empty;
            Description = String.Empty;
            Beginning = TimeSpan.Zero;
            Ending = TimeSpan.Zero;
        }
    }
}
