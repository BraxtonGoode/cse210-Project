using System;
using System.Collections.Generic;
using System.Linq;

public class Filter
{
    // Variables
    private List<EntertainmentMedia> _eMediaList;

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
}

