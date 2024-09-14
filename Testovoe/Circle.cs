namespace Testovoe;

public class Circle : IFigure
{
    private float _radius;
    public float Radius => _radius;
    
    public Circle(float radius)
    {
        if(radius <= 0)
            throw new ArgumentException("Radius should be bigger than 0", nameof(radius));
        _radius = radius;
    }
    
    public float Square()
    {
        return MathF.PI * MathF.Pow(_radius, 2);
    }
}