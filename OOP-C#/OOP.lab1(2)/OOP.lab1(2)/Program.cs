using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.Write("Введіть розмірність квадратної матриці (n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Введіть елементи першого рядка матриці, розділені пробілом:");
        string firstRowInput = Console.ReadLine();
        int[] firstRow = firstRowInput.Split(' ').Select(int.Parse).ToArray();

        if (firstRow.Length != n)
        {
            Console.WriteLine("Неправильна кількість елементів у першому рядку. Спробуйте ще раз.");
            return;
        }

        Console.WriteLine("Введіть елементи другого рядка матриці, розділені пробілом:");
        string secondRowInput = Console.ReadLine();
        int[] secondRow = secondRowInput.Split(' ').Select(int.Parse).ToArray();

        if (secondRow.Length != n)
        {
            Console.WriteLine("Неправильна кількість елементів у другому рядку. Спробуйте ще раз.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            matrix[0, i] = firstRow[i];
            matrix[1, i] = secondRow[i];
        }

        Console.WriteLine("Номери рядків, елементи яких є паліндромами:");

        for (int i = 0; i < n; i++)
        {
            int[] row = new int[n];

            for (int j = 0; j < n; j++)
            {
                row[j] = matrix[i, j];
            }

            if (row.SequenceEqual(row.Reverse()))
            {
                Console.WriteLine(i + 1); 
            }
        }
    }
}
