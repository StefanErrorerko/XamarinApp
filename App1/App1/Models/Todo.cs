using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class Todo :DayTask
    {
        public CheckBox Check { get; set; }
        
        public Todo(CheckBox check, String content)
        {
            Check = check;
            Content = content;
            isTodo = true;
            isAppointment = false;
        }
    }
}
