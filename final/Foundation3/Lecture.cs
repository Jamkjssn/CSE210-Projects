public class Lecture : Event
{
    private string _speaker;
    private int _capacity;
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
        _eventType = "Lecture";
    }
    public override string FullDetails()
    {
        string baseDetails = base.FullDetails();
        return $"Lecture\n{baseDetails}\nSpeaker: {_speaker}\nCapacity: {_capacity} People";
    }
}