using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade?");
        int grade = int.Parse(Console.ReadLine());
        string letter = "";
        string plusOrMinus = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // if (letter == "A" && grade % 10 >= 7 )
        // {
        //     plusOrMinus = "";
        // }
        // else if (letter == "F" && grade % 10 <= 3 )
        // {
        //     plusOrMinus = "";
        // }
        // else if (grade % 10 >= 7)
        // {
        //     plusOrMinus = "+";
        // }
        // else
        // {
        //     plusOrMinus = "-";
        // }

        Console.WriteLine($"your letter grade is {letter}{plusOrMinus}");

        if (grade >= 70 )
        {
            Console.WriteLine("congrats you passed!");
        }
        else 
        {
            Console.WriteLine("Sorry you did not pass the class. better luck next time. ");
        }

    }
}