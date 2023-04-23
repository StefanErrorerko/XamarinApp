using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public abstract class DayTask
    {
        public String Content { get; set; }
        public bool IsTodo { get; set; } = false;
        public bool IsAppointment { get; set; } = false;
        public bool IsPlainText { get; set; } = false;
    }
}
