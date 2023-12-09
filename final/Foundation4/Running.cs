public class Running : Activity
{
    private double _distance;
    public Running(DateOnly date, int length, double distance) : base(date, length)
    {
        _distance = distance;
        _activityType = "Running";
    }
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        return _distance*60/_length;
    }
    public override double GetPace()
    {
        return _length/_distance;
    }
}