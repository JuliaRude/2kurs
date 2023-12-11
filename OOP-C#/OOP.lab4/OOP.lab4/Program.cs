using System;
using System.Collections.Generic;
using System.Diagnostics;

public interface IName
{
    object DeepCopy();
}

public class Person : IName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Person other)
            return false;

        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public object DeepCopy()
    {
        return new Person(FirstName, LastName);
    }
}

public class Auto : IName
{
    public string LicensePlate { get; set; }
    public string Year { get; set; }

    public Auto(string licensePlate, string year)
    {
        LicensePlate = licensePlate;
        Year = year;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Auto other)
            return false;

        return LicensePlate == other.LicensePlate && Year == other.Year;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LicensePlate, Year);
    }

    public override string ToString() => $"{Year} {LicensePlate}";

    public object DeepCopy()
    {
        return new Auto(LicensePlate, Year);
    }
}

public enum Parking
{
    Car,
}

public class Fares : IName
{
    public string Prices { get; set; }
    public int SomeOtherProperty { get; set; } 

    public List<Person> Members { get; set; }
    public List<Auto> Autos { get; set; }

    public Fares(string prices, int someOtherProperty, string priceDetails, Parking parkingType, Person[] members, Auto[] autos)
    {
        Prices = prices;
        SomeOtherProperty = someOtherProperty;
        Members = new List<Person>(members);
        Autos = new List<Auto>(autos);
    }

    public void AddAuto(Auto[] newAutos)
    {
        Autos.AddRange(newAutos);
    }

    public override string ToString()
    {
        return $"{Prices} {SomeOtherProperty} {string.Join(", ", Members)} {string.Join(", ", Autos)}";
    }

    public object DeepCopy()
    {
        var copiedMembers = Members.ConvertAll(member => (Person)member.DeepCopy());
        var copiedAutos = Autos.ConvertAll(auto => (Auto)auto.DeepCopy());

        return new Fares(Prices, SomeOtherProperty, "Update this with actual details", Parking.Car, copiedMembers.ToArray(), copiedAutos.ToArray());
    }
}

class Program
{
    static void Main()
    {
        
        Price parkingPrice = new Price("паркування автомобілів", 1);

        
        Fares parkingFares = new Fares("паркування автомобілів", 1, "100 грн/день", Parking.Car,
            new Person[] { new Person("Іван", "Іванов"), new Person("Марія", "Петрова") },
            new Auto[] { new Auto("AA0000AA", "2023"), new Auto("BB0000BB", "2022") });

       
        parkingFares.AddAuto(new Auto[] { new Auto("CC0000CC", "2021") });

       
        Console.WriteLine("Список учасників парковки:");
        foreach (Person member in parkingFares.Members)
        {
            Console.WriteLine(member);
        }

       
        Fares copyFares = (Fares)parkingFares.DeepCopy();

       
        copyFares.Prices = "150 грн/день";
        copyFares.Members[0].FirstName = "Петро";

       
        Console.WriteLine("\nКопія об'єкта Fares:");
        Console.WriteLine(copyFares);
        Console.WriteLine("\nВихідний об'єкт Fares:");
        Console.WriteLine(parkingFares);

        
        Console.WriteLine("\nУчасники парковки з державним номером:");
        foreach (Person member in parkingFares.Members)
        {
            foreach (Auto auto in parkingFares.Autos)
            {
                if (member.Equals(auto))
                {
                    Console.WriteLine(member);
                    break;
                }
            }
        }

        
        Console.WriteLine("\nУчасники парковки з більше ніж однією автівкою:");
        foreach (Person member in parkingFares.Members)
        {
            int autoCount = parkingFares.Autos.Count(auto => member.Equals(auto));
            if (autoCount > 1)
            {
                Console.WriteLine(member);
            }
        }

        
        Console.WriteLine("\nДержавні номери авто, що вийшли за останній рік:");
        foreach (Auto auto in parkingFares.Autos)
        {
            int year = int.Parse(auto.Year);
            if (year == DateTime.Now.Year || year == DateTime.Now.Year - 1)
            {
                Console.WriteLine(auto.LicensePlate);
            }
        }

        Console.ReadLine();
    }
}
