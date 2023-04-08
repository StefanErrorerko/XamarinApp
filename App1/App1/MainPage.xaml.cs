using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void ButtonAddAppointClick(object sender, EventArgs e)
        {
            MainSheet.Text = "AppointButton is Clicked!";
        }

        public void ButtonAddTodoClick(object sender, EventArgs e) 
        {
            MainSheet.Text = "TodoButton is Clicked";
            MainSheet.TextColor = Color.Aquamarine;
        }

        public void ButtonClearNoteClick(object sender, EventArgs e) 
        {
            MainSheet.Text = "nothing";
            MainSheet.TextColor = Color.Black;
        }

        public void ButtonInfoClick(object sender, EventArgs e) 
        {
            MainSheet.TextColor = Color.Aqua;
        }

    }
}
