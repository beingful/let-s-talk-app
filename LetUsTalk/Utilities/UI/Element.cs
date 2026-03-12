namespace LetUsTalk.Utilities.UI;

public class Element
{
    private readonly Size _size;

    public Element(Size? size = null)
    {
        _size = size ?? UI.Size.None();
    }

    public ISize Size => _size;

    public ICaption? Caption { get; init; }
}