using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;
//Abstract class
namespace Abstracts
{
    public abstract class Equation
    {
        protected float _b2;
        protected float _b1;
        protected float _b0;
        protected float _a0;
        public Equation()
        {

        }
        public abstract bool XValValid(float x);
        
        public abstract double? GetSolution(int n);

        public abstract string Print();
    } 
    public class Square : Equation
    {
        public Square(float b2,float b1, float b0) 
        {
            _b2 = b2;
            _b1 = b1;
            _b0 = b0;
        }
        public override bool XValValid(float x)
        {
            if (_b2 * x * x + _b1 * x + _b0 == 0)
            {
                return true;
            }
            else return false;
        }
        public override double? GetSolution(int n)
        {
            double D = Math.Sqrt(_b1*_b1+4*_b1*_b0);
            if (D >= 0 && n == 1)
            {
                return ((-1) * _b1 + D / 2 * _b2);
            }
            else if (D > 0 && n == 2)
            {
                return ((-1) * _b1 - D / 2 * _b2);
            }
            else return null;
        }
        public override string Print()
        {
            return _b2 + "x^2 " + ((_b1<0)?_b1:"+"+ _b1) + "x " + ((_b0 < 0) ? _b0 : "+" + _b0);  
        }
    }

    public class Cubic : Equation
    {

        public Cubic(float a3, float a2,float a1 , float a0)
        {
            _b2 = a3;
            _b1 = a2;
            _b0 = a1;
            _a0 = a0;
        }
        public override bool XValValid(float x)
        {
            if (_b2 * x * x * x + _b1 * x * x + _b0 * x + _a0 == 0)
            {
                return true;
            }
            else { return false; }
        }
        public override double? GetSolution(int n)
        {
            throw new NotImplementedException();
        }
        public override string Print()
        {
            return _b2 + "x^3 " + ((_b1 < 0) ? _b1 : "+" + _b1) 
                + "x^2 " + ((_b0 < 0) ? _b0 : "+" + _b0) + "x "
                + ((_a0 < 0) ? _a0 : "+" + _a0);
        }
    }
    class Program
    {
        public static void Main()
        {
            bool restart;
            do
            {
                IEquation Equation;
                Console.WriteLine("Choose:\n 0 - Square Equation.\n 1 - Cubic Equation");
                string? choice = Console.ReadLine();
                bool success = true;
                if (choice == "1")
                {
                    Console.WriteLine("Enter a3,a2,a1,a0");
                    success = float.TryParse(Console.ReadLine(), out float a3);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a2);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a1);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a0);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    Equation = new CubicEquation(a3, a2, a1, a0);
                    Console.WriteLine("Write x for the equation" + Equation.Print());
                    success = float.TryParse(Console.ReadLine(), out float x);
                    bool correct = Equation.XVal_Valid(x);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    if (correct) Console.WriteLine("The x is correct");
                    else Console.WriteLine("The x is incorrect");
                }
                else
                {
                    Console.WriteLine("Enter b2,b1,b0");
                    success = float.TryParse(Console.ReadLine(), out float b2);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float b1);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float b0);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    Equation = new SquareEquation(b2, b1, b0);
                    Console.WriteLine("Write x for the equation" + Equation.Print());
                    success = float.TryParse(Console.ReadLine(), out float x);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    bool correct = Equation.XVal_Valid(x);
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
}
//Interface
namespace Interface
{
    public interface IEquation
    {
        float _b2
        {
            get; set;
        }
        float _b1 { get; set; }
        float _b0 { get; set; }

        string Print();
        bool XVal_Valid(float x);
        double? GetSolution(int n);
    }
    class SquareEquation : IEquation
    {

        public SquareEquation(float b2, float b1, float b0)
        {
            _b2 = b2;
            _b1 = b1;
            _b0 = b0;
        }
        public float _b2 { get; set; }
        public float _b1 { get; set; }
        public float _b0 { get; set; }

        public string Print()
        {
            return _b2 + "x^2 " + ((_b1 < 0) ? _b1 : "+" + _b1) + "x " + ((_b0 < 0) ? _b0 : "+" + _b0);
        }
        public bool XVal_Valid(float x)
        {
            if (_b2 * x * x + _b1 * x + _b0 == 0)
            {
                return true;
            }
            else return false;
        }
        public double? GetSolution(int n)
        {
            double D = Math.Sqrt(_b1 * _b1 + 4 * _b1 * _b0);
            if (D >= 0 && n == 1)
            {
                return ((-1) * _b1 + D / 2 * _b2);
            }
            else if (D > 0 && n == 2)
            {
                return ((-1) * _b1 - D / 2 * _b2);
            }
            else return null;
        }
    }
    class CubicEquation : IEquation
    {
        private float _a0;
        public CubicEquation(float a3, float a2, float a1, float a0)
        {
            _b2 = a3;
            _b1 = a2;
            _b0 = a1;
            _a0 = a0;
        }
        public float _b2 { get; set; }
        public float _b1 { get; set; }
        public float _b0 { get; set; }
        public string Print()
        {
            return _b2 + "x^3 " + ((_b1 < 0) ? _b1 : "+" + _b1)
                + "x^2 " + ((_b0 < 0) ? _b0 : "+" + _b0) + "x "
                + ((_a0 < 0) ? _a0 : "+" + _a0);
        }
        public bool XVal_Valid(float x)
        {
            if (_b2 * x * x * x + _b1 * x * x + _b0 * x + _a0 == 0)
            {
                return true;
            }
            else { return false; }
        }
        public double? GetSolution(int n)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        public static void Main()
        {
            bool restart;
            do
            {
                IEquation Equation;
                Console.WriteLine("Choose:\n 0 - Square Equation.\n 1 - Cubic Equation");
                string? choice = Console.ReadLine();
                bool success = true;
                if (choice == "1")
                {
                    Console.WriteLine("Enter a3,a2,a1,a0");
                    success = float.TryParse(Console.ReadLine(), out float a3);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a2);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a1);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float a0);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    Equation = new CubicEquation(a3, a2, a1, a0);
                    Console.WriteLine("Write x for the equation" + Equation.Print());
                    success = float.TryParse(Console.ReadLine(), out float x);
                    bool correct = Equation.XVal_Valid(x);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    if (correct) Console.WriteLine("The x is correct");
                    else Console.WriteLine("The x is incorrect");
                }
                else
                {
                    Console.WriteLine("Enter b2,b1,b0");
                    success = float.TryParse(Console.ReadLine(), out float b2);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float b1);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    success = float.TryParse(Console.ReadLine(), out float b0);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    Equation = new SquareEquation(b2, b1, b0);
                    Console.WriteLine("Write x for the equation" + Equation.Print());
                    success = float.TryParse(Console.ReadLine(), out float x);
                    if (!success)
                    {
                        Console.WriteLine("value is incorrectly formatted.");
                        break;
                    }
                    bool correct = Equation.XVal_Valid(x);
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
}

