using System.Globalization;

public class Activity
{
    private string _description { get; set; }
    protected List<string> _prompts { get; set; }
    private int _duration { get; set; }
    private List<string> _animation = new(){"|","/","-","\\"};
    private string _activitytype;
    private Random _random = new();
    public Activity(string description, string activitytype)
    {
        //Constructor
        _description = description;
        _activitytype = activitytype;
    }
    public void Pause(int length)
    {
        //Enter how many seconds you want to pause

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(length);
        int index = 0;
        while(DateTime.Now < end)
        {
            string symbol = _animation[index % 4];
            Console.Write(symbol);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
        Console.WriteLine("");
    }
    public void Countdown(int time)
    {
        // Time is how long you put on the initial message to the user,
        // this method will erase the last character and replace it with the next number counting down.
        Thread.Sleep(1000);
        for (int number = time-1; number >= 0; number--)
        {
            Console.Write($"\b{number}");
            Thread.Sleep(1000);
        }
        Console.Write("\b");
        Console.WriteLine("");
    }
    public void ActivityStart()
    {
        Console.WriteLine(_description);
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        string duration = Console.ReadLine();
        _duration = int.Parse(duration);
        Console.Clear();
        Console.WriteLine("Get Ready ...");
        Pause(5);
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void DesplayFinish()
    {
        Console.WriteLine("Well Done!");
        Pause(3);
        Console.Clear();
        Console.WriteLine($"\n You've completed another {_duration} seconds of {_activitytype}!");
        Pause(5);
    }
    public string RandomPrompt()
    {
        int randompromptindex = _random.Next(0, _prompts.Count);
        return _prompts[randompromptindex];
    }
}