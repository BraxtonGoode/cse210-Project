using System;

class Program
{

    static void Main(string[] args)
    {
        Displaywelcome();
        string userName = Promptusername();
        int userNumber = Promptusernumber();
        int squaredNumber = Squarenumber(userNumber);
        Displayresult(userName,squaredNumber);
    }
    static void Displaywelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string Promptusername()
    {
        Console.WriteLine("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int Promptusernumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static int Squarenumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void Displayresult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}