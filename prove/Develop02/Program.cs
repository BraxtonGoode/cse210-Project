using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        Journal journal = new Journal();

        string _loaded = "no";
     

        // extra piece of code starts off asking if you want to load a given file or not.
        Console.WriteLine("Do you wish to load a Saved file to start with?(YES or NO)");
        Console.Write(">");            
        string startLoadFile = Console.ReadLine().ToLower();
        if (startLoadFile == "yes")
        {
            Console.Clear();
            journal.LoadFromFile();
            _loaded = "yes";
        }
        else
        {
            
            Console.Clear();
        }

        int userChoice;

        
       
        do 
        {
             // The menu of options to choose from
            Console.WriteLine("Please select one of the following options.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write(">");
            userChoice = int.Parse(Console.ReadLine());         
            Console.WriteLine();



            if (userChoice == 1 )
            {
                Console.Clear();
                journal.addEntry();
            }
            else if (userChoice == 2)
            {
                Console.Clear();
                journal.DisplayAll();

            }
            else if (userChoice ==3)
            {
                Console.Clear();
                journal.SaveToFile(_loaded);

            }
            else if (userChoice ==4 )
            {
                Console.Clear();
                journal.LoadFromFile();
            }
            else if (userChoice == 5 )
            {
                Console.Clear();
                Console.WriteLine("Good Bye!");
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Select a different number!");
            }
        } while (userChoice != 5);









    }
}