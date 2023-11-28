using System.Text.RegularExpressions;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.WriteLine("Введіть текстовий рядок:");
        string input = Console.ReadLine();

        
        int openP = input.Count(c => c == '(');
        int closeP = input.Count(c => c == ')');
        int openS = input.Count(c => c == '[');
        int closeS = input.Count(c => c == ']');

        if (openP == closeP && openS == closeS)
        {
            Console.WriteLine("Кількість відкритих і закритих дужок співпадає.");
        }
        else
        {
            Console.WriteLine("Кількість відкритих і закритих дужок не співпадає.");
        }

        
        string[] words = input.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '(', ')', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        string lW = words.OrderByDescending(w => w.Length).FirstOrDefault();

        if (lW != null)
        {
            Console.WriteLine($"Найдовше слово: {lW}");
        }
        else
        {
            Console.WriteLine("Немає слів у введеному рядку.");
        }

        
        string pattern = @"^[A-Za-z]+$";
        string result = string.Join(" ", words.Where(word => !Regex.IsMatch(word, pattern)));

        Console.WriteLine($"Текст без слів, що складаються тільки з латинських літер:\n{result}");
    }
}