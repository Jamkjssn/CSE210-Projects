public class Cycling : Activity
{
    private double _speed;
    public Cycling(DateOnly date, int length, double speed) : base(date, length)
    {
        _speed = speed;
        _activityType = "Cycling";
    }
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetDistance()
    {
        return _speed*_length/60;
    }
    public override double GetPace()
    {
        return 60/_speed;
    }
}