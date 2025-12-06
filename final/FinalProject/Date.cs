using System;
using System.IO;

public abstract class Date
{
    protected string _name;
    protected string _description;
    protected string _type;

    public Date(string name, string description, string type)
    {
        _name = name;
        _description = description;
        _type = type;
    }

    public void ReportDate()
    {
        Console.WriteLine("Did you feel safe on the date?");
        string safety = Console.ReadLine();

        string additionalInfo = AskSpecificQuestions();

        Console.WriteLine("What did you do for the date?");
        string activity = Console.ReadLine();

        Console.WriteLine("Would you be willing to save your response?");
        string response = Console.ReadLine();

        if (response == "yes")
        {
            SaveResponse(safety, additionalInfo, activity);
        }
        else if (response == "no")
        {
            Console.WriteLine("Would you like to report this person as unsafe? (yes/no)");
            string report = Console.ReadLine();

            if (report == "yes")
            {
                Console.WriteLine("Who did you go on a date with?");
                string delete = Console.ReadLine();

                if (Male.GetMaleDates().Contains(delete))
                {
                    Male.RemoveMale(delete);
                    Console.WriteLine($"{delete} has been removed from the dating pool. Thank you for reporting.");
                }
                else if (Female.GetFemaleDates().Contains(delete))
                {
                    Female.RemoveFemale(delete);
                    Console.WriteLine($"{delete} has been removed from the dating pool. Thank you for reporting.");
                }
                else
                {
                    Console.WriteLine($"{delete} was not found in either dating pool.");
                }
            }
            else
            {
                Console.WriteLine("Have a lovely day");
                Environment.Exit(0);
            }
        }
        else
        {
            Console.WriteLine("Have a lovely day");
            Environment.Exit(0);
        }
    }

    protected abstract string AskSpecificQuestions();

    private void SaveResponse(string safety, string additionalInfo, string activity)
    {
        Console.WriteLine("What file would you like to save to:");
        string file = Console.ReadLine();
        
        file = $"{file}.txt";

        using (StreamWriter writer = File.AppendText(file))
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            writer.WriteLine($"{timestamp}|{_type}|{safety}|{additionalInfo}|{activity}");
        }
        
        Console.WriteLine("Response saved successfully!");
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public virtual string GetDisplayString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    public string GetDate()
    {
        return _type;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDetails()
    {
        return _description;
    }
}