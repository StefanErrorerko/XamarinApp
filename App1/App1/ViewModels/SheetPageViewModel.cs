using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class SheetPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SheetPageViewModel(String sheet)
        {
            SheetText = sheet;

            AddAppointment = new Command(() =>
            {
                SheetText = "Appointment adding";
            });
            AddTodo = new Command(() =>
            {
                SheetTextColor = Color.BlueViolet;
                SheetText = "Todo";
            });
            ClearSheet = new Command(() =>
            {
                SheetText = String.Empty;
                SheetTextColor = Color.Default;
            });
            ProvideInfo = new Command(() =>
            {
                SheetText = "Info";
            });
        }

        String sheetText;
        Color sheetTextColor;

        public String SheetText
        {
            get => sheetText;
            set
            {
                sheetText = value;
                var args = new PropertyChangedEventArgs(nameof(SheetText));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Color SheetTextColor
        {
            get => sheetTextColor;
            set
            {
                sheetTextColor = value;
                var args = new PropertyChangedEventArgs(nameof(SheetTextColor));
                PropertyChanged?.Invoke(this, args);
            }
        }


        public Command AddAppointment { get; }
        public Command AddTodo { get; }
        public Command ClearSheet { get; }
        public Command ProvideInfo { get; }
    }
}
