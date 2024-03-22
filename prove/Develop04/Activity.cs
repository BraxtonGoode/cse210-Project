using System;
using System.Reflection;
using System.Threading;

public class Activity
{
    //Member variables
    protected string _name = "";
    protected string _description ="";
    protected int _duration;

    //constructor
    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    //Methods
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();   
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(); 
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!!");
        ShowSpinner();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner();

    }

    public void ShowSpinner()
    {
        List<string> animationString = new List<string>();
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
        animationString.Add("|");       


        foreach (string animation in animationString)
        {
            Console.Write(animation);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i>0 ; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

    }

}