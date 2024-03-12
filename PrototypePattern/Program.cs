var line = new OtherLine
{
    End = new Point
    {
        X = 0,
        Y = 10
    },
    Start = new Point
    {
        X = 10,
        Y = 20
    },
    Color = "Green"
};

Console.WriteLine(line);

var line2 = line.DeepCopy();
line2.Start.X = 0;
line2.Start.Y = 0;
line2.Color = "Red";

Console.WriteLine(line2);

public interface IPrototype<T>
    where T : new()
{
    void CopyTo(T target);

    public T DeepCopy()
    {
        T t = new();
        CopyTo(t);
        return t;
    }
}

public class Point : IPrototype<Point>
{
    public int X, Y;

    public void CopyTo(Point target)
    {
        target.Y = Y;
        target.X = X;
    }

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }
}

public class Line : IPrototype<Line>
{
    public Point Start, End;

    public void CopyTo(Line target)
    {
        target.Start = Start.DeepCopy();
        target.End = Start.DeepCopy();
    }

    public override string ToString()
    {
        return $"Start: {Start} | End: {End}";
    }
}

public class OtherLine : Line, IPrototype<OtherLine>
{
    public string Color { get; set; }
    public void CopyTo(OtherLine target)
    {
        target.Color = Color;
        target.Start = Start.DeepCopy();
        target.End = End.DeepCopy();
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Color: {Color}";
    }
}

public static class PrototypeExtensions
{
    public static T DeepCopy<T>(this IPrototype<T> prototype) where T : new()
    {
        return prototype.DeepCopy();
    }

    public static T DeepCopy<T>(this T prototype) where T: Line, new()
    {
        return ((IPrototype<T>)prototype).DeepCopy();
    }
}
