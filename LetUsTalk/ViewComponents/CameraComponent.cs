using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;
using LetUsTalk.Utilities;

namespace LetUsTalk.ViewComponents;

public sealed partial class CameraComponent : ObservableObject, IInitializable, IDisposable
{
    private CameraStream? _cameraStream;
    private Task? _frameUpdateTask;
    private CancellationTokenSource? _frameUpdateCancellationTokenSource;

    [ObservableProperty]
    private IImage? _frame;

    public void Initialize()
    {
        if (_frameUpdateTask == null)
        {
            _frameUpdateCancellationTokenSource = new CancellationTokenSource();

            _cameraStream = CameraStream.Open();

            _frameUpdateTask = Task.Run(() => UpdateFrames(_frameUpdateCancellationTokenSource.Token));
        }
    }

    public void Dispose()
    {
        _frameUpdateCancellationTokenSource?.Cancel();

        while(_frameUpdateTask?.IsCompleted == false)
        {
            Task.Delay(50);
        }

        _frameUpdateTask?.Dispose();
        _frameUpdateTask = null;

        _frameUpdateCancellationTokenSource?.Dispose();
        _frameUpdateCancellationTokenSource = null;

        _cameraStream?.Dispose();
        _cameraStream = null;

        (Frame as Bitmap)?.Dispose();
        Frame = null;
    }

    private void UpdateFrames(CancellationToken token)
    {
        foreach (Bitmap currentFrame in _cameraStream!.ReadFrames(token))
        {
            Dispatcher.UIThread.Post(() =>
            {
                Bitmap? oldFrame = Frame as Bitmap;
                Frame = currentFrame;
                oldFrame?.Dispose();
            });
        }
    }
}
