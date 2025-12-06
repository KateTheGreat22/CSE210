using System;
using System.Collections.Generic;

class Male
{
    private static List<string> maleDates = new List<string> 
    { 
        "Ben", "Josh", "Bryce", "Gabe", "Blake", 
        "Jake", "Caleb", "Tyler", "Nathan" 
    };

    public static List<string> GetMaleDates()
    {
        return new List<string>(maleDates); 
    }

    public static void DisplayMale()
    {
        foreach (string man in maleDates)
        {
            Console.WriteLine(man);
        }
    }

    public static void AddMale()
    {
        Console.WriteLine("What male name would you like to add?");
        string maleName = Console.ReadLine();
        maleDates.Add(maleName);
        Console.WriteLine($"{maleName} has been successfully added.");
    }

    public static void RemoveMale(string name)
    {
        maleDates.Remove(name);
    }

    public static void RemoveMaleInteractive()
    {
        Console.WriteLine("What male name would you like to remove?");
        string maleRemove = Console.ReadLine();
        RemoveMale(maleRemove);
        Console.WriteLine($"{maleRemove} has been successfully removed.");
    }
}