public class Breathing : Activity
{
    private int _remainingDuration { get; set; }
    public Breathing(string description, string activity = "Breathing Activity") : base(description, activity)
    {
        Breath();
    }
    public void Breath()
    {
        ActivityStart();
        _remainingDuration = GetDuration();
        bool breaths = true;
        while (_remainingDuration > 0)
        {
            breaths = EachBreath(breaths);
            _remainingDuration  -= 3;
            breaths = EachBreath(breaths);
            _remainingDuration -= 5;
        }
        DesplayFinish();
    }
    public bool EachBreath(bool InBreath)
    {
        if(InBreath)
        {
            //Breath in
            Console.Write("Breath in ...3");
            Countdown(3);
            Console.WriteLine("");
        }
        else
        {
            //Breath out
            Console.Write("Now breath out ...5");
            Countdown(5);
            Console.WriteLine("\n\n");
        }
        return !InBreath;
    }
}