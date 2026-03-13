using LetUsTalk.ViewComponents;
using LetUsTalk.ViewModels;
using LetUsTalk.Interfaces;

namespace LetUsTalk.Views;

public partial class ConnectToSessionWindow : WindowBase
{
    private readonly IWindow _mainWindow;

    public ConnectToSessionWindow()
        : this(null!)
    {
    }

    public ConnectToSessionWindow(IWindow mainWindow)
    {
        _mainWindow = mainWindow;
        Initialize();
    }

    protected override void Initialize()
    {
        InitializeComponent();
        InitializeDataContext();
    }

    protected override void InitializeDataContext()
    {
        DataContext = new ConnectToSessionWindowViewModel(
            sessionModalWindowComponent: new SessionModalWindowComponent(_mainWindow, this)
        );
    }
}
