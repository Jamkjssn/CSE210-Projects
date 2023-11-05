using System.Dynamic;

public class Listing : Activity
{   
    private List<string> _userlist { get; set;}
    public Listing(string description, List<string> prompts, string activity = "Listing Activity") : base(description, activity, prompts)
    {
        _userlist = new List<string>();

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