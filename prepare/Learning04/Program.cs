using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning04 World!");

        // Assignment task1 = new Assignment("Braxton Goode", "Math");
        // Console.WriteLine(task1.GetSummary());

        // MathAssignment math1 = new MathAssignment("Braxton Goode", "Fractions", "7.3", "8-19");
        // Console.WriteLine(math1.GetSummary());
        // Console.WriteLine(math1.GetHomeworkList());

        WritingAssignment writing1 = new WritingAssignment("Braxton Goode", "European History", "The Causes of World War II");
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInformation());

    }
}