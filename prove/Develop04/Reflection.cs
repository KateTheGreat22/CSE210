using System;
using System.Collections.Generic;
using System.Threading;

class Reflection : Activity
{
    public string _promptContainer;
    public string _followupsContainer;

    public List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you appreciated nature fully."
    };

    public List<string> _followups = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _usedFollowups = new List<string>();

    public Reflection() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        StartMessage();
        RunReflection();
        EndMessage();
    }

    private void RunReflection()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        GivenRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        DisplayCountdown(5);
        Console.Clear();

        int elapsed = 0;
        int questionPause = 10; 
        
        while (elapsed < _duration)
        {
            if (elapsed + questionPause > _duration)
            {
                questionPause = _duration - elapsed;
            }
            
            GivenFollowUps();
            DisplaySpinner(questionPause);
            Console.WriteLine();
            elapsed += questionPause;
        }
    }

    public void GivenRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        _promptContainer = _prompts[index];
        Console.WriteLine($"--- {_promptContainer} ---");
    }

    public void GivenFollowUps()
    {
        Random randomGenerator = new Random();
        
        // Reset if all questions have been used
        if (_usedFollowups.Count >= _followups.Count)
        {
            _usedFollowups.Clear();
        }
        
        string selectedQuestion;
        do
        {
            int index = randomGenerator.Next(_followups.Count);
            selectedQuestion = _followups[index];
        } while (_usedFollowups.Contains(selectedQuestion));
        
        _usedFollowups.Add(selectedQuestion);
        _followupsContainer = selectedQuestion;
        Console.Write($"> {_followupsContainer} ");
    }
}