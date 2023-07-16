using PocketChessClock.ViewModels;

namespace PocketChessClock;

public partial class App : Application
{
    public static MainPageViewModel MainPageViewModel { get; set; }

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Deactivated += OnWindowDeactivated;
        return window;
    }

    private void OnWindowDeactivated(object sender, EventArgs e)
    {
        if (MainPageViewModel != null)
        {
            MainPageViewModel.PausePlaying();
        }
    }
}