using System;

public abstract class EntertainmentMedia
{
    // Variables
    protected string _title; 
    protected string _genre; 
    protected int _rating;
    // Constructor
    public EntertainmentMedia(string title, string genre, int rating)
    {
        _title = title;
        _genre = genre;
        _rating = rating;

    }

    // Methods
    public abstract string GetDetailsString();

    public abstract string GetStringRepresentation();
}