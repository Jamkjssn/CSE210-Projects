public class EternalGoal : Goal
{
    private int _timeTable; //How often the goal should be done
    private int _completionStreak; //How many times in a row this goal has been completed
    private List<DateTime> _completions;
    public EternalGoal(string name, string goalType = "EternalGoal") : base(goalType, name) {}
    public void CalculateStreak()//Use timetable and timestamps on completions to calculate streak
    {
        //You need to figure out more about DateTime before you can write this
    }
}