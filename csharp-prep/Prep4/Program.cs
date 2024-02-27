using System;
using System.Collections.Generic;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbersList = new List<int>();
        int number; 
        do
        {
            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if(number != 0)
            {
                numbersList.Add(number);
            }            
            

        } while (number != 0);

        int sum = 0;
        foreach (int num in numbersList)
        {
            sum = sum + num;
        }
        Console.WriteLine($"The sum is : {sum}");
        int average = sum / numbersList.Count;
        Console.WriteLine($"The average is : {average}");
        int largest = 0;
        foreach(int num in numbersList)
        {
            if (num > largest)
            {
                largest = num;
            } 
        }
        Console.WriteLine($"The largest number is : {largest}");
    }
}