using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Writing : Activity
{
    public string _BulletsContainer;
    public List<string> _Bullets = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Writing() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        StartMessage();
        RunListing();
        EndMessage();
    }

    private void RunListing()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        GivenRandomBulletPrompt();
        Console.Write("You may begin in: ");
        DisplayCountdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        Stopwatch stopwatch = Stopwatch.StartNew();
        int durationMs = _duration * 1000;

        while (stopwatch.ElapsedMilliseconds < durationMs)
        {
            Console.Write("> ");
            
            if (stopwatch.ElapsedMilliseconds >= durationMs)
            {
                break;
            }

            string entry = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(entry) && stopwatch.ElapsedMilliseconds < durationMs)
            {
                items.Add(entry);
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"You listed {items.Count} items!");
    }

    public void GivenRandomBulletPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_Bullets.Count);
        _BulletsContainer = _Bullets[index];
        Console.WriteLine($"--- {_BulletsContainer} ---");
    }
}