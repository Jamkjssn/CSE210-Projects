public class OutdoorGathering : Event
{
    private string _weather;
    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
        _eventType = "Outdoor Gathering";
    }
    public override string FullDetails()
    {
        string baseDetails = base.FullDetails();
        return $"{baseDetails}\nWill be held outdoors\nExpected Weather: {_weather}";
    }

}