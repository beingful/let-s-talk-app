using System;
using System.IO;
using Avalonia.Media.Imaging;
using OpenCvSharp;

namespace LetUsTalk.Utilities;

public sealed class Camera : IDisposable
{
    private readonly VideoCapture _capture;

    public Camera()
    {
        _capture = new VideoCapture(0);
    }

    public bool Launched()
    {
        return _capture.IsOpened();
    }

    public Bitmap? CaptureFrame()
    {
        Bitmap? frame = null;

        using Mat frameArray = new();

        if (_capture.Read(frameArray) && frameArray.Empty() == false)
        {
            byte[] encoded = frameArray.ImEncode(".bmp");

            using MemoryStream stream = new(encoded);

            frame = new Bitmap(stream);
        }

        return frame;
    }

    public void Dispose()
    {
        _capture?.Dispose();
    }
}