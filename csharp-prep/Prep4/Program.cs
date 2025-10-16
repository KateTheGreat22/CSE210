using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program will add your numbers to the list until 0 is inputed.");

        List<int> numbers = new List<int>();
        int total = 0;

        string response = "yes";
        while (response == "yes")
        {
            Console.Write("What number would you like to add? ");
            string guess = Console.ReadLine();
            int number = int.Parse(guess);

            if (number == 0)
            {
                response = "no";
            }
            else
            {
                numbers.Add(number);
                total += number;
            }
        }

        if (numbers.Count > 0)
        {
            double average = (double)total / numbers.Count;
            Console.WriteLine($"Your total is {total}");
            Console.WriteLine($"Your average is {average}");
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
        int highest = numbers[0];

        foreach (int numb in numbers)
        {
            if (numb > highest)
            {
                highest = numb;
            }
        }
        Console.WriteLine($"Your highest number is {highest}");
    }
}
