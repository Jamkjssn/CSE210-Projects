public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;
    protected string _eventType;
    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
    public string StandardDetails()
    {
        return $"\n\t{_title}\n{_description}\nOn:{_date} at {_time}\nAddress: {_address.GetFullAddress()}";
    }
    public virtual string FullDetails()
    {
        return $"\t\t{_title}\n\n{_description}\n\nOn:{_date} at {_time}\nAddress: {_address.GetFullAddress()}";
    }
    public virtual string ShortDetails()
    {
        return $"{_eventType}\n{_title}\n{_date}";
    }
}