using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("John", "Geology");
        string summary0 = assignment.GetSummary();
        Console.WriteLine(summary0 + "\n");

        MathAssignments mathAssignment = new("7.3", "12-23", "George", "Calculus");
        string summary1 = mathAssignment.GetSummary();
        string homework = mathAssignment.GetHomeworkList();
        Console.WriteLine(summary1 + "\n" + homework + "\n");

        WritingAssignments writingAssignment = new("The Way of Kings", "Brandon", "Creative Writing");
        string summary2 = writingAssignment.GetSummary();
        string writing = writingAssignment.GetWritingInformation();
        Console.WriteLine(summary2 + "\n" + writing);

    }
}