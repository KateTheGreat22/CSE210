using System;
using System.Threading;

class Breathing : Activity
{
    public Breathing() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("How long, in seconds, would you like to practice for?");
        if (int.TryParse(Console.ReadLine(), out int breathe))
        {
            _duration = breathe;
            Console.WriteLine($"You will practice for {breathe} seconds.");
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
        
        BreathingPractice();
        EndMessage();
    }

    private void BreathingPractice()
    {
        int elapsed = 0;
        int breathDuration = 5; 
        
        while (elapsed < _duration)
        {
            // Breathe in
            if (elapsed + breathDuration > _duration)
            {
                breathDuration = _duration - elapsed;
            }
            
            Console.Write("Breathe in...");
            DisplayCountdown(breathDuration);
            Console.WriteLine();
            elapsed += breathDuration;
            
            if (elapsed >= _duration) break;
            
            // Breathe out
            int breathOutDuration = 5;
            if (elapsed + breathOutDuration > _duration)
            {
                breathOutDuration = _duration - elapsed;
            }
            
            Console.Write("Now breathe out...");
            DisplayCountdown(breathOutDuration);
            Console.WriteLine();
            elapsed += breathOutDuration;
        }
    }
}