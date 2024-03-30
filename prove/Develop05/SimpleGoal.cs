using System;



public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) :base (name,description,points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isComplete = false;        
        

    }

    public override void RecordEvent()
    {
        _isComplete = true;

    }

    public override bool IsComplete()
    {
        
        
        return _isComplete;
    }
    public override int GetPointValue()
    {
        // Parse the string points to int, handling any potential parsing errors
        int pointValue;
        if (!int.TryParse(_points, out pointValue))
        {
            Console.WriteLine("Error: Invalid point value format.");
            return 0; // Return 0 if parsing fails
        }
        
        return pointValue;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}:{_description}:{_points}:{_isComplete}";
    }


}