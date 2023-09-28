using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Class Testing!");

        Job job1 = new()
        {
            JobTitle = "Engineer",
            Company = "Microsoft",
            StartYear = 2000,
            EndYear = 2021
        };

        Job job2 = new()
        {
            JobTitle = "Programmer",
            Company = "Apple",
            StartYear = 1984,
            EndYear = 2000
        };

        Resume resume1 = new()
        {
            Name = "Jerry Smith"
        };

        resume1.Jobs.Add(job1);
        resume1.Jobs.Add(job2);
        resume1.Display();

    }
}