namespace LetUsTalk.Utilities;

public class RelativeNumber
{
    public RelativeNumber()
    {
        Base = 0;
        Factor = 1;
    }

    public double Base { get; set; }

    public double Factor { get; set; } = 1;

    public double Value => Base * Factor;

    public static RelativeNumber Zero()
    {
        return new RelativeNumber();
    }
}