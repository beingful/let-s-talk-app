namespace LetUsTalk.Utilities.UI;

public interface ISize
{
    public IMeasure Height { get; }

    public IMeasure Width { get; }

    public void Expand();

    public void Collapse();
}