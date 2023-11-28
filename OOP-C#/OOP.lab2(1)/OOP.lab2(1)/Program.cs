using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.Write("Скільки чисел буде в масиві? ");
        int N = int.Parse(Console.ReadLine());

        double[] arr = new double[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write($"Введіть {i + 1}-е число: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        double sum = arr.Where(x => x > 0).Sum();

        double[] sortedArray = arr.OrderByDescending(x => Math.Abs(x)).ToArray();

        double max = Math.Abs(sortedArray[0]);
        double min = Math.Abs(sortedArray[N - 1]);

        double Bet = 1;
        bool foundMax = false;
        bool foundMin = false;

        foreach (var element in arr)
        {
            if (Math.Abs(element) == max)
                foundMax = true;
            if (Math.Abs(element) == min)
                foundMin = true;

            if (foundMax && foundMin)
                break;

            if (foundMax || foundMin)
                Bet *= element;
        }

        Console.WriteLine($"Сума додатніх чисел: {sum}");
        Console.WriteLine($"Добуток чисел між найбільшим і найменшим за модулем: {Bet}");
        Console.WriteLine("Масив, впорядкований за спаданням:");
        foreach (var element in sortedArray)
            Console.WriteLine(element);
    }
}
