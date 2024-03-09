using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    
    public void addEntry()
    {
        // opens when you choose Write option and share prompt for you to write and adds it to list
        Entry newEntry = new Entry();
        newEntry.Display(); // Display method captures the prompt, entry, and date.

        _entries.Add(newEntry); // Add the new entry to the list


           

    }

    public void DisplayAll()
    {
        // This is opened when you select Display option and it shows all the entries you have currently made
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date} Prompt: {entry._promptText}");
            Console.WriteLine($"Entry: {entry._entryText}");
            Console.WriteLine();
        }


    }

    public void SaveToFile(string loaded)
    {
        
        //This starts when you choose Save from menu and allows you to type in a given text file to save to 
        //(added)- it takes the parameter of loaded if it yes then you can immediately save, if no you get a message and must say yes or no to to continue to save
        if (loaded == "yes")
        {
            Console.WriteLine("What is the filename?");// Journal.txt is where i have been testing
            Console.Write(">");
            string filename = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
            foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");                
                
                }
            }
        }
        else if (loaded == "no")
        {
            Console.WriteLine("If you save file to an existing one you may overwrite the existing file. Do you wish to continue? (YES or NO)");
            Console.Write(">");
            string readAnswer = Console.ReadLine().ToLower();
            if (readAnswer == "yes")
            {
                Console.WriteLine("What is the filename?");
                Console.Write(">");
                string filename = Console.ReadLine();
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");                
                    
                    }
                }
            }
            else if (readAnswer == "no")
            {
                return;
            }
        }

   


    }

    public void LoadFromFile()
    {
        // this is opened when you choose the load option and asks you name of file to load.
        Console.WriteLine("What is the filename?");
        Console.Write(">");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        
        foreach (string line in lines)
    {
        string[] parts = line.Split(",");

        
            string date = parts[0];
            string prompt = parts[1];
            string answer = parts[2];

            // Create a new Entry object using the parsed data
            Entry entry = new Entry();
            entry._date = date;
            entry._promptText = prompt;
            entry._entryText = answer;

            // Add the new Entry object to the list of entries
            _entries.Add(entry);
        
      
    }

 
    }
}