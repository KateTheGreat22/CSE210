using System;

// Exceeding Core Requirements:
// 1. Added input validation with int.TryParse() to better deal with incorrect input
// 2. Implemented a continue/exit prompt that allows users to control when to exit the program at any point
// 3. Added .ToLower() on user response to handle user input (yes/Yes/YES all work)
// 4. Provided user-friendly error messages for invalid menu choices and invalid input types
// 5. Added confirmation messages after saving and loading operations for both debugging reasons and because I think it makes the code cleaner

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        myJournal.MenuDisplay();

        string response = "yes";

        while (response == "yes")
        {
            Console.WriteLine("\nEnter your menu choice:");
            string input = Console.ReadLine();
            int menuChoice;

            if (int.TryParse(input, out menuChoice))
            {
                if (menuChoice == 1)
                {
                    myJournal.WriteEntry(menuChoice, response);
                }
                else if (menuChoice == 2)
                {
                    myJournal.DisplayEntry(menuChoice);
                }
                else if (menuChoice == 3)
                {
                    myJournal.SaveEntry(menuChoice);
                }
                else if (menuChoice == 4)
                {
                    myJournal.LoadEntry(menuChoice);
                }
                else if (menuChoice == 5)
                {
                    myJournal.ProvideMenu(menuChoice);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                }

                Console.WriteLine("\nWould you like to continue? (yes/no)");
                response = Console.ReadLine().ToLower();
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                myJournal.ProvideMenu(menuChoice);
            }
        }

        Console.WriteLine("Thank you for using the journal!");
    }
}