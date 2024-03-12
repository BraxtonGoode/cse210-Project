using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        //Fraction fraction = new Fraction();        
        //Fraction whole = new Fraction(1);        
        Fraction topandBottom = new Fraction(1,3);

        Console.WriteLine(topandBottom.GetFractionString());
        Console.WriteLine(topandBottom.GetDeciamlValue());
    }
}