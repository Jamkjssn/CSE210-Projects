public class Swimming : Activity
{
    private int _laps;
    public Swimming(DateOnly date, int length, int laps) : base(date, length)
    {
        _laps = laps;
        _activityType = "Swimming";
    }
    public override double GetDistance()
    {
        return _laps*50/1000*0.62;
    }
    public override double GetSpeed()
    {
        return GetDistance()/_length*60;
    }
    public override double GetPace()
    {
        return 60/GetSpeed();
    }
}