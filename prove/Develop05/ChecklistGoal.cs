using System;

public class CheckListGoal : Goal
{
    private int _amountCompleted;

    private int _target;

    private int _bonus;
    private bool _isComplete;

    public CheckListGoal(string name, string description, string points, int amountCompleted, int target, int bonus ) :base (name,description,points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        bool _isComplete = IsComplete();
        _amountCompleted ++;
        
    }

    public override bool IsComplete()
    {
        if (_amountCompleted != _target)
        {
            _isComplete = false;

        }
        else if (_amountCompleted == _target)
        {
            _isComplete = true;
        }

        return _isComplete;
    }

    public override int GetPointValue()
    {
        // gains points for everytime but an adiitional bonus when target and amountCompleted are the same.
        int pointValue;
        if (!int.TryParse(_points, out pointValue))
        {
            Console.WriteLine("Error: Invalid point value format.");
            return 0; // Return 0 if parsing fails
        }
        if (_amountCompleted == _target)
        {
            pointValue = pointValue + _bonus;
        }
        
        return pointValue;
    }

    public override string GetDetailsString()
    {
        string completionStatus = IsComplete() ? "[x]" : "[ ]";
        return $"{completionStatus} {_shortName}: {_description} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"CheckListGoal: {_shortName}: {_description}: {_points}: {_amountCompleted}: {_target}: {_bonus}";
    }


}