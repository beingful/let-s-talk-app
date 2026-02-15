using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class ConferenceRoom : Window
{
    private const double ChatWidthFactor = 0.32;
    private const double MinExpandedChatWidth = 220;
    private bool _isChatOpen;

    public ConferenceRoom()
    {
        InitializeComponent();

        Opened += (_, _) => (DataContext as ConferenceRoomViewModel)?.StartCamera();
        Closed += (_, _) => (DataContext as ConferenceRoomViewModel)?.Dispose();
        SizeChanged += (_, _) =>
        {
            if (_isChatOpen)
                ChatPanel.Width = GetExpandedChatWidth();
        };
    }

    private void ResizeThumb_OnDragDelta(object? sender, VectorEventArgs e)
    {
        if (CameraPreviewContainer is null)
            return;

        double maxWidth = Math.Max(CameraPreviewContainer.MinWidth, Bounds.Width - 32);
        double maxHeight = Math.Max(CameraPreviewContainer.MinHeight, Bounds.Height - 32);

        double newWidth = Math.Clamp(CameraPreviewContainer.Width + e.Vector.X, CameraPreviewContainer.MinWidth, maxWidth);
        double newHeight = Math.Clamp(CameraPreviewContainer.Height + e.Vector.Y, CameraPreviewContainer.MinHeight, maxHeight);

        CameraPreviewContainer.Width = newWidth;
        CameraPreviewContainer.Height = newHeight;
    }

    private void ChatToggleButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _isChatOpen = !_isChatOpen;

        ChatPanel.Width = _isChatOpen ? GetExpandedChatWidth() : 0;
    }

    private double GetExpandedChatWidth()
    {
        return Math.Max(MinExpandedChatWidth, Bounds.Width * ChatWidthFactor);
    }
}
