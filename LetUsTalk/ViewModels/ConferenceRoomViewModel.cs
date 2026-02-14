using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using OpenCvSharp;

namespace LetUsTalk.ViewModels;

public sealed partial class ConferenceRoomViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty]
    private IImage? cameraFrame;

    private CancellationTokenSource? _captureCts;
    private Task? _captureTask;
    private VideoCapture? _capture;

    public void StartCamera()
    {
        if (_captureTask != null)
            return;

        /*if (OperatingSystem.IsMacOS())
            Environment.SetEnvironmentVariable("OPENCV_AVFOUNDATION_SKIP_AUTH", "1");*/

        // Open the capture device on the UI thread so macOS camera permission
        // flow is not triggered from a worker thread.
        _capture = new VideoCapture(0);
        if (!_capture.IsOpened())
        {
            _capture.Dispose();
            _capture = null;
            return;
        }

        _captureCts = new CancellationTokenSource();
        _captureTask = Task.Run(() => CaptureLoop(_capture, _captureCts.Token));
    }

    private void CaptureLoop(VideoCapture capture, CancellationToken token)
    {
        using Mat frame = new Mat();
        
        while (!token.IsCancellationRequested)
        {
            if (!capture.Read(frame) || frame.Empty())
                continue;

            byte[] encoded = frame.ImEncode(".bmp");
            using MemoryStream stream = new MemoryStream(encoded);
            Bitmap bitmap = new Bitmap(stream);

            Dispatcher.UIThread.Post(() =>
            {
                Bitmap? oldBitmap = CameraFrame as Bitmap;
                CameraFrame = bitmap;
                oldBitmap?.Dispose();
            });
        }
    }

    public void Dispose()
    {
        if (_captureCts == null)
            return;

        _captureCts.Cancel();
        _captureTask?.Wait(500);
        _captureTask = null;
        _captureCts.Dispose();
        _captureCts = null;

        _capture?.Dispose();
        _capture = null;

        (CameraFrame as Bitmap)?.Dispose();
        CameraFrame = null;
    }
}
