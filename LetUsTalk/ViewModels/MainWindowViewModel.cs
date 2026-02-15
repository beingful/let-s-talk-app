using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Views;

namespace LetUsTalk.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly DispatcherTimer _connectTextTimer;
    private const string ConnectTextLoop = "⋅⋅⋅⋅Let⋅Us⋅Talk⋅⋅⋅⋅";
    private int _connectTextOffset;

    [ObservableProperty]
    private string connectButtonText = "Let Us Talk";

    public MainWindowViewModel()
    {
        _connectTextTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(280),
        };

        _connectTextTimer.Tick += (_, _) => AnimateConnectText();
        _connectTextTimer.Start();
    }

    public string Greeting { get; } = "Welcome to Avalonia!";

    private void AnimateConnectText()
    {
        _connectTextOffset = (_connectTextOffset + 1) % ConnectTextLoop.Length;
        ConnectButtonText = ConnectTextLoop[_connectTextOffset..] + ConnectTextLoop[.._connectTextOffset];
    }

    [RelayCommand]
    private void Connect()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
            return;

        ConferenceRoom conferenceRoom = new ConferenceRoom
        {
            DataContext = new ConferenceRoomViewModel(),
        };

        conferenceRoom.Show();

        if (desktop.MainWindow is Window currentWindow)
            currentWindow.Close();
    }
}
