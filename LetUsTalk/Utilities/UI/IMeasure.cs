namespace LetUsTalk.Utilities.UI;

public interface IMeasure
{
    public RelativeNumber Relation { get; }

    public Limit Limit { get; }

    public double Value { get; }
}