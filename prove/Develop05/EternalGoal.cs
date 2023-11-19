public class EternalGoal : Goal
{
    private int _timeTable; //How often the goal should be done
    private int _completionStreak; //How many times in a row this goal has been completed
    private double _baseCompletePoints;
    private double _streakMultiplier;
    private List<DateTime> _completions;
    public EternalGoal(string name, string goalType = "EternalGoal") : base(goalType, name) {}
    public void CalculateStreak()//Use timetable and timestamps on completions to calculate streak
    {
        //You need to figure out more about DateTime before you can write this
        //This will also edit streakMultiplier when tis called
    }
    public override void Setgoal(string description, int importanceRating, int difficultyRating) //Initial goal set, determines points as well
    {
        base.Setgoal(description, importanceRating, difficultyRating);
        double weight = (_difficultyRating + _importanceRating + _importanceRating)/3;
        _baseCompletePoints = (-165 + Math.Pow(1.155, weight + 39))*0.1;
        _streakMultiplier = 1;
    }
    public override double CompleteGoal()
    {
        _completions.Add(DateTime.Now);
        return AwardPoints();
    }
    public override double AwardPoints()
    {
        return 1;
    }
}