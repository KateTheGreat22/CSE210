using System;
using System.Collections.Generic;
using System.IO;

public class Menu
{
    public void MenuDisplay()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
    }
}