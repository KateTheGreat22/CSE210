using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        DisplayName();
        DisplayNumber();
        DisplayYear();

        void DisplayMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        Console.Write("What is your name?");
        string name = Console.ReadLine();

        void DisplayName(string name)
        {
            Console.WriteLine($"Welcome {name}!");
        }

        Console.Write("What is your favorite number?");
        string number = Console.ReadLine();
        int numbers = int.Parse(number);

        void DisplayNumber(int numbers)
        {
            Console.WriteLine($"Welcome {name}!");
        }

        Console.Write("What year were you born?");
        int year = Console.ReadLine();
        int years = int.Parse(year);

        void DisplayYear(int years)
        {
            Console.WriteLine($"Welcome {name}!");
        }

    }
}