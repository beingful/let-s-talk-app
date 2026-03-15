using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LetUsTalk.ViewComponents;

public sealed partial class ConferenceMenuComponent : ObservableObject
{
    [ObservableProperty]
    private ChatComponent _chatComponent;

    [ObservableProperty]
    private LeaveConferenceRoomButtonComponent _leaveConferenceRoomButtonComponent;

    public ConferenceMenuComponent(ChatComponent chatComponent, LeaveConferenceRoomButtonComponent leaveConferenceRoomButtonComponent)
    {
        ChatComponent = chatComponent;
        LeaveConferenceRoomButtonComponent = leaveConferenceRoomButtonComponent;
    }

    [RelayCommand]
    private void ChatToggleButtonClick()
    {
        ChatComponent.Expanded = !ChatComponent.Expanded;
    }
}
