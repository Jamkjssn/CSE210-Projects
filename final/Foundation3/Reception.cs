public class Reception : Event
{
    private string _contactInfo;
    public Reception(string title, string description, string date, string time, Address address, string contactInfo) : base(title, description, date, time, address)
    {
        _contactInfo = contactInfo;
        _eventType = "Reception";
    }
    public override string FullDetails()
    {
        string baseDetails = base.FullDetails();
        return $"Reception\n{baseDetails}\nRSVP at: {_contactInfo}";
    }
}