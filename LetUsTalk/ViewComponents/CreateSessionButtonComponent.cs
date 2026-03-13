using LetUsTalk.Interfaces;
using LetUsTalk.Utilities.UI;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed class CreateSessionButtonComponent : MainButtonComponent
{
    private readonly IWindow _mainWindow;

    public CreateSessionButtonComponent(IWindow mainWindow, Element button, Avalonia.Threading.DispatcherTimer runningTextTimer)
        : base(button, runningTextTimer)
    {
        _mainWindow = mainWindow;
    }

    protected override void OnClick()
    {
        ConferenceRoom conferenceRoom = new();

        conferenceRoom.Show();
        _mainWindow.Close();
    }
}
