using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) :base (name,description,points)
    {
        _shortName = name;
        _description = description;
        _points = points;        

    }



    public override void RecordEvent()
    {
       bool _iscomplete = IsComplete();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {_shortName}: {_description}: {_points}";
    }

        public override int GetPointValue()
    {
        
        int pointValue;
        if (!int.TryParse(_points, out pointValue))
        {
            Console.WriteLine("Error: Invalid point value format.");
            return 0; // Return 0 if parsing fails
        }
        return pointValue;
    }

}