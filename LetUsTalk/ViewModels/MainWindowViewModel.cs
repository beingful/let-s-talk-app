using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;
using LetUsTalk.ViewComponents;

namespace LetUsTalk.ViewModels;

public sealed partial class MainWindowViewModel : ViewModelBase, IInitializable, IDisposable
{
    [ObservableProperty]
    private MainButtonComponent _mainButtonComponent;

    public MainWindowViewModel(MainButtonComponent mainButtonComponent)
    {
        MainButtonComponent = mainButtonComponent;
    }

    void IInitializable.Initialize()
    {
        MainButtonComponent.Initialize();
    }

    void IDisposable.Dispose()
    {
        MainButtonComponent.Dispose();
    }
}
