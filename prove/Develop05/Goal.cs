using System.ComponentModel;

public class Goal
{
    protected string _goaltype;
    protected string _name; //Make giving the goal a name optional?
    protected string _description;
    protected bool _isComplete;
    protected double _importanceRating;
    protected double _difficultyRating;
    protected DateTime _creationTimestamp;
    protected DateTime _completionTimestamp;
    public Goal(string goalType, string name)
    {
        _goaltype = goalType;
        _name = name;
        _isComplete = false;
    }
    public virtual void CompleteGoal()
    {
        //Polymorphism method. This will be different in inherited classes.
    }
    public virtual double AwardPoint()
    {
        //Polymorphism method. This will be different in inherited classes.
        return -1;
    }
    public virtual void Setgoal(string description, int importanceRating, int difficultyRating)
    {
        //Setting the goal will be different for each goal type. 
    }
}