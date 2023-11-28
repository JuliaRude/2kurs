using System;
using System.Text;

class Program
{
    // Функція для перевірки, чи є число простим
    static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.Write("Введіть парне число більше 2: ");
        int q = int.Parse(Console.ReadLine());

        if (q <= 2 || q % 2 != 0)
        {
            Console.WriteLine("Гіпотеза Гольбаха не застосовна до цього числа.");
        }
        else
        {
            for (int i = 2; i <= q / 2; i++)
            {
                if (IsPrime(i) && IsPrime(q - i))
                {
                    Console.WriteLine($"{q} = {i} + {q - i}");
                    break;
                }
            }
        }
    }
}
