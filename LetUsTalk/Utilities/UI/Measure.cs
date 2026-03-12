using System;

namespace LetUsTalk.Utilities.UI;

public class Measure : IMeasure
{
    public Measure()
    {
        Relation = RelativeNumber.Zero();
        Limit = Limit.None();
        Collapsed = false;
    }

    public RelativeNumber Relation { get; init; }

    public Limit Limit { get; init; }

    public bool Collapsed { get; set; }

    public double Value => Collapsed == false
        ? Math.Clamp(Relation.Value, Limit.Min.Value, Limit.Max.Value)
        : 0;

    public static Measure None()
    {
        return new Measure
        {
            Relation = RelativeNumber.Zero(),
            Limit = Limit.None(),
            Collapsed = false
        };
    }
}