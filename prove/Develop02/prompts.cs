using System;
using System.Collections.Generic;

class Prompt
{
    public string _promptContainer;

    public List<string> _prompts = new List<string>
    {
        "What is something that you smelled today?",
        "How did you see the Hand of the Lord",
        "What was something that made you smile?",
        "What was something that was hard for you today?",
        "What was something that you learned?"
    };

    public void GivenPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        _promptContainer = _prompts[index];
        Console.WriteLine(_promptContainer);
    }
}