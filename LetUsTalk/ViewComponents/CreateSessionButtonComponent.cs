using LetUsTalk.Interfaces;
using LetUsTalk.Utilities.UI;

namespace LetUsTalk.ViewComponents;

public sealed class CreateSessionButtonComponent : MainButtonComponent
{
    private readonly ICreateSessionModalWindowHost _createSessionModalWindowHost;

    public CreateSessionButtonComponent(ICreateSessionModalWindowHost createSessionModalWindowHost, Element button, Avalonia.Threading.DispatcherTimer runningTextTimer)
        : base(button, runningTextTimer)
    {
        _createSessionModalWindowHost = createSessionModalWindowHost;
    }

    protected override void OnClick()
    {
        _createSessionModalWindowHost.ShowCreateSessionWindow();
    }
}
