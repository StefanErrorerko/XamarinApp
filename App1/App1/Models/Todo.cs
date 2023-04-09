using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class Todo
    {
        public CheckBox Check { get; set; }
        public String Content { get; set; }
        
        public Todo(CheckBox check, String content)
        {
            Check = check;
            Content = content;
        }
    }
}
