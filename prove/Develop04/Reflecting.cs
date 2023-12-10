public class Reflecting : Activity
{
    private List<string> _questions { get; set; }
    private Random _random = new();
    public Reflecting(string description, string activity = "Reflecting Activity") : base(description, activity)
    {
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
        _prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
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