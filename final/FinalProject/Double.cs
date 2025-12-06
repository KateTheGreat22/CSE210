using System;
class Double : Date
{
    public Double(string name, string description) 
        : base(name, description, "Double")
    {
    }

    protected override string AskSpecificQuestions()
    {
        Console.WriteLine("Did you feel that going on a double date was effective with your date?");
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
        return $"Double date: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"Double|{_name}|{_description}";
    }
}