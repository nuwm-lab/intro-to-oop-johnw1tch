class SquareEquation
{
    protected float _b2;
    protected float _b1;
    protected float _b0;

    public SquareEquation() { }
    public SquareEquation(float b2, float b1, float b0)
    {
        _b2 = b2; 
        _b1 = b1; 
        _b0 = b0;
    }
    public void Setb0(float b) { this._b0 = b; }
    public void Setb1(float b) { this._b1 = b; }
    public void Setb2(float b) { this._b2 = b; }
    public float Getb0() { return _b0; }
    public float Getb1() { return _b1; }
    public float Getb2() { return _b2; }
    public string PrintB()
    {
        return _b2 + "," + _b1 + "," + _b0;
    }
    public bool X1val_Valid(float x)
    {
        if (_b2 * (x * x) + _b1 * x + _b0 == 0) { return true; }
        else { return false; }
    }
    public double? GetSolution(int n)
    {
        double D = _b1 * _b1 - 4 * _b2 * _b0;
        if (D < 0) return null;
        else if (n == 1) return (-1) * _b1 + Math.Sqrt(D) / 2 * _b2;
        else if (n == 2 && D != 0) return (-1) * _b1 + (-1) * Math.Sqrt(D) / 2 * _b2;
        else return null;
    }
}
class CubicEquation : SquareEquation
{
    private float _a0;

    public CubicEquation(float b2, float b1, float b0, float a0) 
    { 
        _b2 = b2;
        _b1 = b1;
        _b0 = b0;
        _a0 = a0; 
    }

    public float Geta0() {return _a0;}
    public void Seta0(float a0) { this._a0 = a0; }

    public void PrintA()
    {
        Console.WriteLine(_b2 + "," + _b1 + "," + _b0 + "," + _a0 + ",");
    }
    public bool X2val_Valid(float x)
    {
        if (_b2 * (x * x * x) + _b1 * (x * x) + _b0 * x + _a0 == 0) return true;
        else return false;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a3=b2,a2=b1,a1=b0,a0:");
            float a3 = float.Parse(Console.ReadLine());
            float a2 = float.Parse(Console.ReadLine());
            float a1 = float.Parse(Console.ReadLine());
            float a0 = float.Parse(Console.ReadLine());
            CubicEquation CubEqu = new(a3, a2, a1, a0);
            Console.WriteLine("Solutions for a square equation with b2,b1,b0 =" + CubEqu.PrintB() + " are :" + CubEqu.GetSolution(1) + " and " + CubEqu.GetSolution(2));
            Console.WriteLine("Write x for Cubic equation " + CubEqu.Getb2() + "*x^3+" + CubEqu.Getb1() + "*x^2+" + CubEqu.Getb0() + "*x+" + CubEqu.Geta0() + " : ");
            float x = float.Parse(Console.ReadLine());
            if (CubEqu.X2val_Valid(x))
            {
                Console.WriteLine("the x is correct!");
            }
            else Console.WriteLine("the x is incorrect");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
