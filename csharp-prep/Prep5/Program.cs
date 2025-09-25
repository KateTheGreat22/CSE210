using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int number = PromptUserNumber();

        PromtUserBirthYear(out int birthYear);

        int square = SquareNumber(number);

        DisplayResult(name, square, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string input = Console.ReadLine();
        return int.Parse(input);
    }

    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("What year were you born? ");
        string input = Console.ReadLine();
        birthYear = int.Parse(input);
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int square, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        Console.WriteLine(" Information Summary Because I Like To Keep Code Clean");
        Console.WriteLine($"Welcome {name}!");
        Console.WriteLine($"{name}, your number squared is {square}");
        Console.WriteLine($"{name}, You are {age} years old this year.");
    }
}
