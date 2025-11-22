using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _bonusAwarded;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = false;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = (amountCompleted >= target);
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

    public int GetPointsForEvent()
    {
        if (_amountCompleted == _target && !_bonusAwarded)
        {
            _bonusAwarded = true;
            return _points + _bonus;
        }
        return _points;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}