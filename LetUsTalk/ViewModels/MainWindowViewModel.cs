using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Views;

namespace LetUsTalk.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

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
