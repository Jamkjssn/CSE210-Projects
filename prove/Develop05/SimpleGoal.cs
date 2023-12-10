using System.Reflection;
using System.Text;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string goalType = "SimpleGoal") : base(name, goalType) {}
    public override double AwardPoints() //Points awarded upon completion
    {
        double weight = (_difficultyRating + _importanceRating + _importanceRating)/3;
        double pointsToAward = -165 + Math.Pow(1.155, weight + 39); 
        //For the math equation above, weight 0 = 110, weight 5 = 402, weight 10 = 1000
        //To see it visualized open desmos graphing calculator and past this in: 1.155^{\left(x+39\right)}-165
        return pointsToAward;
    }
    public override double CompleteGoal()
    {
        _isComplete = true;
        return AwardPoints();
    }
    public override void DesplayGoal()
    {
        Console.WriteLine();
        if (_name != "empty")
        {
            Console.WriteLine($"Goal Name: {_name}");
        }
        if (_isComplete)
        {
            Console.WriteLine($"Goal: {_description}\t(This goal has been completed)");
        }
        Console.WriteLine($"Goal: {_description}");
    }
    public override int EditGoal()
    {
        int selection = base.EditGoal();
        if(selection == 5)
        {
            Console.WriteLine("Since this is a simple goal there are no other things thac can be edited.");
        }
        return 0;
    }
}