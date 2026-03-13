using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Utilities.UI;

namespace LetUsTalk.ViewComponents;

public abstract partial class MainButtonComponent : ObservableObject, IDisposable
{
    private readonly Element _button;
    private readonly DispatcherTimer _timer;

    [ObservableProperty]
    private string _text;

    protected MainButtonComponent(Element button, DispatcherTimer runningTextTimer)
    {
        _button = button;
        _timer = runningTextTimer;

        _timer.Tick += (_, _) => AnimateText();

        Text = button.Caption!.Text();
    }

    public void Initialize()
    {
        _timer.Start();
    } 

    public void Dispose()
    {
        _timer.Stop();
    }

    private void AnimateText()
    {
        Text = _button.Caption!.Text();
    }

    [RelayCommand]
    public void Click()
    {
        OnClick();
    }

    protected abstract void OnClick();
}
