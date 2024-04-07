using System;
using System.Collections.Generic;
using System.IO;

public class SaveandLoad
{
    // Variables
    private List<EntertainmentMedia> _eMediaList;

    // Constructor
    public SaveandLoad(List<EntertainmentMedia> eMediaList)
    {
        _eMediaList = eMediaList;
    }

    // Methods

    public void SaveToCSV()
    {
        if (_eMediaList.Count == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }

        try
        {
            Console.Write("What is the filename we are saving to? ");
            string filePath = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (EntertainmentMedia media in _eMediaList)
                {
                    writer.WriteLine(media.GetStringRepresentation());
                }
            }

            Console.WriteLine("Entries saved to CSV successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while saving entries: {ex.Message}");
        }
    }

    public void LoadCSV()
    {
        try
        {
            Console.Write("What is the filename we are saving to? ");
            string filePath = Console.ReadLine();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');

                    
                    string type = parts[0];
                    string title = parts[1];
                    string genre = parts[2];
                    int rating = int.Parse(parts[3]);
                    string creator = parts[4];
                    string illustrator = parts.Length > 5 ? parts[5] : null;

                    if (type == "Books")
                    {
                        _eMediaList.Add(new Books(title, genre, rating, creator, illustrator));
                    }
                    else if (type == "CDs")
                    {
                        _eMediaList.Add(new CD(title, genre, rating, creator));
                    }


                    // Add similar conditions for other types of entertainment media if needed
                    // DVD
                }
            }

            Console.WriteLine("Entries loaded from CSV successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while loading entries: {ex.Message}");
        }
    }
}
