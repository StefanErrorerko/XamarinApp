using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MainPageViewModel()
        {
            AllSheets = new ObservableCollection<SheetPageViewModel>();

            SelectedSheetChangedCommand = new Command(() => SelectedSheetChangedCommandHandler());

            AddSheet = new Command(() => AddSheetCommandHandler() );
        }
        #endregion

        #region Properties
        SheetPageViewModel selectedSheet;
        #endregion

        #region Fields
        public ObservableCollection<SheetPageViewModel> AllSheets { get; set; }

        public SheetPageViewModel SelectedSheet
        {
            get => selectedSheet;
            set
            {
                selectedSheet = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedSheet));
                PropertyChanged?.Invoke(this, args);
            }
        }
        #endregion

        #region Commands
        public Command SelectedSheetChangedCommand { get; }
        public Command AddSheet { get; }
        #endregion

        #region CommandHandlers
        private async void SelectedSheetChangedCommandHandler()
        {
            var sheetVM = SelectedSheet;
            var sheetPage = new SheetPage();
            sheetPage.BindingContext = sheetVM;
            await Application.Current.MainPage.Navigation.PushModalAsync(sheetPage);

        }

        private async void AddSheetCommandHandler()
        {
            var sheetVM = new SheetPageViewModel();
            var sheetPage = new SheetPage();
            AllSheets.Add(sheetVM);
            sheetPage.BindingContext = sheetVM;
            await Application.Current.MainPage.Navigation.PushModalAsync(sheetPage);
        }
        #endregion
    }
}
