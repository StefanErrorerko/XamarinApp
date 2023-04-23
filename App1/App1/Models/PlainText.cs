using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class PlainText : DayTask
    {
        public String PlaceholderText { get;set; }
        public PlainText()
        {
            Content = String.Empty;
            IsPlainText = true;
            PlaceholderText = String.Empty;
        }
        public PlainText(String placeholderText)
        {
            PlaceholderText = placeholderText;
            Content = String.Empty;
            IsPlainText = true;
        }
    }
}
