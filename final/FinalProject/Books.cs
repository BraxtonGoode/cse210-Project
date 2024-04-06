using System;
using System.ComponentModel;

public class Books : EntertainmentMedia
{
    // variables

    private string _author;
    private string _illustrator;

    //Constructor
    public Books(string title, string genre, int rating, string author, string illustrator) : base(title,genre,rating)
    {
        _title = title;
        _genre = genre;
        _rating = rating;

        
        _author = author;
        _illustrator = illustrator;



    }

    public Books(string title, string genre, int rating, string author) : base (title, genre, rating)
    {
       
        _author = author;
    }

    //Methods

    public override string GetDetailsString()
    {
        string details = $"Title: {_title},Genre: {_genre},Rating: {_rating} of 5,Author: {_author}";

        if (!string.IsNullOrEmpty(_illustrator))
        {
            details += $",Illustrator: {_illustrator}";
        }

        return details;
    }

    public override string GetStringRepresentation()
    {
        string details = $"Books,{_title},{_genre},{_rating},{_author}";

        if (!string.IsNullOrEmpty(_illustrator))
        {
            details += $",{_illustrator}";
        }

        return details;
    }
}