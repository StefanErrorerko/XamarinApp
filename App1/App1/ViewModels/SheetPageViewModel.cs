using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using App1.Models;

namespace App1.ViewModels
{
    public class SheetPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public SheetPageViewModel()
        {
            //SheetText = sheet;
            SheetTasks = new ObservableCollection<DayTask>();

            AddAppointment = new Command(() => AddAppointmentCommandHandler());
            AddTodo = new Command(() => AddTodoCommandHandler());
            ClearSheet = new Command(() =>ClearSheetCommandHandler());
            ProvideInfo = new Command(() => ProvideInfoCommandHandler());
        }
        #endregion

        #region Properties
        DayTask selectedTask;
        String stringed = String.Empty;
        #endregion

        #region Fields
        public DayTask SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedTask));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public String Stringed
        {
            get => stringed;
            set
            {
                stringed = value;
                var args = new PropertyChangedEventArgs(nameof(Stringed));
                PropertyChanged?.Invoke(this, args);
            }
        }
        
        public ObservableCollection<DayTask> SheetTasks { get; set; }
        #endregion

        #region Commands
        public Command AddAppointment { get; }
        public Command AddTodo { get; }
        public Command ClearSheet { get; }
        public Command ProvideInfo { get; }
        #endregion

        #region CommandHandlers
        public async void AddAppointmentCommandHandler()
        {
            var vm = new AppointmentCreateViewModel(new Appointment(), SheetTasks);
            var page = new AppointmentCreatePage();
            page.BindingContext = vm;
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
            Stringed = ToString();
        }

        public void AddTodoCommandHandler()
        {
            SheetTasks.Add(new Todo(new CheckBox(), String.Empty));
            Stringed = ToString();
        }
        public void ClearSheetCommandHandler()
        {
            SheetTasks.Clear();
            Stringed = ToString();
        }
        public void ProvideInfoCommandHandler()
        {

        }
        #endregion

        #region Overrided Methods
        public override String ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in SheetTasks)
            {
                if (item.isTodo)
                {
                    var todo = (Todo)item;
                    if (todo.IsChecked)
                    {
                        sb.AppendLine("☑");
                    }
                    else
                    {
                        sb.AppendLine("❎");
                    }
                    sb.Append(item.Content);
                }
                if (item.isAppointment)
                {
                    var appointment = (Appointment)item;
                    sb.AppendLine(appointment.BeginningString);
                    sb.Append('-');
                    sb.Append(appointment.EndingString);
                    sb.Append(' ');
                    sb.Append(appointment.Content);
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
