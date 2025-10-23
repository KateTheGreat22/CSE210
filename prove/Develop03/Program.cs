using System;

//To exceed requirements, the code will only select words at random that have not already been hidden. 
class Program
{
    static void Main(string[] args)

    {
        Reference reference = new Reference("Acts", 4, 20);

        Scripture scripture = new Scripture(reference, "For we cannot but speak the things which we have seen and heard.");
        
        string response = "";

        while (response != "quit" && !scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.DisplayWithReference();


            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            response = Console.ReadLine();

            if (response != "quit")
            {
                scripture.HideRandomWord();
            }
        }

        // Display one final time to show all words hidden
        if (response != "quit")
        {
            Console.Clear();
            scripture.DisplayWithReference();
        }

        Console.WriteLine("\nProgram is finished. Have a nice day!");
    }
}
