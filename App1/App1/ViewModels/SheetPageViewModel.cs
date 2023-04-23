using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Linq;
using Xamarin.Forms.Internals;

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
            SheetTasks = new ObservableCollection<DayTask>()
            {
                new PlainText(placeholderText: String.Empty)
            };

            AddAppointment = new Command(() => AddAppointmentCommandHandler());
            AddTodo = new Command(() => AddTodoCommandHandler());
            ClearSheet = new Command(() =>ClearSheetCommandHandler());
            ProvideInfo = new Command(() => ProvideInfoCommandHandler());
            AddEditor = new Command(() => AddEditorCommandHandler());
        }
        #endregion

        #region Properties
        DayTask selectedTask;
        String stringed = String.Empty;
        String title;
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

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                var args = new PropertyChangedEventArgs(nameof(Title));
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
        public Command AddEditor { get; }
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
            if(String.IsNullOrEmpty(SheetTasks.Last().Content) && SheetTasks.Last().IsPlainText)
            {
                SheetTasks.RemoveAt(SheetTasks.Count - 1);
            }
            SheetTasks.Add(new Todo(new CheckBox(), String.Empty));
            AddPlainText(placeholderText: String.Empty);
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
        public void AddEditorCommandHandler()
        {
            AddPlainText(placeholderText: String.Empty);
        }
        #endregion

        #region Methods
        public override String ToString()
        {
            var sb = new StringBuilder();
            var item = SheetTasks.FirstOrDefault();
            var lineWidth = 45;
            if (item.IsTodo)
            {
                var todo = (Todo)item;
                if (todo.IsChecked)
                {
                    sb.Append("☑");
                }
                else
                {
                    sb.Append("▢");
                }
                var lastIndex = lineWidth - 5 > item.Content.Length ? item.Content.Length : lineWidth - 5;
                sb.Append(item.Content.Substring(0, lastIndex));
                if(item.Content.Length > lineWidth-5)
                {
                    sb.Append("...");
                }
            }
            if (item.IsAppointment)
            {
                var appointment = (Appointment)item;
                sb.Append(appointment.BeginningString);
                sb.Append('-');
                sb.Append(appointment.EndingString);
                sb.Append(' ');
                var lastIndex = lineWidth - 12 > item.Content.Length ? item.Content.Length : lineWidth - 12;
                sb.Append(appointment.Content.Substring(0, lastIndex));
                if(appointment.Content.Length > lineWidth)
                {
                    sb.Append("...");
                }
            }
            if (item.IsPlainText)
            {
                var lastIndex = lineWidth > item.Content.Length ? item.Content.Length : lineWidth;
                sb.Append(item.Content.Substring(0, lastIndex));
                if(item.Content.Length > lineWidth)
                {
                    sb.Append("...");
                }
            }
            return sb.ToString();
        }

        public void AddPlainText(String placeholderText)
        {
            SheetTasks.Add(new PlainText(placeholderText));
        }
        #endregion
    }
}
