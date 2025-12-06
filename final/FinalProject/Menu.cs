using System;

//I kept this in a seperate class in case I wanted to update the menu to add more options
class Menu
{
    public static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("  1. Report on your date");
        Console.WriteLine("  2. Add a person into the dating pool");
        Console.WriteLine("  3. Remove a person from the dating pool");
        Console.WriteLine("  4. Generate date pairs for this week");
        Console.WriteLine("  5. Quit");
        Console.Write("Select a choice from the menu: ");
}
}