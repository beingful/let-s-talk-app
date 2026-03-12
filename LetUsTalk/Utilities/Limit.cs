namespace LetUsTalk.Utilities;

public class Limit
{
    private Limit(RelativeNumber min, RelativeNumber max)
    {
        Min = min;
        Max = max;
    }

    public RelativeNumber Min { get; }

    public RelativeNumber Max { get; }

    public static Limit Set(RelativeNumber min, RelativeNumber max)
    {
        return new Limit(min, max);
    }

    public static Limit SetMin(RelativeNumber min)
    {
        return new Limit(min, max: new RelativeNumber
            {
                Base = double.PositiveInfinity,
                Factor = 1
            });
    }

    public static Limit SetMax(RelativeNumber max)
    {
        return new Limit(min: new RelativeNumber
            {
                Base = double.NegativeInfinity,
                Factor = 1
            }, max);
    }

    public static Limit None()
    {
        return new Limit(
            min: new RelativeNumber
            {
                Base = double.NegativeInfinity,
                Factor = 1
            },
            max: new RelativeNumber
            {
                Base = double.PositiveInfinity,
                Factor = 1
            }
        );
    }
}