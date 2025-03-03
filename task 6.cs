// 1 задание

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите логин:");
        string login = Console.ReadLine();

        if (IsValidLogin(login))
        {
            Console.WriteLine("Логин корректен.");
        }
        else
        {
            Console.WriteLine("Логин некорректен.");
        }
    }

    static bool IsValidLogin(string login)
    {
        string pattern = @"^[a-zA-Z][a-zA-Z0-9]{1,9}$";

        return login.Length >= 2 && login.Length <= 10 && Regex.IsMatch(login, pattern);
    }
}

// 2 задание

using System;
using System.Collections.Generic;
using System.Linq;

public static class Message
{
    public static void PrintWordsWithMaxLength(string message, int n)
    {
        var words = message.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var filteredWords = words.Where(word => word.Length <= n);
        
        Console.WriteLine("Слова, содержащие не более {0} букв:", n);
        foreach (var word in filteredWords)
        {
            Console.WriteLine(word);
        }
    }

    public static string RemoveWordsEndingWith(string message, char endingChar)
    {
        var words = message.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var filteredWords = words.Where(word => !word.EndsWith(endingChar.ToString()));
        
        return string.Join(" ", filteredWords);
    }

    public static string FindLongestWord(string message)
    {
        var words = message.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.OrderByDescending(word => word.Length).FirstOrDefault() ?? string.Empty;
    }
}

class Program
{
    static void Main()
    {
        string message = "Привет! Это тестовое сообщение для обработки текста.";

        Message.PrintWordsWithMaxLength(message, 4);

        char endingChar = 'е';
        string updatedMessage = Message.RemoveWordsEndingWith(message, endingChar);
        Console.WriteLine("Сообщение после удаления слов, заканчивающихся на '{0}':", endingChar);
        Console.WriteLine(updatedMessage);

        string longestWord = Message.FindLongestWord(message);
        Console.WriteLine("Самое длинное слово: " + longestWord);
    }
}


// 3 задание


using System;

public class Car
{

    private string brand;
    private int year;
    private int mileage;

    public Car(string brand, int year)
    {
        this.brand = brand;
        this.year = year;
        this.mileage = 0; // Устанавливаем пробег в 0
    }

    public void Drive(int km)
    {
        if (km < 0)
        {
            Console.WriteLine("Пробег не может быть отрицательным.");
        }
        else
        {
            mileage += km; 
            Console.WriteLine($"Автомобиль проехал {km} км. Текущий пробег: {mileage} км.");
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Марка: {brand}");
        Console.WriteLine($"Год выпуска: {year}");
        Console.WriteLine($"Пробег: {mileage} км");
    }

    ~Car()
    {
        Console.WriteLine($"Объект автомобиля {brand}, год {year} уничтожен.");
    }
}

class Program
{
    static void Main()
    {
        Car myCar = new Car("Toyota", 2020);

        myCar.DisplayInfo();

        myCar.Drive(150);
        myCar.Drive(200);

        myCar.DisplayInfo();

    }
}

