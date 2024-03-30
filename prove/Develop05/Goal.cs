using System;
using System.Dynamic;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    private string _currentRanking;

    private List<String> _rankings;
    

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _rankings = new List<string>();
        _currentRanking = "NONE";
        SetRankings();
        
        
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();
    public abstract int GetPointValue();



    public virtual string  GetDetailsString()
    {
        
        string completionStatus = IsComplete() ? "[x]" : "[ ]";
        return $"{completionStatus} {_shortName}: {_description}";

    }

    public abstract string GetStringRepresentation();



    //additions from base program down below!!


    public void LeveledUp(int score)
    {

        for (int i = 0; i < _rankings.Count; i++)
        {
            string rank = _rankings[i];
            string[] parts = rank.Split(",");
            string ranking = parts[0];
            int points = Convert.ToInt16(parts[1]);

            if (score >= points)
            {



                if (CompareRankings(ranking, _currentRanking) > 0)
                {
                    Console.WriteLine($"You have leveled up, your ranking is now {ranking}!");
                    _currentRanking = ranking; // Update the highest achieved ranking
                }
            }


        

        }

    }
    private void SetRankings()
    {
        // create ranking and point values
        _rankings.Add("Amateur,100");
        _rankings.Add("Bronze,500");
        _rankings.Add("Silver,1000");
        _rankings.Add("Gold,2000");
        
    }

    private int CompareRankings(string ranking1, string ranking2)
    {
        // list and then comparing the order of rankings
        List<string> order = new List<string> { "Amateur", "Bronze", "Silver", "Gold" };
        return order.IndexOf(ranking1) - order.IndexOf(ranking2);
    }


}