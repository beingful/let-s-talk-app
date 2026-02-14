using Avalonia.Controls;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class ConferenceRoom : Window
{
    public ConferenceRoom()
    {
        InitializeComponent();

        Opened += (_, _) => (DataContext as ConferenceRoomViewModel)?.StartCamera();
        Closed += (_, _) => (DataContext as ConferenceRoomViewModel)?.Dispose();
    }
}
