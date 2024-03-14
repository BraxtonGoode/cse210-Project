using System;
using System.IO;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
        

        // Member variables
        Reference reference = new Reference("Proverbs", 3, 5,6);
        Scripture scripture = new Scripture(reference, "Trust in the lord with all thine heart; and lean not unto thine own understanding. In all they ways acknowledge him, and he shall direct thy paths.");

        string userInput = "";

        do
        {
            // had to put this in my Console.clear statement kept giving me problems. so better safe than sorry
            try
            {
                Console.Clear();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while clearing the console:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            
            // Display reference and scripture
            Console.Write(reference.GetDisplayText());
            Console.WriteLine($" {scripture.GetDisplayText()}");
            Console.WriteLine();

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden.");
                userInput = "quit";
            }
            else
            {
                Console.WriteLine("To continue, press Enter or type 'quit' to exit.");
                userInput = Console.ReadLine().ToLower();

                // Hide random words if user pressed Enter
                if (userInput == "")
                {
                    // The number of words to hide 
                    int numToHide = 1;
                    scripture.HideRandomWords(numToHide);
                }
                else
                {
                    Console.WriteLine("Try again, only hit enter or type 'quit'");
                    Thread.Sleep(5000);
                }
            }
        } while (userInput != "quit");
    }
}

//my added pieces of code involve some error handling namely consol.clear() it seemed to have a problem using the debugger on the top right of screen.
//I also added the component where if you dont type Quit and hit enter you recieve a message saying to try again and then after 5 seconds it clears the screen.

