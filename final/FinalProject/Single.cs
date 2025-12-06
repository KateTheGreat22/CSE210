using System;
class Single : Date
{
    public Single(string name, string description) 
        : base(name, description, "Single")
    {
    }

    protected override string AskSpecificQuestions()
    {
        Console.WriteLine("Did you feel that going on a single date was effective with your date?");
        return Console.ReadLine();
    }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"Single date: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"Single|{_name}|{_description}";
    }
}