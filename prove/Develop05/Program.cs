using System;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager goalManager = new GoalManager();
        
        goalManager.Start();
     
        
    }
}

/*Additions to code are:
1. The menu of options inside the start method of the GoalManager class now has some error handling so if you dont type correct input it will give you error message
2. Added 3 new methods to the goal class which are LevelUp(), SetRankings(), and CompareRankings().
    -LeveledUp() reads each item inside the _rankings list and splits it between points and rank and then it checks the score against the ranked points and if its greater 
        gives you the coresponding rank in a message
    - SetRankings() adds the entries for the _rankings list
    - CompareRankings() takes currentranking and ranking as parmeter and compares which one is greater in the list and return which one is.*/