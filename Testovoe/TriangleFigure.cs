namespace Testovoe;

public class TriangleFigure : IFigure
{
    private float[] _triangleSides;

    public float[] TriangleSides
    {
        get => (float[])_triangleSides.Clone();
    }

    public readonly bool Rectangular;
    
    public TriangleFigure(float a, float b, float c)
    {
        if(a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("All of triangle sides must be bigger than zero");
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Sum of any two triangle sides must be bigger than third");

        _triangleSides = new float[] {a, b, c};
        Array.Sort(_triangleSides);
        Rectangular = (MathF.Abs(MathF.Round(MathF.Pow(c, 2) - MathF.Pow(a, 2) - MathF.Pow(b, 2), 5))) < 0.0001;
    }
    
    public float Square()
    {
        if(Rectangular) return _triangleSides[0] * _triangleSides[1]/2.0f;
        
        float semiperimeter = (_triangleSides[0] + _triangleSides[1] + _triangleSides[2]) / 2.0f;
        return MathF.Sqrt(semiperimeter * (semiperimeter-_triangleSides[0]) * (semiperimeter-_triangleSides[1]) * (semiperimeter-_triangleSides[2]));
    }
}