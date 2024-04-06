using System;

public class CD : EntertainmentMedia
{
    // variables

    private string _singer;

    //Constructor
    public CD(string album, string genre, int rating, string singer) : base(album,genre,rating)
    {
        _title = album;
        _genre = genre;
        _rating = rating;
             
        _singer = singer;


    }

    //Methods

    public override string GetDetailsString()
    {
        string details = $"Album: {_title},Genre: {_genre},Rating: {_rating} of 5,Singer: {_singer}";

        return details;
    }

    public override string GetStringRepresentation()
    {
        string details = $"CDs,{_title},{_genre},{_rating},{_singer}";

        return details;
    }
}