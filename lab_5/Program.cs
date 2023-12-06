
using System;


class SquareEquation
{
    protected float _b2;
    protected float _b1;
    protected float _b0;
    public SquareEquation() 
    { 
    
    }
    public SquareEquation(float b2, float b1, float b0)
    {
        _b2 = b2;
        _b1 = b1;
        _b0 = b0;
    }
    public void SetB0(float b) 
    {
        _b0 = b;
    }
    public void SetB1(float b) 
    {
        _b1 = b; 
    }
    public void SetB2(float b) 
    {
        _b2 = b;
    }
    public float GetB0() 
    {
        return _b0;
    }
    public float GetB1() 
    {
        return _b1;
    }
    public float GetB2() 
    {
        return _b2;
    }
    public virtual string Print()
    {   //Друкує вигляд формули 
        return _b2 + "x^2 +" + _b1 + "x +" + _b0;
    }
    public virtual bool Xval_Valid(float x)
    {   //Перевіряє чи є x коренем рівняння 
        if (_b2 * (x * x) + _b1 * x + _b0 == 0) { return true; }
        else { return false; }
    }
    public virtual double? GetSolution(int n)
    {   //Виводить перший чи другий корінь рівняння 
        double D = _b1 * _b1 - 4 * _b2 * _b0;
        if (D < 0) return null;
        else if (n == 1) return ((-1) * _b1 + Math.Sqrt(D)) / (2 * _b2);
        else if (n == 2 && D != 0) return ((-1) * _b1 + (-1) * Math.Sqrt(D)) / (2 * _b2);
        else return null;
    }
}
class CubicEquation : SquareEquation
{
    private float _a0;
    public CubicEquation() 
    { 
    
    }
    public CubicEquation(float b2, float b1, float b0, float a0)
    {
        _b2 = b2;
        _b1 = b1;
        _b0 = b0;
        _a0 = a0;
    }
    public float GetA0() 
    {
        return _a0; 
    }
    public void SetA0(float a0) 
    { 
        _a0 = a0;
    }
    public override string Print()
    {   //Друкує вигляд формули 
        return _b2 + "x^3 +" + _b1 + "x^2 +" + _b0 + "x +" + _a0;
    }
    public override bool Xval_Valid(float x)
    {   //Перевіряє чи є x коренем рівняння 
        if (_b2 * (x * x * x) + _b1 * (x * x) + _b0 * x + _a0 == 0) return true;
        else return false;
    }
}

class Program
{
    public static void Main()
    {
        bool restart;
        do
        {
            SquareEquation Equation;
            Console.WriteLine("Choose:\n 0 - Square Equation.\n 1 - Cubic Equation");
            string? choice = Console.ReadLine();
            bool success = true;
            if (choice == "1")
            {
                Console.WriteLine("Enter a3,a2,a1,a0");
                success = float.TryParse(Console.ReadLine(),out float a3);
                success = float.TryParse(Console.ReadLine(),out float a2);
                success = float.TryParse(Console.ReadLine(),out float a1);
                success = float.TryParse(Console.ReadLine(),out float a0); 
                if (!success)
                {
                    Console.WriteLine("Some value is incorrectly formatted. Restarting...");
                    break;
                }
                Equation = new CubicEquation(a3, a2, a1, a0);
                Console.WriteLine("Write x for the equation" + Equation.Print());
                success= float.TryParse(Console.ReadLine(),out float x);
                bool correct = Equation.Xval_Valid(x);
                if (!success)
                {
                    Console.WriteLine("Some value is incorrectly formatted. Restarting...");
                    break;
                }
                if (correct) Console.WriteLine("The x is correct");
                else Console.WriteLine("The x is incorrect");
            }
            else
            {
                Console.WriteLine("Enter b2,b1,b0");
                success = float.TryParse(Console.ReadLine(),out float b2);
                success = float.TryParse(Console.ReadLine(),out float b1);
                success = float.TryParse(Console.ReadLine(),out float b0);
                if(!success)
                {
                    Console.WriteLine("Some value is incorrectly formatted. Restarting...");
                    break;
                }
                Equation = new SquareEquation(b2, b1, b0);
                Console.WriteLine("Write x for the equation" + Equation.Print());
                success = float.TryParse(Console.ReadLine(),out float x);
                if (!success)
                {
                    Console.WriteLine("Some value is incorrectly formatted. Restarting...");
                    break;
                }
                bool correct = Equation.Xval_Valid(x);
                if (correct) Console.WriteLine("The x is correct");
                else Console.WriteLine("The x is incorrect");

                Console.WriteLine("Solutions for a square equation " + Equation.Print() + " are :" + ((Equation.GetSolution(1) == null) ? "null" : Equation.GetSolution(1)) + " and " + ((Equation.GetSolution(2) == null) ? "null" : Equation.GetSolution(2)));
            }
            Console.WriteLine("Restart? (Y/N)?");
            restart = (Console.ReadLine() == "Y");
            Console.Clear();
        }
        while (restart);
    }
}
