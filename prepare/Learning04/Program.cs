using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Kaitlyn Johnson", "Addition");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Bryce Miguel", "Fractions", "4.5", "1-3");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WriteAssignment a3 = new WriteAssignment("Lord Hamlet", "World History", "WWII");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
