using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Menu.DisplayMenu();

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("What type of date? (single/double/group)");
                string dateType = Console.ReadLine();
                
                Console.WriteLine("Enter date name:");
                string name = Console.ReadLine();
                
                Console.WriteLine("Enter description:");
                string description = Console.ReadLine();
                
                Date currentDate = null;
                
                if (dateType == "single")
                {
                    currentDate = new Single(name, description);
                }
                else if (dateType == "double")
                {
                    currentDate = new Double(name, description);
                }
                else if (dateType == "group")
                {
                    currentDate = new Group(name, description);
                }
                
                if (currentDate != null)
                {
                    currentDate.ReportDate();
                }
                else
                {
                    Console.WriteLine("Invalid date type.");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Would you like to add a male or female?");
                string gender = Console.ReadLine();

                if (gender == "male")
                {
                    Male.AddMale();
                }
                else if (gender == "female")
                {
                    Female.AddFemale();
                }
                else
                {
                    Console.WriteLine("Invalid gender.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Would you like to remove a male or female?");
                string gender = Console.ReadLine();

                if (gender == "male")
                {
                    Male.RemoveMaleInteractive();
                }
                else if (gender == "female")
                {
                    Female.RemoveFemaleInteractive();
                }
                else
                {
                    Console.WriteLine("Invalid gender.");
                }
            }
            else if (choice == "4")
            {
                ListRandom.Attempt();
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}