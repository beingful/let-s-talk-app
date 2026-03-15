using LetUsTalk.Interfaces;
using LetUsTalk.Models;
using LetUsTalk.Services.Genertor;
using LetUsTalk.Services.Validation;
using LetUsTalk.ViewComponents;
using LetUsTalk.ViewModels;

namespace LetUsTalk.Views;

public partial class CreateSessionWindow : WindowBase
{
    private readonly IWindow _mainWindow;

    public CreateSessionWindow()
        : this(null!)
    {
    }

    public CreateSessionWindow(IWindow mainWindow)
    {
        _mainWindow = mainWindow;
        Initialize();
    }

    protected override void Initialize()
    {
        InitializeComponent();
        InitializeDataContext();
    }

    protected override void InitializeDataContext()
    {
        DataContext = new CreateSessionWindowViewModel(
            createSessionModalWindowComponent: new CreateSessionModalWindowComponent(
                mainWindow: _mainWindow,
                modalWindow: this,
                randomStringGenerator: new RandomStringGenerator(
                    charactersPool: new CharactersPoolBuilder()
                        .WithLetters()
                        .WithNumbers()
                        .ToString(),
                    minLength: 4,
                    maxLength: 12
                ),
                sessionComponent: new SessionComponent(
                    session: new Session(),
                    validator: new CreateSessionValidator()
                )
            )
        );
    }
}
