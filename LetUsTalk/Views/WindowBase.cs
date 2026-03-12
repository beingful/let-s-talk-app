using System;
using Avalonia.Controls;
using LetUsTalk.Interfaces;

public abstract class WindowBase : Window
{
    public WindowBase()
    {
        Initialize();

        Opened += (_, _) => (DataContext as IInitializable)?.Initialize();
        Closed += (_, _) => (DataContext as IDisposable)?.Dispose();
        SizeChanged += (_, _) => (DataContext as IAdaptable)?.Adapt(Bounds);
    }

    protected virtual void Initialize()
    {
        InitializeDataContext();
    }

    protected abstract void InitializeDataContext();
}