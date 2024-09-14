using System.Collections;
using Testovoe;

namespace StandartFiguresTest;

public class CircleFigureTests
{
    [Theory]
    [ClassData(typeof(CircleFigure_Constructor_RadiusBelowZero_Cases))]
    public void Constructor_RadiusBelowZero_ArgumentException(float radius)
    {
        Assert.Throws<ArgumentException>(() => new CircleFigure(radius));
    }

    [Fact]
    public void Square_Correct()
    {
        var circleFigure = new CircleFigure(10.5f);
        Assert.InRange(circleFigure.Square(), 346.360, 346.361);
    }
    
    [Fact]
    public void Radius_Correct()
    {
        var circleFigure = new CircleFigure(10.5f);
        Assert.Equal(10.5f, circleFigure.Radius);
    }
}

public class CircleFigure_Constructor_RadiusBelowZero_Cases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new[] { (object)-100f };
        yield return new[] { (object)-10000.0f };
        yield return new[] { (object)-55.126f };
        yield return new[] { (object)-0.1f };
        yield return new[] { (object)-1f };
        for (int i = 0; i < 10; i++)
        {
            yield return new[] { (object)(-Random.Shared.NextSingle()) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}