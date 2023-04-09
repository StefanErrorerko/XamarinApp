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
        
        Todo selectedTodo;
        Appointment selectedAppointment;
        public Todo SelectedTodo
        {
            get => selectedTodo;
            set
            {
                selectedTodo = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedTodo));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public Appointment SelectedAppointment
        {
            get => selectedAppointment;
            set
            {
                selectedAppointment = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedAppointment));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public ObservableCollection<Todo> SheetTodos { get; set; }
        public ObservableCollection<Appointment> SheetAppointments { get; set; }

        #region Constructor
        public SheetPageViewModel()
        {
            //SheetText = sheet;
            SheetTodos = new ObservableCollection<Todo>();
            SheetAppointments = new ObservableCollection<Appointment>();

            AddAppointment = new Command(() => AddAppointmentCommandHandler());
            AddTodo = new Command(() => AddTodoCommandHandler());
            ClearSheet = new Command(() =>ClearSheetCommandHandler());
            ProvideInfo = new Command(() => ProvideInfoCommandHandler());
        }
        #endregion

        

        //public Color SheetTextColor
        //{
        //    get => sheetTextColor;
        //    set
        //    {
        //        sheetTextColor = value;
        //        var args = new PropertyChangedEventArgs(nameof(SheetTextColor));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}


        public Command AddAppointment { get; }
        public Command AddTodo { get; }
        public Command ClearSheet { get; }
        public Command ProvideInfo { get; }

        public async void AddAppointmentCommandHandler()
        {
            var vm = new AppointmentCreateViewModel(new Appointment(), SheetAppointments);
            var page = new AppointmentCreatePage();
            page.BindingContext = vm;
            await Application.Current.MainPage.Navigation.PushModalAsync(page);            
        }

        public void AddTodoCommandHandler()
        {
            SheetTodos.Add(new Todo(new CheckBox(), String.Empty));
        }
        public void ClearSheetCommandHandler()
        {
            SheetTodos.Clear();
        }
        public void ProvideInfoCommandHandler()
        {

        }
    }
}
