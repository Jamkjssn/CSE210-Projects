using System.Dynamic;

public class Listing : Activity
{   
    private List<string> _userlist { get; set;}
    public Listing(string description, string activity = "Listing Activity") : base(description, activity)
    {
        _userlist = new List<string>();
        _prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        Listingactivity();
    }
    
    public void Listingactivity()
    {
        //Stuff
        ActivityStart();
        int duration = GetDuration();

        Console.WriteLine("List as many responses as you can to the following prompt: ");
        string prompt = RandomPrompt();
        Console.WriteLine($"\n---{prompt}---\n");

        Console.Write("You may start in: 5");
        Countdown(5);
        GetUserList(duration);
        Console.Clear();
        Console.WriteLine($"You listed {_userlist.Count} items!");
        DesplayFinish();
    }
    public void GetUserList(int duration)
    {
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string listitem = Console.ReadLine();
            _userlist.Add(listitem);
        }
    }
}