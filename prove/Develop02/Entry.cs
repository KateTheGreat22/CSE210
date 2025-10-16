using System;

public class Entry
{
    public string GivenPrompt { get; set; }
    public string EntryDateTime { get; set; }
    public string EntryText { get; set; }

    public Entry(string givenPrompt, string entryDateTime, string entryText)
    {
        GivenPrompt = givenPrompt;
        EntryDateTime = entryDateTime;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {EntryDateTime}");
        Console.WriteLine($"Prompt: {GivenPrompt}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine("---------------------------");
    }
}