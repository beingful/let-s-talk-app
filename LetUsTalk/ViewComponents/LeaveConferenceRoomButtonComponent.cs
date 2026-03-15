using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Interfaces;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed partial class LeaveConferenceRoomButtonComponent : ObservableObject
{
    private readonly IWindow _conferenceRoomWindow;

    public LeaveConferenceRoomButtonComponent(IWindow conferenceRoomWindow)
    {
        _conferenceRoomWindow = conferenceRoomWindow;
    }

    [RelayCommand]
    private void Click()
    {
        MainWindow mainWindow = new();

        mainWindow.Show();
        _conferenceRoomWindow.Close();
    }
}
