namespace LetUsTalk.Utilities;

public class SizeClamp
{
    public readonly Limit Height;
    public readonly Limit Width;

    public SizeClamp(Limit height, Limit width)
    {
        Height = height;
        Width = width;
    }

    public static SizeClamp None()
    {
        return new SizeClamp(height: Limit.None(), width: Limit.None());
    }
}