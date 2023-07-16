using System.Timers;
using PocketChessClock.Infrastructure.ViewModels;
using PocketChessClock.Models.Enums;
using Timer = System.Timers.Timer;

namespace PocketChessClock.Models;

public class Player : ViewModel
{
    private const double TimerIntervalMs = 100;

    private readonly Timer _timer;
    private TimeSpan _time;

    public string TimeValue
    {
        get
        {
            return _time.ToString(@"mm\:ss");
        }
    }

    public SideType Side { get; set; }

    public Player(SideType side)
    {
        Side = side;
        _timer = new Timer(TimerIntervalMs);
        _timer.Elapsed += OnTimerElapsed;
        _timer.Enabled = false;

        _time = TimeSpan.FromSeconds(3 * 60);
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        _time = _time.Subtract(TimeSpan.FromMilliseconds(TimerIntervalMs));
        OnPropertyChanged(nameof(TimeValue));
    }

    public bool Equals(Player otherPlayer)
    {
        return Side == otherPlayer.Side;
    }
}