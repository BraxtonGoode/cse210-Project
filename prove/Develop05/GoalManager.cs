using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager 
{
    // varables
    private List<Goal> _goals;

    private int _score;  
    
    //constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;

    }
    // methods
    public void Start()
    {
        int UserChoice;

        do
        {
            
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goals");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            


            if (int.TryParse(input, out UserChoice))
            {
                // based upon user choice these methods are then called.
                if (UserChoice == 1)
                {
                    CreateGoals();

                }
                else if (UserChoice == 2)
                {
                    ListGoalDetails();

                }
                else if (UserChoice == 3)
                {
                    SaveGoals();
                }
                else if (UserChoice == 4)
                {
                    LoadGoals();
                }
                else if (UserChoice == 5)
                {
                    RecordEvent();

                }
                else if (UserChoice == 6)
                {
                    Console.WriteLine("Goodbye");
                }
            }
            else 
            {
                Console.WriteLine("Invalid input: please try again.");
            }


        }while (UserChoice!= 6);

    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");

    }

    public void ListGoalNames()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");

    }

    public void ListGoalDetails()
    {
        Console.Clear();
        if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to display.");
                return;
            }

        Console.WriteLine("Goal Details:");
        for (int i = 0; i < _goals.Count; i++)
            {
                
                Console.WriteLine($"{i + 1}: {_goals[i].GetDetailsString()}");
            }

    }

    public void CreateGoals()
    {
        int UserChoice;
        ListGoalNames();
        Console.Write("Which type of goal would you like to create? ");
        UserChoice = int.Parse(Console.ReadLine());

        if (UserChoice ==1)//Simple Goal
        {
            
            Console.Write("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();

            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);

            

            _goals.Add(simpleGoal);

            

        }
        else if (UserChoice == 2)//eternal goal
        {

            Console.Write("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();

            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            

            _goals.Add(eternalGoal);


        }
        else if (UserChoice == 3)//Checklist Goal
        {
            Console.Write("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int bonusTimes = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it many times? ");
            int bonus = int.Parse(Console.ReadLine());



            CheckListGoal checkListGoal = new CheckListGoal(name, description, points, 0 , bonusTimes, bonus);
            

            _goals.Add(checkListGoal);
            



        }
        Console.Clear();


    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int selectedGoalIndex) || selectedGoalIndex < 1 || selectedGoalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
            return;
        }

        Goal selectedGoal = _goals[selectedGoalIndex - 1];


        // Check if the selected goal is already complete
        if (!selectedGoal.IsComplete())
        {
            selectedGoal.RecordEvent();
                        
            Console.WriteLine($"Congratulations! You were at {_score} but now have earned {selectedGoal.GetPointValue()} more points!");
            UpdateScore(selectedGoal.GetPointValue());
            Console.WriteLine($"You now have {_score} points.");
            Console.WriteLine();
            selectedGoal.LeveledUp(_score);
        }
        else
        {
            Console.WriteLine("This goal is already complete. No points added.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            
            foreach (Goal goal in _goals)
            {
             if (goal.GetType() == typeof(SimpleGoal))
                {
                    SimpleGoal simpleGoal = (SimpleGoal)goal; // Cast to SimpleGoal
                    outputFile.WriteLine(simpleGoal.GetStringRepresentation());
                }
                else if (goal.GetType() == typeof(EternalGoal))
                {
                    EternalGoal eternalGoal = (EternalGoal)goal; // Cast to EternalGoal
                    outputFile.WriteLine(eternalGoal.GetStringRepresentation());
                    

                }
                else if (goal.GetType() == typeof(CheckListGoal))
                {
                    CheckListGoal checkListGoal = (CheckListGoal)goal;
                    outputFile.WriteLine(checkListGoal.GetStringRepresentation());
                }
                Console.Clear();
            
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);
        if (lines.Length > 0)
        {
            int.TryParse(lines[0], out _score); // Assuming the score is stored as an integer
        }

        // Read each goal from subsequent lines
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');

            if (parts.Length >= 4) // Ensure that the line contains the expected number of parts
            {
                string type = parts[0];         

                if (type == "SimpleGoal")
                {        
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    bool complete = Convert.ToBoolean(parts[4]);
   
                    Goal goal = new SimpleGoal(name, description, points); // Assuming complete is stored as a string representation of boolean
                    
                    if (complete)
                    {
                        goal.RecordEvent(); // Mark the goal as complete
                    }
                    _goals.Add(goal);

                    

                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    
                    
   
                    Goal goal = new EternalGoal(name, description, points); // Assuming complete is stored as a string representation of boolean

                    _goals.Add(goal);
                    
                }
                else if (type == "CheckListGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    int amountCompleted = Convert.ToInt16(parts[4]);
                    int target = Convert.ToInt16(parts[5]);
                    int bonus = Convert.ToInt16(parts[6]);


                    Goal goal = new CheckListGoal(name, description, points, amountCompleted, target, bonus); // Assuming complete is stored as a string representation of boolean

                    _goals.Add(goal);
                }
                


            }
            Console.Clear();
        }
    }
    private void UpdateScore(int points)
    {
        _score += points;
    }



}