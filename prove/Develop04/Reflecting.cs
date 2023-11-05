public class Reflecting : Activity
{
    private List<string> _questions { get; set; }
    private Random _random = new();
    public Reflecting(string description, List<string>prompts, string activity = "Reflecting Activity") : base(description, activity, prompts)
    {
        _questions = new List<string>
        {
            "Placeholder",
            "Another Placeholder"
        };
        Reflect();
    }
    public void Reflect()
    {
        //Main method for reflection
        ActivityStart();
        int duration = GetDuration();
        DesplayPrompt();
        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may start in: 5");
        Countdown(5);
        Console.Clear();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            DesplayQuestion();
            Pause(15);
        }
        DesplayFinish();
    }
    public void DesplayPrompt()
    {
        string prompt = RandomPrompt();
        Console.WriteLine("Consider the following prompt");
        Console.WriteLine($"\n---{prompt}---\n");
        Console.WriteLine("When you have something in mind press enter to continue.");
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {}
    }
    public void DesplayQuestion()
    {
        int randomindex = _random.Next(0, _questions.Count-1);
        Console.WriteLine(_questions[randomindex]);
    }
}