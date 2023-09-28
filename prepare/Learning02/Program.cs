using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Class Testing!");

        Job job1 = new Job();
        job1.JobTitle = "Engineer";
        job1.Company =  "Microsoft";
        job1.StartYear = 2000;
        job1.EndYear = 2021;

        Job job2 = new();
        job2.JobTitle = "Programmer";
        job2.Company = "Apple";
        job2.StartYear = 1984;
        job2.EndYear = 2000;
        
        Resume resume1 = new();
        resume1.Name = "Jerry";
        resume1.Jobs.Add(job1);
        resume1.Jobs.Add(job2);

        resume1.Display();

    }
}