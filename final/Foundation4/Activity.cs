public class Activity
{
    private DateOnly _date;
    protected int _length;
    protected string _activityType;
    public Activity(DateOnly date, int length)
    {
        _date = date;
        _length = length;
    }
    public virtual double GetDistance()
    {
        return -1;
    }
    public virtual double GetSpeed()
    {
        return -1;
    }
    public virtual double GetPace()
    {
        return -1;
    }
    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return $"{_date} {_activityType} ({_length} min): Distance {distance:F2} Miles, Speed {speed:F2} mph, Pace: {pace:F2} min per mile.";
    }
}