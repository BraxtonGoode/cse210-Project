using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;


    public void Display()
    {
        //shows the prompt and saves it into _promptText
        PromptGenerator RNDprompt = new PromptGenerator();
        _promptText = RNDprompt.GetRandomPrompt();
        Console.WriteLine(_promptText);

        //this saves your entry into the _entryText variable
        Console.Write(">");
        _entryText = Console.ReadLine();

        //saves the date
        _date = DateTime.Now.ToString("d/MM/yyyy");




    }

}