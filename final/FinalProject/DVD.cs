using System;

public class DVD : EntertainmentMedia
{
    // variables

    private string _DirectedBy;

    //Constructor
    public DVD(string title, string genre, int rating, string creator) : base(title,genre,rating)
    {
        _title = title;
        _genre = genre;
        _rating = rating;
             
        _DirectedBy = creator;


    }

    //Methods

    public override string GetDetailsString()
    {
        string details = $"Title: {_title},Genre: {_genre},Rating: {_rating} of 5,DirectedBy: {_DirectedBy}";

        return details;
    }

    public override string GetStringRepresentation()
    {
        string details = $"DVDs,{_title},{_genre},{_rating},{_DirectedBy}";

        return details;
    }
}