using System;
class Group : Date
{
    public Group(string name, string description) 
        : base(name, description, "Group")
    {
    }

    protected override string AskSpecificQuestions()
    {
        Console.WriteLine("Who did you go with on the group date?");
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
        return $"Group date: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"Group|{_name}|{_description}";
    }
}