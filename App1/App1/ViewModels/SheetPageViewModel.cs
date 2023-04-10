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
        public event PropertyChangedEventHandler PropertyChanged;

        DayTask selectedTask;
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
        
        public ObservableCollection<DayTask> SheetTasks { get; set; }

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


        public Command AddAppointment { get; }
        public Command AddTodo { get; }
        public Command ClearSheet { get; }
        public Command ProvideInfo { get; }

        public async void AddAppointmentCommandHandler()
        {
            var vm = new AppointmentCreateViewModel(new Appointment(), SheetTasks);
            var page = new AppointmentCreatePage();
            page.BindingContext = vm;
            await Application.Current.MainPage.Navigation.PushModalAsync(page);            
        }

        public void AddTodoCommandHandler()
        {
            SheetTasks.Add(new Todo(new CheckBox(), String.Empty));
        }
        public void ClearSheetCommandHandler()
        {
            SheetTasks.Clear();
        }
        public void ProvideInfoCommandHandler()
        {

        }
    }
}
