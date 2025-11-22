using System;

public class SimpleGoal : Goal
{
    private int _amountCompleted;
    private int _target;

    public SimpleGoal(string name, string description, int points, int target) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
    }

    public SimpleGoal(string name, string description, int points, int target, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDisplayString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetDetailsString()
    {
        return GetDisplayString();
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name}|{_description}|{_points}|{_target}|{_amountCompleted}";
    }
}