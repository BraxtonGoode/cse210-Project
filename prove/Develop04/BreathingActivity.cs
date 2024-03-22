using System;
using System.Globalization;

public class BreathingActivity : Activity
{
    // constructor
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you to relax by having you breathe in and out.";
    }

    // methods

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();   
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        while (currentTime <= futureTime)
        {
            Console.WriteLine();
            Console.Write("Breathe In ...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.Write("Breath out ...");            
            ShowCountDown(5);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        Console.WriteLine();
        
        DisplayEndingMessage();   

    }
    
} 