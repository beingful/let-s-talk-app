using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Utilities.UI;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed partial class MainButtonComponent : ObservableObject, IDisposable
{
    private readonly Element _button;
    private readonly DispatcherTimer _timer;

    [ObservableProperty]
    private string _text;

    public MainButtonComponent(Element button, DispatcherTimer runningTextTimer)
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
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            ConferenceRoom conferenceRoom = new();

            conferenceRoom.Show();

            if (desktop.MainWindow is WindowBase currentWindow)
            {
                currentWindow.Close();
            }
        }
    }
}