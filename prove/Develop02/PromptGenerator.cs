using System;
using System.Collections.Generic;

public class PromptGenerator
{

    public string GetRandomPrompt()
    {       
        Random randomNumber = new Random();
        int chosenNumber = randomNumber.Next(1, 6); // Generate a random number between 1 and 5

        string prompt;

        if (chosenNumber == 1)
        {
            prompt = "What was your favorite thing about today?";
        }
        else if (chosenNumber == 2)
        {
            prompt = "What was your least favorite thing about today?";
        }
        else if (chosenNumber == 3)
        {
            prompt = "Did you talk to anyone today?";
        }
        else if (chosenNumber == 4)
        {
            prompt = "What is something you've learned today?";
        }
        else
        {
            prompt = "What is something you have read that you have found interesting?";
        }

        return prompt;
    }
}

