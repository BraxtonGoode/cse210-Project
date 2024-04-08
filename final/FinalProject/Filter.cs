using System;
using System.Collections.Generic;
using System.Linq;

public class Filter : EntertainmentManager
{
    // Variables
    // private List<EntertainmentMedia> _eMediaList;

    // Constructor
    public Filter(List<EntertainmentMedia> eMediaList)
    {
        _eMediaList = eMediaList;
    }

    // Method
    public List<EntertainmentMedia> FilterByPropertyValue(int propertyIndex, string desiredValue)
    {
        List<EntertainmentMedia> filteredList = new List<EntertainmentMedia>();

        foreach (EntertainmentMedia media in _eMediaList)
        {
            // Splitting by comma and accessing the property by index
            string[] properties = media.GetStringRepresentation().Split(',');
            if (properties.Length > propertyIndex && properties[propertyIndex].Trim() == desiredValue)
            {
                filteredList.Add(media);
            }
        }

        return filteredList;
    }
    
    public void GetFilter()
    {
    int userChoice;

    Console.WriteLine("    1.Media");
    Console.WriteLine("    2.Title");
    Console.WriteLine("    3.Rating");
    Console.Write("What would you like to filter by? (Type: 1, 2 or 3) ");
    string filterType = Console.ReadLine();

    if (int.TryParse(filterType, out userChoice))
    {
        Filter filter = new Filter(_eMediaList);
        if (userChoice == 1) // Media
        {
            Console.WriteLine("Media Types:");
            ListMedia();
            Console.Write("What media would you like to filter by? (EX: Books) ");
            string desiredFilter = Console.ReadLine();
            FilteredList = filter.FilterByPropertyValue(0, desiredFilter);
        }
        else if (userChoice == 2) // Title
        {
            Console.Write("Enter the desired title to filter by: ");
            string desiredTitle = Console.ReadLine();
            FilteredList = filter.FilterByPropertyValue(1, desiredTitle);
        }
        else if (userChoice == 3) // Rating
        {
            int desiredRating;
            Console.Write("Enter the desired Rating to filter by: ");
            string desiredRatingInput = Console.ReadLine();
            if (int.TryParse(desiredRatingInput, out desiredRating))
            {
                FilteredList = filter.FilterByPropertyValue(3, desiredRating.ToString());
            }
            else
            {
                Console.WriteLine("Invalid input for rating. Please enter a valid integer.");
                return;
            }
        }
        if (FilteredList != null)
        {
            // Output filtered list
            Console.WriteLine();
            Console.WriteLine("Filtered list:");
            foreach (var media in FilteredList)
            {
                Console.WriteLine(media.GetStringRepresentation());
            }
        }        
        else
        {
            Console.WriteLine("Could not Find anything that fit your filter. Try again!");
        }
    }


}

}