using System.Runtime.InteropServices;
using Testovoe;

namespace StandartFiguresTest;

public class TriangleFigureTests
{
    [Fact]
    public void Triangle_Rectangular()
    {
        var testTriangle = new TriangleFigure(3, 4, 5);
        Assert.True(testTriangle.Rectangular);
    }
    
    [Fact]
    public void Triangle_Not_Rectangular()
    {
        var testTriangle = new TriangleFigure(3, 4, 6);
        Assert.False(testTriangle.Rectangular);
    }

    [Theory]
    [InlineData(3,4,0)]
    [InlineData(1,-10,1)]
    [InlineData(-1, 5, 2)]
    public void Triangle_ZeroSide_ArgumentException(float a, float b, float c)
    {
        Assert.Throws<ArgumentException>(() => new TriangleFigure(a,b,c));
    }

    [Theory]
    [InlineData(1,1,3)]
    [InlineData(1,10,3)]
    [InlineData(9,1,3)]
    public void Triangle_WrongSides_ArgumentException(float a, float b, float c)
    {
        Assert.Throws<ArgumentException>(() => new TriangleFigure(a,b,c));
    }

    [Theory]
    [InlineData(3,4,5,(3*4)/2)]
    [InlineData(3,3,4, 4.472f)]
    [InlineData(10, 15, 13, 64.0624f)]
    public void Triangle_Square_Correct(float a, float b, float c, float correctSquare)
    {
        var triangle = new TriangleFigure(a,b,c);
        var square = MathF.Round(triangle.Square(), 4);
        Assert.InRange(square, correctSquare-0.0001f,correctSquare+0.0001f);
    }

    [Fact]
    public void Triangle_Sides_Equals()
    {
        var triangle = new TriangleFigure(4.0f, 5.105f, 3.505f);
        Assert.Equal(triangle.TriangleSides, new [] {3.505f, 4.0f, 5.105f});
    }
}