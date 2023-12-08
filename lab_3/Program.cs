

using System;

class MemoryLeak
{
    public MemoryLeak()
    {
        Console.WriteLine("Flooding RAM");
        int[,,] memleak = new int[999, 999, 999];
    }

    ~MemoryLeak()
    {
        Console.WriteLine("Memory leak destructor called!");
    }
}

class Sum
{
    private readonly float[] a_var = new float[3];

    public Sum() { }

    public Sum(float a1, float a2, float a3)
    {
        this.a_var[0] = a1;
        this.a_var[1] = a2;
        this.a_var[2] = a3;
    }

    public void SetAvar()
    {
        string? temp;
        for (int i = 0; i < 3; i++)
        {
            try
            {
                Console.WriteLine("Enter " + (i + 1) + "th Element");
                temp = Console.ReadLine();
                if (temp == null)
                    a_var[i] = 0;
                else
                    a_var[i] = float.Parse(temp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        return;
    }

    public float Execute()
    {
        float sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += a_var[i] / (i + 1 * (i + 2));
        }
        return sum;
    }

    ~Sum()
    {
        Console.WriteLine("Destructor Called!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter amount of objects");
        string? temp = Console.ReadLine();
        int n;
        if (temp != null)
        {
            n = int.Parse(temp);
        }
        else
        {
            return;
        }

        Sum[] sum = new Sum[100];
        for (int i = 0; i < n; i++)
        {
            sum[i] = new Sum();
            Console.WriteLine("Object №" + (i + 1));
            sum[i].SetAvar();
        }

        Console.WriteLine("Results:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("For " + (i + 1) + "th Object : " + sum[i].Execute());
        }

        float max = sum[0].Execute();
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (max <= sum[i].Execute())
            {
                imax = i;
                max = sum[i].Execute();
            }
        }

        Console.WriteLine("Max result is " + max + " in Object № " + (imax + 1));

        for (int i = 0; i < 100; i++)
        {
            MemoryLeak memleak = new MemoryLeak();
        }
    }
}
