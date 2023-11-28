using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;


        Console.WriteLine("Введіть значення 'a':");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть значення 'b':");
        double b = double.Parse(Console.ReadLine());

        double q = Math.Pow((a + b), 5);
        double w = Math.Pow((b - a), 3);

        if (w == 0)
        {
            Console.WriteLine("Дільник дорівнює нулю. Неможливо обчислити корінь.");
        }
        else
        {
            double y = Math.Sqrt(q / w);
            Console.WriteLine($"Результат: y = {y}");
        }
    }
}
