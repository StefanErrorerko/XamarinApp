using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Appointment : DayTask
    {
        public string Title { get; set; }
        public TimeSpan Beginning { get;set; }
        public TimeSpan Ending { get;set; }
        public String BeginningString { get => Beginning.ToString(@"hh\:mm");}
        public String EndingString { get => Beginning.ToString(@"hh\:mm"); }


        public Appointment(String title, String descr, TimeSpan begin, TimeSpan end)
        {
            Title = title;
            Content = descr;
            Beginning = begin;
            Ending = end;
            isTodo = false;
            isAppointment = true;
        }

        public Appointment()
        {
            Title = String.Empty;
            Content = String.Empty;
            Beginning = TimeSpan.Zero;
            Ending = TimeSpan.Zero;
        }
    }
}
