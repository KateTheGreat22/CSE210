using System;
using System.Collections.Generic;

class Female
{
    private static List<string> femaleDates = new List<string> 
    { 
        "Grace", "Corinne", "Kaitlyn", "Nichole", "Audrey", 
        "Megan", "Kristen", "Gabbi", "Brin" 
    };

    public static List<string> GetFemaleDates()
    {
        return new List<string>(femaleDates);
    }

    public static void DisplayFemale()
    {
        foreach (string girl in femaleDates)
        {
            Console.WriteLine(girl);
        }
    }

    public static void AddFemale()
    {
        Console.WriteLine("What female name would you like to add?");
        string femaleName = Console.ReadLine();
        femaleDates.Add(femaleName);
        Console.WriteLine($"{femaleName} has been successfully added.");
    }

    public static void RemoveFemale(string name)
    {
        femaleDates.Remove(name);
    }

    public static void RemoveFemaleInteractive()
    {
        Console.WriteLine("What female name would you like to remove?");
        string femaleRemove = Console.ReadLine();
        RemoveFemale(femaleRemove);
        Console.WriteLine($"{femaleRemove} has been successfully removed.");
    }
}