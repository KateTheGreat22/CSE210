using System;
using System.Collections.Generic;

class ListRandom
{
    public static void Attempt()
    {
        Console.WriteLine("Would you like to randomly generate one date pair or all date pairs?");
        string answer = Console.ReadLine();

        Random rand = new Random();

        if (answer == "one")
        {
            List<string> females = Female.GetFemaleDates();
            List<string> males = Male.GetMaleDates();

            string girl = females[rand.Next(females.Count)];
            string man = males[rand.Next(males.Count)];

            Console.WriteLine($"Your random date pair is: {girl} and {man}");
        }
        else if (answer == "all")
        {
            List<string> availableGirls = Female.GetFemaleDates();
            List<string> availableMen = Male.GetMaleDates();

            while (availableGirls.Count > 0 && availableMen.Count > 0)
            {
                int girlIndex = rand.Next(availableGirls.Count);
                int manIndex = rand.Next(availableMen.Count);

                string girl = availableGirls[girlIndex];
                string man = availableMen[manIndex];

                Console.WriteLine($"Your random date pair is: {girl} and {man}");

                availableGirls.RemoveAt(girlIndex);
                availableMen.RemoveAt(manIndex);
            }
        }
    }
}