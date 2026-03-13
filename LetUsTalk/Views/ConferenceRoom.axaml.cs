using LetUsTalk.ViewComponents;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class ConferenceRoom : WindowBase
{
    public ConferenceRoom()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        InitializeComponent();
        InitializeDataContext();
    }

    protected override void InitializeDataContext()
    {
        DataContext = new ConferenceRoomViewModel(
            cameraContainerComponent: new CameraContainerComponent(
                cameraComponent: new CameraComponent(),
                borderComponent: new DraggableBorderComponent(
                    borderControl: CameraViewBorder
                )
            ),
            menuComponent: new ConferenceMenuComponent(
                chatComponent: new ChatComponent(
                    expanded: false
                )
            )
        );
    }
}
