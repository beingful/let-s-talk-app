using System;
using System.Collections.Generic;
using System.Threading;
using Avalonia.Media.Imaging;

namespace LetUsTalk.Utilities;

internal sealed class CameraStream : IDisposable
{
    private readonly Camera _camera;

    private CameraStream()
    {
        _camera = new Camera();
    }

    internal static CameraStream Open()
    {
        return new CameraStream();
    }

    public IEnumerable<Bitmap> ReadFrames(CancellationToken cancellationToken = default)
    {
        if (_camera.Launched())
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                Bitmap? frame = _camera.CaptureFrame();

                if (frame == null)
                {
                    yield break;
                }

                yield return frame;
            }
        }
    }

    public void Dispose()
    {
        _camera?.Dispose();
    }
}
