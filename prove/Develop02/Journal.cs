using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void MenuDisplay()
    {
        Console.WriteLine("Please Select Your Option For Today:");
        Console.WriteLine("Write an entry = 1");
        Console.WriteLine("Display the current journal = 2");
        Console.WriteLine("Save your journal = 3");
        Console.WriteLine("Load the file from the journal = 4");
        Console.WriteLine("To see the menu again = 5");
    }

    public void WriteEntry(int menuChoice, string response)
    {
        if (menuChoice == 1)
        {
            Prompt prompt = new Prompt();
            prompt.GivenPrompt();
            
            Console.WriteLine("Please write your journal entry:");
            string entryText = Console.ReadLine();
            
            DateTime now = DateTime.Now;
            string entryDateTime = now.ToString("MMMM dd, yyyy");
            
            Entry entries = new Entry(prompt._promptContainer, entryDateTime, entryText);
            AddEntry(entries);
        }
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

public void DisplayEntry(int menuChoice)
{
    if (menuChoice == 2)
    {
        Console.WriteLine("======= My Journal =======");
        foreach (Entry entry in _entries) 
        {
            entry.Display();  
        }
    }
}
    public void SaveEntry(int menuChoice)
    {
        if (menuChoice == 3)
        {
            Console.WriteLine("What file would you like to save your journal to:");
            string file = Console.ReadLine();

            file = $"{file}.txt";

            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry.EntryDateTime}|{entry.GivenPrompt}|{entry.EntryText}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
    }

public void LoadEntry(int menuChoice)
{
    if (menuChoice == 4)
    {
        Console.WriteLine("What file would you like to load:");
        string file = Console.ReadLine();
        
        file = $"{file}.txt";
        
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry(parts[1], parts[0], parts[2]);
                    AddEntry(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
            
            Console.WriteLine("\n======= Loaded Journal =======");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
    public void ProvideMenu(int menuChoice)
    {
        if (menuChoice == 5)
        {
            MenuDisplay();
        }
    }
}