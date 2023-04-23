using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using App1.Models;
using App1.Models.ModelExtensions;

using Xamarin.Forms;

namespace App1.ViewModels
{
        
    public class AppointmentCreateViewModel : INotifyPropertyChanged
    {

        #region Constructors
        public AppointmentCreateViewModel() { }
        public AppointmentCreateViewModel(Appointment appointment, ObservableCollection<DayTask> sheetTasks)
        {
            AppointmentProcessed = appointment;
            LabelError = String.Empty;
            SheetTasks = sheetTasks;
            Submit = new Command(() => SubmitCommandHandler());
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public String title;
        public String description;
        public TimeSpan begin;
        public TimeSpan end;
        public String labelError;
        #endregion

        #region Fields
        public Appointment AppointmentProcessed { get; set; }
        public ObservableCollection<DayTask> SheetTasks { get; set; }
        public String Title
        {
            get => title;
            set
            {
                title = value;
                var args = new PropertyChangedEventArgs(nameof(Title));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public String Description
        {
            get => description;
            set
            {
                description = value;
                var args = new PropertyChangedEventArgs(nameof(Description));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public TimeSpan Begin
        {
            get => begin;
            set
            {
                begin = value;
                var args = new PropertyChangedEventArgs(nameof(Begin));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public TimeSpan End
        {
            get => end;
            set
            {
                end = value;
                var args = new PropertyChangedEventArgs(nameof(End));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public String LabelError
        {
            get => labelError;
            set
            {
                labelError = value;
                var args = new PropertyChangedEventArgs(nameof(LabelError));
                PropertyChanged?.Invoke(this, args);
            }
        }
        #endregion

        #region Commands
        public Command Submit { get; }
        #endregion

        #region CommandHandlers
        public async void SubmitCommandHandler()
        {
            LabelError = String.Empty;
            // if end of appoint. is bigger than begin in more than 5 mins.
            if(String.IsNullOrEmpty(title) || String.IsNullOrEmpty(description))
            {
                LabelError = "You left one or more fields empty;";
                return;
            }
            else if(end - begin < new TimeSpan(0, 5, 0)){
                LabelError = "You input invalid time interval for an appointment";
                return;
            }
            AppointmentProcessed.Title = title;
            AppointmentProcessed.Content = description;
            AppointmentProcessed.Beginning = begin;
            AppointmentProcessed.Ending = end;
            var appointment = AppointmentProcessed.Copy();
            if (String.IsNullOrEmpty(SheetTasks.Last().Content) && SheetTasks.Last().IsPlainText)
            {
                SheetTasks.RemoveAt(SheetTasks.Count - 1);
            }
            SheetTasks.Add(appointment);
            SheetTasks.Add(new PlainText(placeholderText: String.Empty));
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}