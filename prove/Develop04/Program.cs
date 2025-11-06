using System;

/* 
  Exceeding Requirements:
  1. Prevented duplicate questions in the Reflection activity
     during the same session by tracking used questions in a list
  2. Added proper timing mechanism in the Listing activity using Stopwatch
     to ensure it stops exactly when the duration is reached.
  3. Added exceptions to deal with incorrect inputs

 */

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        bool running = true;

        Console.WriteLine("Welcome to the Mindfulness Program!");

        while (running)
        {
            menu.MenuDisplay();
            string input = Console.ReadLine();

            if (int.TryParse(input, out int menuChoice))
            {
                if (menuChoice == 1)
                {
                    Breathing breathing = new Breathing();
                }
                else if (menuChoice == 2)
                {
                    Reflection reflection = new Reflection();
                }
                else if (menuChoice == 3)
                {
                    Writing writing = new Writing();
                }
                else if (menuChoice == 4)
                {
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}