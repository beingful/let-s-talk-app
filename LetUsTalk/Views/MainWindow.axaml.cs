using System;
using Avalonia.Threading;
using LetUsTalk.Utilities.UI;
using LetUsTalk.ViewComponents;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class MainWindow : WindowBase
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void InitializeDataContext()
    {
        DataContext = new MainWindowViewModel(
            connectToSessionButtonComponent: new MainButtonComponent(
                button: new Element(size: new Size(100, 100))
                    {
                        Caption = RunningCaption.Create("CONNECT TO SESSION", ' ', 4)
                    },
                runningTextTimer: new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(200)
                }
            ),
            createSessionButtonComponent: new MainButtonComponent(
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
}
