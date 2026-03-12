namespace LetUsTalk.Utilities;

public struct Factor
{
    public Factor(double heightFactor, double widthFactor)
    {
        HeightFactor = heightFactor;
        WidthFactor = widthFactor;
    }

    public double HeightFactor { get; set; }

    public double WidthFactor { get; set; }

    public static Factor None()
    {
        return new Factor(heightFactor: 1, widthFactor: 1);
    }
}