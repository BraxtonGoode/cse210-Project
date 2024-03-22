using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // initializing activities
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        //Testing
        //reflection.DisplayQuestions();

        // Console.WriteLine(test);
        //reflection.ShowSpinner();



        //Menu of options
        int userChoice = 0;
        bool isValidChoice = false;

        do 
        {
            do
            {            
            Console.Clear();            
            Console.WriteLine("Menu options: ");
            Console.WriteLine("     1. Start breathing activity");
            Console.WriteLine("     2. Start reflection activity");
            Console.WriteLine("     3. Start listing activity");
            Console.WriteLine("     4. Quit");
            Console.Write("Select a choice from menu: ");
            
            string userInput = Console.ReadLine();
            
            if (!int.TryParse(userInput,out userChoice))
            {
                Console.WriteLine("Please try again with a number between 1 through 4");
                Console.WriteLine("Press any key to retry...");
                Console.ReadKey();
                
            }
            else
            {
                isValidChoice = true;
            }

            } while (!isValidChoice);
            

            if (userChoice == 1)
            {
                breathing.Run();
            }
            else if (userChoice == 2)
            {
                reflection.Run();
            }
            else if (userChoice == 3)
            {
                listing.Run();
            }
            else if (userChoice == 4)
            {
                Console.WriteLine("Goodbye");
            }
            else 
            {
                Console.WriteLine("Please try again");
            }



        }while (userChoice != 4);

        
    }
}
// Additions away from base program
// --------------------------------
// For the Mindfulness program i added 3 new pieces that were not originally part of the program.
//      1. In the Program file i added a UserInput check which will check if the user typed a number 
//          between 1 through 4 and if not they have are told to try again.

//      2. in the program file for option 4 i added a GoodeBye message upon it quiting.

//      3. The Reflection activity Creates a random list of questions that do not repeat until you have
//          used them all at one time then reshuffles and goes again until the duration of the program is complete.