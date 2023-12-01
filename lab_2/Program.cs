// See https://aka.ms/new-console-template for more information

class Sum
{
    private readonly float[] aVar = new float[3];
    public void SetAvar()
    {
        string? temp;
        for (int i = 0; i < 3; i++)
        {
            try
            {
                Console.WriteLine("Enter " + (i + 1) + "th Element");
                temp = Console.ReadLine();
                if (temp == null) aVar[i] = 0;
                else aVar[i] = float.Parse(temp);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        return;
    }
    public float GetAvar(int n) { return aVar[n]; }
    public float Execute()
    {
        float sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += aVar[i] / (i + 1 * (i + 2));
        }
        return sum;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Sum sum = new();
        sum.SetAvar();
        Console.WriteLine("The Result is : " + sum.Execute());

    }
}
