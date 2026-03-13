using System;
using Avalonia.Threading;
using LetUsTalk.Interfaces;
using LetUsTalk.Utilities.UI;
using LetUsTalk.ViewComponents;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class MainWindow : WindowBase, ISessionModalWindowHost
{
    public MainWindow()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        InitializeComponent();
        InitializeDataContext();
    }

    protected override void InitializeDataContext()
    {
        DataContext = new MainWindowViewModel(
            connectToSessionButtonComponent: new ConnectToSessionButtonComponent(
                sessionModalWindowHost: this,
                button: new Element(size: new Size(100, 100))
                    {
                        Caption = RunningCaption.Create("CONNECT TO SESSION", ' ', 4)
                    },
                runningTextTimer: new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(200)
                }
            ),
            createSessionButtonComponent: new CreateSessionButtonComponent(
                mainWindow: this,
                button: new Element(size: new Size(100, 100))
                    {
                        Caption = RunningCaption.Create("CREATE NEW SESSION", ' ', 4)
                    },
                runningTextTimer: new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(200)
                }
            )
        );
    }

    void ISessionModalWindowHost.ShowConnectToSessionWindow()
    {
        ConnectToSessionWindow dialog = new(this);

        _ = dialog.ShowDialog(this);
    }
}
