using System;
using System.Collections.Generic;

interface IName
{
    string Name { get; set; }
    object DeepCopy();
}

// Клас Person
public class Person 
{
    private string _firstName;
    private string _lastName;

    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (obj is Person)
        {
            Person other = (Person)obj;
            return _firstName == other._firstName && _lastName == other._lastName;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _firstName.GetHashCode() ^ _lastName.GetHashCode();
    }

    public override string ToString()
    {
        return $"{_firstName} {_lastName}";
    }

    public object DeepCopy()
    {
        return new Person(_firstName, _lastName);
    }
}

// Клас Auto
public class Auto 
{
    private string _licensePlate;
    private string _year;

    public Auto(string licensePlate, string year)
    {
        _licensePlate = licensePlate;
        _year = year;
    }

    public string LicensePlate
    {
        get { return _licensePlate; }
        set { _licensePlate = value; }
    }

    public string Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (obj is Auto)
        {
            Auto other = (Auto)obj;
            return _licensePlate == other._licensePlate && _year == other._year;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _licensePlate.GetHashCode() ^ _year.GetHashCode();
    }

    public override string ToString()
    {
        return $"{_year} {_licensePlate}";
    }

    public object DeepCopy()
    {
        return new Auto(_licensePlate, _year);
    }
}

// Клас Parking
public enum Parking
{
    Car   
}

// Клас Price
public class Price
{
    protected string _services;
    protected int _occupiedPlace;

    public Price()
    {
        _services = "";
        _occupiedPlace = 0;
    }

    public Price(string services, int occupiedPlace)
    {
        _services = services;
        _occupiedPlace = occupiedPlace;
    }

    public string Services
    {
        get { return _services; }
        set
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (value.Length == 0)
                throw new ArgumentException("Значення має бути непорожнім", "value");
            _services = value;
        }
    }

    public int OccupiedPlace
    {
        get { return _occupiedPlace; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", "Значення має бути більше або дорівнювати нулю");
            _occupiedPlace = value;
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (obj is Price)
        {
            Price other = (Price)obj;
            return _services == other._services && _occupiedPlace == other._occupiedPlace;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _services.GetHashCode() ^ _occupiedPlace;
    }

    public override string ToString()
    {
        return $"Сервіси: {_services}, зайняте місце: {_occupiedPlace}";
    }

    public object DeepCopy()
    {
        return new Price(_services, _occupiedPlace);
    }
}

// Клас Fares
public class Fares : Price
{
    protected string _prices;
    protected Parking _parking;
    protected List<Person> _members;
    protected List<Auto> _autos;

    public Fares()
    {
        _prices = "";
        _parking = Parking.Car;
        _members = new List<Person>();
        _autos = new List<Auto>();
    }

    public Fares(string services, int occupiedPlace, string prices, Parking parking, Person[] members, Auto[] autos)
        : base(services, occupiedPlace)
    {
        _prices = prices;
        _parking = parking;
        _members = new List<Person>(members);
        _autos = new List<Auto>(autos);
    }

    public string Prices
    {
        get { return _prices; }
        set { _prices = value; }
    }

    public Parking Parking
    {
        get { return _parking; }
        set { _parking = value; }
    }

    public List<Person> Members
    {
        get { return _members; }
    }

    public List<Auto> Autos
    {
        get { return _autos; }
    }

    public Auto LatestAuto
    {
        get
        {
            if (_autos.Count == 0)
                return null;
            return _autos[^1]; 
        }
    }

    public void AddAuto(Auto[] autos)
    {
        _autos.AddRange(autos);
    }

    public override string ToString()
    {
        return $"Сервіси: {base.ToString()}, ціни: {_prices}, тип транспорту: {_parking}, учасники парковки: {_members.Count}, автомобілі: {_autos.Count}";
    }

    public new object DeepCopy()
    {
        // Використовуємо new для явної реалізації методу DeepCopy в класі Fares
        // та викликаємо DeepCopy базового класу Price
        return new Fares(_services, _occupiedPlace, _prices, _parking, _members.ToArray(), _autos.ToArray());
    }
}

// Клас TestCollections
public class TestCollections
{
    public List<int> IntList { get; set; }
    public List<string> StringList { get; set; }
    public Dictionary<int, string> IntStringDictionary { get; set; }
    public Dictionary<string, double> StringDoubleDictionary { get; set; }

    public TestCollections()
    {
        IntList = new List<int>();
        StringList = new List<string>();
        IntStringDictionary = new Dictionary<int, string>();
        StringDoubleDictionary = new Dictionary<string, double>();
    }

}
