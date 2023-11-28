using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
       
        List<(int apartNum, string owner, string phoneNum, int alarmFee, int fine, int mPay, int Polic)> contracts = new List<(int, string, string, int, int, int, int)>();

        contracts.Add((52, "Таїсія Вікторівна", "132-600-7000", 45, 100, 500, 4));
        contracts.Add((65, "Маша Ярославівна", "947-675-3200", 100, 20, 650, 3));
        contracts.Add((146, "Ліза Миронівна", "153-876-6565", 190, 40, 600, 1));
        contracts.Add((54, "Ярина Богданівна", "111-333-4556", 150, 90, 450, 2));
        contracts.Add((87, "Вероніка Олегівна", "235-847-5552", 40, 80, 300, 2));
        contracts.Add((153, "Іван Іванович", "747-558-6655", 190, 95, 700, 1));
        contracts.Add((34, "Михайло Володимирович", "997-677-3020", 200, 100, 600, 2));
        contracts.Add((1, "Ігор Петрович", "575-133-4667", 350, 70, 650, 4));
        contracts.Add((75, "Надія Богданівна", "755-886-6374", 140, 30, 450, 2));
        contracts.Add((47, "Ярослав Олександрович", "345-278-3663", 150, 45, 300, 1));
        contracts.Add((14, "Микола Григорович", "828-656-2233", 250, 60, 750, 4));
        contracts.Add((30, "Олег Миколайович", "123-564-5555", 80, 50, 500, 3));
        contracts.Add((12, "Марія Олексіївна", "787-943-4477", 100, 40, 250, 1));
        contracts.Add((4, "Андрій Йосипович", "265-484-8346", 300, 70, 650, 2));

        Console.WriteLine("Введіть номер квартири для пошуку:");
        int searchfine = int.Parse(Console.ReadLine());
        int Polic = int.Parse(Console.ReadLine());

       

        foreach (var contract in contracts)
        {
            if (contract.fine == searchfine)
            {
                Console.WriteLine($"Номер квартири: {contract.apartNum}");
                Console.WriteLine($"Власник: {contract.owner}");
                Console.WriteLine($"Телефон власника: {contract.phoneNum}");
                Console.WriteLine($"Оплата за встановлення сигналізації: {contract.alarmFee} грн");
                Console.WriteLine($"Розмір штрафу за невчасне відключення сигналізації: {contract.fine} грн");
                Console.WriteLine($"Щомісячна оплата за охорону квартири: {contract.mPay} грн");
                Console.WriteLine($"Кількість виїздів патрульних: {contract.Polic}");

                
            }
            else if (contract.Polic == searchfine)
            {
                Console.WriteLine($"Номер квартири: {contract.apartNum}");
                Console.WriteLine($"Власник: {contract.owner}");
                Console.WriteLine($"Телефон власника: {contract.phoneNum}");
                Console.WriteLine($"Оплата за встановлення сигналізації: {contract.alarmFee} грн");
                Console.WriteLine($"Розмір штрафу за невчасне відключення сигналізації: {contract.fine} грн");
                Console.WriteLine($"Щомісячна оплата за охорону квартири: {contract.mPay} грн");
                Console.WriteLine($"Кількість виїздів патрульних: {contract.Polic}");

                
            }

        }
    }
}
