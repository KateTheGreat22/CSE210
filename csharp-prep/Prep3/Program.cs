using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        string response = "yes";
        while (response == "yes")

        {

            Console.Write("What is your guess?");
            string guess = Console.ReadLine();
            int attempt = int.Parse(guess);

            if (attempt > number)
            {
                Console.WriteLine("You need to guess lower.");
                response = "yes";
            }

            else if (attempt < number)
            {
                Console.WriteLine("You need to guess higher.");
                response = "yes";
            }

            else
            {
                Console.WriteLine("You guesssed correctly!");
                response = "no";
            }
        }
    }
}