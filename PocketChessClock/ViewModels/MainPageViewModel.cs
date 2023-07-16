using PocketChessClock.Infrastructure.ViewModels;
using PocketChessClock.Models;
using PocketChessClock.Models.Enums;

namespace PocketChessClock.ViewModels;

public class MainPageViewModel : ViewModel
{
    private Player _firstSidePlayer;
    private Player _secondSidePlayer;
    private Player _currentPlayer;

    public Player FirstSidePlayer
    {
        get { return _firstSidePlayer; }
        set
        {
            if (_firstSidePlayer != value)
            {
                _firstSidePlayer = value;
                OnPropertyChanged(nameof(FirstSidePlayer));
            }
        }
    }

    public Player SecondSidePlayer
    {
        get { return _secondSidePlayer; }
        set
        {
            if (_secondSidePlayer != value)
            {
                _secondSidePlayer = value;
                OnPropertyChanged(nameof(SecondSidePlayer));
            }
        }
    }

    public Player CurrentPlayer
    {
        get { return _currentPlayer; }
        set
        {
            if (_currentPlayer != value)
            {
                _currentPlayer = value;
                FirstSideClockButtonCommand.ChangeCanExecute();
                SecondSideClockButtonCommand.ChangeCanExecute();
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
    }

    public Command FirstSideClockButtonCommand { get; set; }
    public Command SecondSideClockButtonCommand { get; set; }

    public MainPageViewModel()
    {
        _firstSidePlayer = new Player(SideType.White);
        _secondSidePlayer = new Player(SideType.Black);
        _currentPlayer = FirstSidePlayer;

        FirstSideClockButtonCommand = new Command(PushFirstSideClockButton, CanPushFirstSideClockButton);
        SecondSideClockButtonCommand = new Command(PushSecondSideClockButton, CanPushSecondSideClockButton);
    }

    public void PausePlaying()
    {
        CurrentPlayer.Stop();
    }

    private void PushFirstSideClockButton(object parameter)
    {
        CurrentPlayer = CurrentPlayer.Equals(FirstSidePlayer) ? SecondSidePlayer : FirstSidePlayer;
        FirstSidePlayer.Stop();
        SecondSidePlayer.Start();
    }

    private bool CanPushFirstSideClockButton(object parameter)
    {
        return CurrentPlayer.Side == SideType.White;
    }

    private void PushSecondSideClockButton(object parameter)
    {
        CurrentPlayer = CurrentPlayer.Equals(FirstSidePlayer) ? SecondSidePlayer : FirstSidePlayer;
        SecondSidePlayer.Stop();
        FirstSidePlayer.Start();
    }

    private bool CanPushSecondSideClockButton(object parameter)
    {
        return CurrentPlayer.Side == SideType.Black;
    }
}