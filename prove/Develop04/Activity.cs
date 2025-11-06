using System;
using System.Threading;

public class Activity
{
    protected int _duration;
    protected string _activityName;
    protected string _description;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Setting duration to 30 seconds.");
            _duration = 30;
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner(3);
        Console.WriteLine();
    }

    public void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        DisplaySpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName}.");
        DisplaySpinner(3);
    }

    public void DisplaySpinner(int seconds)
    {
        string[] sequence = { "|", "/", "-", "\\" };
        int iterations = seconds * 5; 
        
        for (int i = 0; i < iterations; i++)
        {
            Console.Write(sequence[i % sequence.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    public void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}