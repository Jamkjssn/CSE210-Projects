public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string goalType = "SimpleGoal") : base(goalType, name) {}
    public override void Setgoal(string description, int importanceRating, int difficultyRating)
    {
        _description = description; //Set the values to what was provided by the user
        _importanceRating = importanceRating;
        _difficultyRating = difficultyRating;
        //Before calling this get the info you need to set the goal
    }
    public override double AwardPoints() //Points awarded upon completion
    {
        double weight = (_difficultyRating + _importanceRating + _importanceRating)/3;
        double pointsToAward = -165 + Math.Pow(1.155, weight + 39); 
        //For the math equation above, weight 0 = 110, weight 5 = 402, weight 10 = 1000
        //To see it visualized open desmos graphing calculator and past this in: 1.155^{\left(x+39\right)}-165
        return pointsToAward;
    }
    public override void CompleteGoal()
    {
        _isComplete = true;
    }
    public override void DesplayGoal()
    {
        if (_name != "empty")
        {
            Console.WriteLine($"{_name}");
        }
        if (_isComplete)
        {
            Console.WriteLine($"{_description}\t(This goal has been completed)");
        }
        else
        {
        Console.WriteLine($"{_description}");
        }
    }
}