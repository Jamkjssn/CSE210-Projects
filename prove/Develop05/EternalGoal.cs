using System.Runtime.CompilerServices;

public class EternalGoal : Goal
{
    private string _timeTable {get; set;} //How often the goal should be done
    private double _baseCompletePoints {get; set;}
    private int _numCompletions {get; set;}

    // These would be cool to add in but i dont have the time
    // private int _completionStreak; //How many times in a row this goal has been completed
    // private double _streakMultiplier;
    // private List<DateTime> _completions;
    public EternalGoal(string name, string goalType = "EternalGoal") : base(goalType, name) 
    {
        _numCompletions = 0;
    }
    public override void Setgoal(string description, double importanceRating, double difficultyRating) //Initial goal set, determines points as well
    {
        base.Setgoal(description, importanceRating, difficultyRating);
        double weight = (_difficultyRating + _importanceRating + _importanceRating)/3;
        _baseCompletePoints = (-165 + Math.Pow(1.155, weight + 39))*0.1;
        _baseCompletePoints = Math.Round(_baseCompletePoints);
    }
    public override double CompleteGoal()
    {
        // _completions.Add(DateTime.Now);
        _numCompletions++;
        return AwardPoints();
    }
    public override double AwardPoints()
    {
        return _baseCompletePoints;
    }
    public void SetTimetable(string timetable)
    {
        _timeTable = timetable;
    }
    public override void DesplayGoal()
    {
        Console.WriteLine();
        if (_name != "empty")
        {
            Console.WriteLine($"Goal Name: {_name}");
        }
        Console.WriteLine($"Goal: {_description}");
        Console.WriteLine($"TimeTable: {_timeTable}");
        Console.WriteLine($"You've completed this goal {_numCompletions} times");
    }
}