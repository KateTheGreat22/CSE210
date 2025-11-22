using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
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
        return $"{GetDisplayString()}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name}|{_description}|{_points}";
    }
}