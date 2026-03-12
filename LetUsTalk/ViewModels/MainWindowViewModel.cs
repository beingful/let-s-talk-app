using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;
using LetUsTalk.ViewComponents;

namespace LetUsTalk.ViewModels;

public sealed partial class MainWindowViewModel : ViewModelBase, IInitializable, IDisposable
{
    [ObservableProperty]
    private MainButtonComponent _connectToSessionButtonComponent;

    [ObservableProperty]
    private MainButtonComponent _createSessionButtonComponent;

    public MainWindowViewModel(MainButtonComponent connectToSessionButtonComponent, MainButtonComponent createSessionButtonComponent)
    {
        ConnectToSessionButtonComponent = connectToSessionButtonComponent;
        CreateSessionButtonComponent = createSessionButtonComponent;
    }

    void IInitializable.Initialize()
    {
        ConnectToSessionButtonComponent.Initialize();
        CreateSessionButtonComponent.Initialize();
    }

    void IDisposable.Dispose()
    {
        ConnectToSessionButtonComponent.Dispose();
        CreateSessionButtonComponent.Dispose();
    }
}
