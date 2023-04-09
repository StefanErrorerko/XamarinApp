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
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            AllSheets = new ObservableCollection<SheetPageViewModel>();

            SelectedSheetChangedCommand = new Command(async () =>
            {
                var sheetVM = SelectedSheet;
                var sheetPage = new SheetPage();
                sheetPage.BindingContext = sheetVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(sheetPage);

            });

            AddSheet = new Command(async () =>
            {
                var sheetVM = new SheetPageViewModel();
                var sheetPage = new SheetPage();
                AllSheets.Add(sheetVM);
                sheetPage.BindingContext = sheetVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(sheetPage);
            });
        }
        
        public ObservableCollection<SheetPageViewModel> AllSheets { get; set; }

        SheetPageViewModel selectedSheet;

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

        public Command SelectedSheetChangedCommand { get; }
        public Command AddSheet { get; }
    }
}
