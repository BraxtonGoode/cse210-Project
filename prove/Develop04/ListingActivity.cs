using System;

public class ListingActivity : Activity
{
    //member variables

    private int _count;
    private List<string>_prompts = new List<string>();

    // constructor
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on moments in your life by having you list as many things about it as you can.";

    }

    // methods 
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompts()}---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        while (currentTime <= futureTime)
        {
            Console.Write(">");
            Console.ReadLine();
            currentTime = DateTime.Now;
            _count++;    
            
        }
        Console.WriteLine($"You listed {_count} items!");
        _count = 0;
        GetListFromUser("yes");
        DisplayEndingMessage();
    }

    public string GetRandomPrompts()
    {
        GetListFromUser("no");

        Random RNDPrompt = new Random();      
        
        int index = RNDPrompt.Next(_prompts.Count);
        return _prompts[index];

    }

    public List<string> GetListFromUser(string yes)
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

        if(yes == "yes".ToLower())
        {
            _prompts.Clear();
        }
        return _prompts;

    }
}