using PocketChessClock.ViewModels;

namespace PocketChessClock;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        DeviceDisplay.Current.KeepScreenOn = true;

        MainPageViewModel mainPageViewModel = new MainPageViewModel();
        App.MainPageViewModel = mainPageViewModel;
        BindingContext = mainPageViewModel;
    }
}