using System;
using System.Runtime.CompilerServices;

public class EntertainmentManager
{
    //Variables
    protected List<EntertainmentMedia> _eMediaList;
    protected List<EntertainmentMedia> FilteredList;
    int rating;
    bool validRating = false;


    // Constructor
    public EntertainmentManager()
    {
        _eMediaList = new List<EntertainmentMedia>();
        

    }

    //Methods

    public void Start()
    {
        int UserChoice;

        do
        {
            
            
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Media Entry");
            Console.WriteLine("    2. List Media Entries");
            Console.WriteLine("    3. Save Entries");
            Console.WriteLine("    4. Load Entries");
            Console.WriteLine("    5. Filter Entries");
            Console.WriteLine("    6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            


            if (int.TryParse(input, out UserChoice))
            {
                // based upon user choice these methods are then called.
                if (UserChoice == 1)
                {
                   
                    CreateEntry(); 

                }
                else if (UserChoice == 2)
                {
                    
                    ListEntries();         

                }
                else if (UserChoice == 3)
                {
                    SaveandLoad saveandLoad = new SaveandLoad(_eMediaList);
                    saveandLoad.SaveToCSV();
       
                }
                else if (UserChoice == 4)
                {
                    SaveandLoad saveandLoad = new SaveandLoad(_eMediaList);
                    saveandLoad.LoadCSV();
   
                }
                else if (UserChoice == 5)
                {
                    Filter filter = new Filter(_eMediaList);
                    filter.GetFilter();  

                }
                else if (UserChoice == 6)
                {
                    Console.WriteLine("Goodbye");
                }
            }
            else 
            {
                Console.WriteLine("Invalid input: please try again.");
            }


        }while (UserChoice!= 6);

    

    }

    public void CreateEntry()
    {
        int UserChoice;
        Console.WriteLine("Create new Entry:");
        ListMedia();
        Console.Write("Type number of what you would like to create? ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out UserChoice))
        {
            if (UserChoice == 1)//Book
            {
                Console.Write("What is the title of the book? ");
                string title = Console.ReadLine();

                Console.Write("What is the genre of the book? ");
                string genre = Console.ReadLine();

                Console.Write("What is the author of the book? ");
                string author = Console.ReadLine();

                
                do
                {
                    Console.Write("What is the rating on this book? (out of 5) ");
                    string ratingInput = Console.ReadLine();

                    if (int.TryParse(ratingInput, out rating))
                    {
                        validRating = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for the rating.");
                    }
                } while (!validRating);

                Console.Write("Does this book have an illustrator? (Yes/No) ");
                string illustrator = Console.ReadLine().ToLower();
                if (illustrator == "yes")
                {
                    Console.Write("What is the name of the illustrator? ");
                    string illustratorName = Console.ReadLine();
                    Books illustratedbooks = new Books(title,genre,rating,author,illustratorName);
                    _eMediaList.Add(illustratedbooks);
                }
                else if (illustrator == "no")
                {
                    Books books = new Books(title,genre,rating,author);

                    _eMediaList.Add(books);
                }
                
            }
            else if (UserChoice == 2)//DVD
            {
                Console.Write("What is the DVD name? ");
                string title = Console.ReadLine();

                Console.Write("What is the DVD genre? ");
                string genre = Console.ReadLine();

                Console.Write("Who Directed the DVD? ");
                string director = Console.ReadLine();

                
                do
                {
                    Console.Write("What is the rating on this DVD? (out of 5) ");
                    string ratingInput = Console.ReadLine();

                    if (int.TryParse(ratingInput, out rating))
                    {
                        validRating = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for the rating.");
                    }
                } while (!validRating);            
                
                
                DVD dvd = new DVD(title,genre,rating,director);
                _eMediaList.Add(dvd);
                
            }
            else if (UserChoice == 3)//CD
            {
                Console.Write("What is the CD name? ");
                string Album = Console.ReadLine();

                Console.Write("What is the CD genre? ");
                string genre = Console.ReadLine();

                Console.Write("Who is the singer for the CD? ");
                string singer = Console.ReadLine();

                
                do
                {
                    Console.Write("What is the rating on this book? (out of 5) ");
                    string ratingInput = Console.ReadLine();

                    if (int.TryParse(ratingInput, out rating))
                    {
                        validRating = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for the rating.");
                    }
                } while (!validRating);            
                
                
                CD cD = new CD(Album,genre,rating,singer);
                _eMediaList.Add(cD);
                

            }
            else
            {
                Console.WriteLine("Did not type a correct number please try again");
            }
        }

    }

    public void ListMedia()
    {
        Console.WriteLine("    1. Books");
        Console.WriteLine("    2. DVDs");
        Console.WriteLine("    3. CDs");
    }

    public void ListEntries()
    {
        Console.Clear();
        Console.WriteLine("Media Entries:");
        if (_eMediaList.Count == 0)
        {
            Console.WriteLine("No Entries have been made at this time.");
            return;
        }

        Console.WriteLine("Books:");
        foreach (var media in _eMediaList)
        {
            if (media is Books)
            {
                Books book = (Books)media;
                string entry = book.GetDetailsString();
 
                Console.WriteLine($"    {entry}");
            }
        }
        Console.WriteLine("CDs:");
        foreach (var media in _eMediaList)
        {
            if (media is CD)
            {
                CD cd = (CD)media;
                string entry = cd.GetDetailsString();
                Console.WriteLine($"    {entry}");
            }
        }
        Console.WriteLine("DVDs:");
        foreach (var media in _eMediaList)
        {
            if (media is DVD)
            {
                DVD dvd = (DVD)media;
                string entry = dvd.GetDetailsString();
                Console.WriteLine($"    {entry}");
            }
        }

    }
}

    // public void Filter()
    // {
    // int userChoice;

    // Console.WriteLine("    1.Media");
    // Console.WriteLine("    2.Title");
    // Console.WriteLine("    3.Rating");
    // Console.Write("What would you like to filter by? (Type: 1, 2 or 3) ");
    // string filterType = Console.ReadLine();

    // if (int.TryParse(filterType, out userChoice))
    // {
    //     Filter filter = new Filter(_eMediaList);
    //     if (userChoice == 1) // Media
    //     {
    //         Console.WriteLine("Media Types:");
    //         ListMedia();
    //         Console.Write("What media would you like to filter by? (EX: Books) ");
    //         string desiredFilter = Console.ReadLine();
    //         FilteredList = filter.FilterByPropertyValue(0, desiredFilter);
    //     }
    //     else if (userChoice == 2) // Title
    //     {
    //         Console.Write("Enter the desired title to filter by: ");
    //         string desiredTitle = Console.ReadLine();
    //         FilteredList = filter.FilterByPropertyValue(1, desiredTitle);
    //     }
    //     else if (userChoice == 3) // Rating
    //     {
    //         int desiredRating;
    //         Console.Write("Enter the desired Rating to filter by: ");
    //         string desiredRatingInput = Console.ReadLine();
    //         if (int.TryParse(desiredRatingInput, out desiredRating))
    //         {
    //             FilteredList = filter.FilterByPropertyValue(3, desiredRating.ToString());
    //         }
    //         else
    //         {
    //             Console.WriteLine("Invalid input for rating. Please enter a valid integer.");
    //             return;
    //         }
    //     }
    //     if (FilteredList != null)
    //     {
    //         // Output filtered list
    //         Console.WriteLine();
    //         Console.WriteLine("Filtered list:");
    //         foreach (var media in FilteredList)
    //         {
    //             Console.WriteLine(media.GetStringRepresentation());
    //         }
    //     }        
    //     else
    //     {
    //         Console.WriteLine("Could not Find anything that fit your filter. Try again!");
    //     }
