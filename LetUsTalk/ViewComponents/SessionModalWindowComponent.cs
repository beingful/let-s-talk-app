using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Interfaces;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed partial class SessionModalWindowComponent : ObservableObject
{
    private readonly IWindow _mainWindow;
    private readonly IWindow _modalWindow;

    public SessionModalWindowComponent(IWindow mainWindow, IWindow modalWindow)
    {
        _mainWindow = mainWindow;
        _modalWindow = modalWindow;
        SessionComponent = new SessionComponent();
    }

    [ObservableProperty]
    private SessionComponent _sessionComponent;

    [RelayCommand]
    private void Connect()
    {
        if (!SessionComponent.IsValid())
        {
            return;
        }

        ConferenceRoom conferenceRoom = new();

        conferenceRoom.Show();

        _mainWindow.Close();
        _modalWindow.Close();
    }

    [RelayCommand]
    private void Cancel()
    {
        _modalWindow.Close();
    }
}
