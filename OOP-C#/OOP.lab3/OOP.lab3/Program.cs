using System;
using System.Linq;

// Перерахування, що представляє розклад ходу поїздів
public enum Schedule
{
    EvenDays,
    OddDays,
    EveryDay
}

// Клас, який представляє інформацію про поїзд
public class Train
{
    // Властивості автоматичних властивостей для назви поїзда, маршруту та дати відправлення
    public string TrainName { get; set; }
    public string Route { get; set; }
    public DateTime DepartureDate { get; set; }

    // Конструктор з параметрами для ініціалізації властивостей класу
    public Train(string trainName, string route, DateTime departureDate)
    {
        TrainName = trainName;
        Route = route;
        DepartureDate = departureDate;
    }

    // Конструктор без параметрів, що ініціалізує властивості значеннями за замовчуванням
    public Train() : this("DefaultTrain", "DefaultRoute", DateTime.Now) { }

    // Перевизначений метод ToString для представлення об'єкта у вигляді рядка
    public override string ToString() => $"Train: {TrainName}, Route: {Route}, Departure Date: {DepartureDate}";
}

// Клас, який представляє інформацію про залізничний вокзал
public class Station
{
    // Закриті поля класу
    private string stationName;
    private string cityName;
    private int registrationNumber;
    private Schedule schedule;
    private Train[] trains = Array.Empty<Train>();

    // Конструктор з параметрами для ініціалізації властивостей класу
    public Station(string stationName, string cityName, int registrationNumber, Schedule schedule)
    {
        this.stationName = stationName;
        this.cityName = cityName;
        this.registrationNumber = registrationNumber;
        this.schedule = schedule;
    }

    // Конструктор без параметрів, що ініціалізує властивості значеннями за замовчуванням
    public Station() : this("DefaultStation", "DefaultCity", 0, Schedule.EveryDay) { }

    // Властивості з автоматичними властивостями та методами get/set для доступу до закритих полів класу
    public string StationName { get => stationName; set => stationName = value; }
    public string CityName { get => cityName; set => cityName = value; }
    public int RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
    public Schedule StationSchedule { get => schedule; set => schedule = value; }
    public Train[] Trains { get => trains; set => trains = value; }

    // Властивість, яка повертає посилання на поїзд з найпізнішою датою відправлення
    public Train LatestTrain => trains.OrderByDescending(t => t.DepartureDate).FirstOrDefault();

    // Індексатор для перевірки розкладу руху
    public bool this[Schedule index] => schedule == index;

    // Метод для додавання поїздів до списку
    public void AddTrain(params Train[] newTrains) => trains = trains.Concat(newTrains).ToArray();

    // Перевизначений метод ToString для представлення об'єкта у вигляді рядка
    public override string ToString() =>
        $"Station: {stationName}, City: {cityName}, Registration Number: {registrationNumber}, Schedule: {schedule},\nTrains:\n{string.Join("\n", trains.Select(train => train.ToString()))}";

    // Віртуальний метод для короткого виводу інформації
    public virtual string ToShortString() => $"Station: {stationName}, City: {cityName}, Registration Number: {registrationNumber}, Schedule: {schedule}";
}

class Program
{
    static void Main()
    {
        // Створення об'єкта вокзалу та виведення інформації
        Station station = new Station("Central Station", "Cityville", 123, Schedule.EveryDay);
        Console.WriteLine("Station Information:\n" + station.ToShortString());

        // Виведення інформації про розклад руху поїздів
        Console.WriteLine($"\nIs the schedule for even days? {station[Schedule.EvenDays]}");
        Console.WriteLine($"Is the schedule for odd days? {station[Schedule.OddDays]}");
        Console.WriteLine($"Is the schedule for every day? {station[Schedule.EveryDay]}");

        // Оновлення інформації про вокзал та виведення її
        station.StationName = "New Station";
        station.CityName = "New City";
        station.RegistrationNumber = 456;
        station.StationSchedule = Schedule.OddDays;
        Console.WriteLine($"\nUpdated Station Information:\n{station}");

        // Додавання поїздів та виведення інформації про вокзал
        Train train1 = new Train("Express", "Route 1", DateTime.Now.AddDays(1));
        Train train2 = new Train("Local", "Route 2", DateTime.Now.AddDays(2));
        Train train3 = new Train("Shuttle", "Route 3", DateTime.Now.AddDays(3));
        station.AddTrain(train1, train2, train3);
        Console.WriteLine($"\nUpdated Station Information with Trains:\n{station}");

        // Виведення інформації про найпізніший поїзд
        Train latestTrain = station.LatestTrain;
        Console.WriteLine($"\nLatest Train Information:\n{latestTrain?.ToString() ?? "No trains available"}");

        // Порівняння часу виконання операцій з елементами масивів
        CompareArrayOperations();
    }

    // Метод для порівняння часу доступу до елементів різних типів масивів
    static void CompareArrayOperations()
    {
        const int size = 1000000;
        Train[] trainsArray = Enumerable.Repeat(new Train("Sample", "Sample Route", DateTime.Now), size).ToArray();
        Train[,] trains2DArray = new Train[size / 1000, 1000];
        Train[][] trainsJaggedArray = Enumerable.Range(0, size / 1000).Select(_ => new Train[1000]).ToArray();

        // Заповнення масивів однаковими об'єктами Train для порівняння
        for (int i = 0; i < size; i++)
        {
            trains2DArray[i / 1000, i % 1000] = trainsArray[i];
            trainsJaggedArray[i / 1000][i % 1000] = trainsArray[i];
        }

        // Порівняння часу доступу до елементів
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < size; i++)
        {
            Train train = trainsArray[i];
        }
        Console.WriteLine($"\nTime taken for accessing elements in 1D array: {(DateTime.Now - startTime).TotalMilliseconds} ms");

        startTime = DateTime.Now;
        for (int i = 0; i < size / 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                Train train = trains2DArray[i, j];
            }
        }
        Console.WriteLine($"Time taken for accessing elements in 2D array: {(DateTime.Now - startTime).TotalMilliseconds} ms");

        startTime = DateTime.Now;
        for (int i = 0; i < size / 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                Train train = trainsJaggedArray[i][j];
            }
        }
        Console.WriteLine($"Time taken for accessing elements in jagged array: {(DateTime.Now - startTime).TotalMilliseconds} ms");
    }
}