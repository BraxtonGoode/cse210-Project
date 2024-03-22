using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : Activity
{
    //member variables
    private List<string>_prompts = new List<string>();
    private List<string>_questions = new List<string>();
    private int _currentIndex = 0;
    private int _repeatIndex = 0;

    //constructor
    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you to reflect on times in your life and to help you recognize the power you have had on all aspects of  your life.";
        
    
    
    } 

    // methods
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {DisplayPrompt()}---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now Ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        AddQuestions("no");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        while (currentTime <= futureTime)
        {
            Console.Write(">");
            Console.WriteLine(DisplayQuestions());
            ShowSpinner();    
            _currentIndex++;
            _repeatIndex++;
            currentTime = DateTime.Now;
            if (_repeatIndex == 9)
            {
                AddQuestions("no");
                _repeatIndex = 0;
            }       
            
        }
        Console.WriteLine();
        AddQuestions("yes");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random RNDPrompt = new Random();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        int prompt = RNDPrompt.Next(_prompts.Count);      
        
        return _prompts[prompt];
    }

    public string DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        return prompt;

    }

    // Added the benefit of choosing random questions without repeating until the end.

    private void AddQuestions(string yes)
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
        ShuffleQuestions();

        if (yes == "yes")
        {
            _questions.Clear();
        }        
    }

    private void ShuffleQuestions()
    {
        _questions = _questions.OrderBy(question => Guid.NewGuid()).ToList();
        _currentIndex = 0;

    }


    public string GetRandomQuestion()
    {
        if (_currentIndex >= _questions.Count)
        {
            AddQuestions("no");
            throw new InvalidOperationException("No questions available.");
            
        }


        return _questions[_currentIndex];
    }
    

    public string DisplayQuestions()
    {      

        string DisplayQuestion = GetRandomQuestion();

        return DisplayQuestion;
        
    }

}


