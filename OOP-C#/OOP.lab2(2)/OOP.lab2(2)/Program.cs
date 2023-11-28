using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Кількість рядків матриці: ");
        int rowCount = int.Parse(Console.ReadLine());

        Console.Write("Кількість стовпців матриці: ");
        int colCount = int.Parse(Console.ReadLine());

        int[][] matrix = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }

        int non = Enumerable.Range(0, colCount)
            .Count(j => matrix.All(row => row[j] != 0));

        Array.Sort(matrix, (row1, row2) =>
        {
            int sum1 = row1.Where(num => num > 0 && num % 2 == 0).Sum();
            int sum2 = row2.Where(num => num > 0 && num % 2 == 0).Sum();
            return sum1.CompareTo(sum2);
        });

        Console.WriteLine($"Кількість стовпців без нулів: {non}");
        Console.WriteLine("Матриця після сортування за характеристиками:");
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
