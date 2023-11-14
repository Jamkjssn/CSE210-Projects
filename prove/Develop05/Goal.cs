using System.ComponentModel;

public class Goal
{
    protected string _goaltype;
    protected string _name; //Make giving the goal a name optional?
    protected string _description;
    protected bool _isComplete;
    protected double _importanceRating;
    protected double _difficultyRating;
    public Goal(string goalType, string name)
    {
        _goaltype = goalType;
        _name = name;
    }
    public virtual void CompleteGoal()
    {
        //Polymorphism method. This will be different in inherited classes.
    }
    public virtual void AwardPoint()
    {
        //Polymorphism method. This will be different in inherited classes.
    }
    public virtual void Setgoal(string description, int importanceRating, int difficultyRating)
    {
        //Setting the goal will be different for each goal type. 
    }
}