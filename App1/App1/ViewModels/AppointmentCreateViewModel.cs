using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using App1.Models;

using Xamarin.Forms;

namespace App1.ViewModels
{
	public class AppointmentCreateViewModel : INotifyPropertyChanged
	{
		public Appointment AppointmentProcessed { get; set; }
        public ObservableCollection<Appointment> SheetAppointments { get; set; }
        public AppointmentCreateViewModel() { }
		public AppointmentCreateViewModel (Appointment appointment, ObservableCollection<Appointment> sheetAppointments)
		{
            AppointmentProcessed = appointment;
            SheetAppointments = sheetAppointments;
			Submit = new Command(() => SubmitCommandHandler());
		}

        public event PropertyChangedEventHandler PropertyChanged;
        public String title;
        public String description;
        public TimeSpan begin;
        public TimeSpan end;


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

        public Command Submit { get; }

		public async void SubmitCommandHandler()
		{
            AppointmentProcessed.Title = title;
            AppointmentProcessed.Description = description;
            AppointmentProcessed.Beginning = begin;
            AppointmentProcessed.Ending = end;
            var appointment = AppointmentProcessed.Copy();
            SheetAppointments.Add(appointment);
            await Application.Current.MainPage.Navigation.PopModalAsync();
		}
    }
}