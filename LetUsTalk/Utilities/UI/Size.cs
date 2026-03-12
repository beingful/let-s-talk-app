namespace LetUsTalk.Utilities.UI;

public class Size : ISize
{
    private readonly Measure _height;
    private readonly Measure _width;

    public Size(Measure height, Measure width)
    {
        _height = height;
        _width = width;
    }

    public Size(double height, double width)
    {
        _height = new Measure
        {
            Relation = new RelativeNumber
            {
                Base = height
            }
        };

        _width = new Measure
        {
            Relation = new RelativeNumber
            {
                Base = width
            }
        };
    }

    public IMeasure Height => _height;

    public IMeasure Width => _width;

    public void Expand()
    {
        _height.Collapsed = false;
        _width.Collapsed = false;
    }

    public void Collapse()
    {
        _height.Collapsed = true;
        _width.Collapsed = true;
    }

    public static Size None()
    {
        return new Size(
            height: Measure.None(),
            width: Measure.None());
    }
}