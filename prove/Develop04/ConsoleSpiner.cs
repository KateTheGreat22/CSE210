using System;
using System.Threading;

// Note: This class is no longer needed as the spinner functionality and
// has been moved into the Activity base class. I just want it in case something breaks as
// Keeping this file for reference, but it's not used in the program.

public class ConsoleSpiner
{
    public void Spin(int seconds)
    {
        string[] sequence = { "/", "-", "\\", "|" };
        int iterations = seconds * 5; 

        for (int i = 0; i < iterations; i++)
        {
            Console.Write(sequence[i % sequence.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }
}