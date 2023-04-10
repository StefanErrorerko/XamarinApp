using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public abstract class DayTask
    {
        public String Content { get; set; }
        public bool isTodo { get; set; }
        public bool isAppointment { get; set; }
    }
}
