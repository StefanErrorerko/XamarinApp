using App1.CustomRenderer;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SheetPage : ContentPage
    {
        public SheetPage()
        {
            InitializeComponent();
        }

        private void TitleEditor_Completed(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue?.Length > e.OldTextValue?.Length)
            {
                var key = e.NewTextValue?.Last() ?? ' ';
                if(key == '\n')
                {
                    TitleEditor.Text = e.OldTextValue;
                    TitleEditor.Unfocus();
                }
            }
            
        }
    }
}