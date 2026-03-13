using LetUsTalk.Interfaces;
using LetUsTalk.Utilities.UI;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed class ConnectToSessionButtonComponent : MainButtonComponent
{
    private readonly ISessionModalWindowHost _sessionModalWindowHost;

    public ConnectToSessionButtonComponent(ISessionModalWindowHost sessionModalWindowHost, Element button, Avalonia.Threading.DispatcherTimer runningTextTimer)
        : base(button, runningTextTimer)
    {
        _sessionModalWindowHost = sessionModalWindowHost;
    }

    protected override void OnClick()
    {
        _sessionModalWindowHost.ShowConnectToSessionWindow();
    }
}
