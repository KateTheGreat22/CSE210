using System;

/* 
 * EXCEEDING REQUIREMENTS:
 * This program exceeds the core requirements by including:
 * 1. Giving congratulatory messages when goals are completed
 * 2. Clear display of bonus points when checklist goals are fully completed
 * 3. Immediate point total updates after each goal is recorded
 * 4. User-friendly menu system with clear prompts
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        bool running = true;

        while (running)
        {
            manager.DisplayPlayerInfo();
            
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                manager.CreateGoal();
            }
            else if (choice == "2")
            {
                manager.ListGoalDetails();
            }
            else if (choice == "3")
            {
                manager.SaveGoals();
            }
            else if (choice == "4")
            {
                manager.LoadGoals();
            }
            else if (choice == "5")
            {
                manager.RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Thank you for using the Eternal Quest Program. Goodbye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1-6.");
            }
        }
    }
}