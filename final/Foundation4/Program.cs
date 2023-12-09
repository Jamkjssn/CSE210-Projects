using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Foundation 4: Activity Stats\n");

        DateOnly date = new(2023, 12, 8);
        DateOnly tomorrow = new(2023, 12, 9);
        DateOnly yesterday = new(2023, 12, 7);

        Running running = new(date, 15, 12);
        Cycling cycling = new(tomorrow, 175, 14);
        Swimming swimming = new(yesterday, 20, 20);

        List<Activity> activities = new()
        {
            running,
            cycling,
            swimming
        };

        foreach(Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine();
    }
}