namespace Lab6;

public class Generator
{
    private const int count = 10000;
    private float Nu { get; }
    private static Random Random = new Random();
    private List<double> numbers;

    public Generator(float nu)
    {
        Nu = nu;
        GenerateNumbers(7, 209715120, 3);
    }

    public decimal GetNext()
    {
        var number = numbers[Random.Next(count)];
        var value = (decimal)(-1.0f / Nu) * (decimal)Math.Log(number);
        return value;
    }

    private void GenerateNumbers(int a, int m, int r)
    {
        numbers = new List<double>(count);

        for (int i = 0; i < count; i++)
        {
            r = (r * a) % m;
            numbers.Add((double)r / m);
        }
    }

}