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
    public virtual double CompleteGoal()
    {
        //Polymorphism method. This will be different in inherited classes.
        return AwardPoints();
    }
    public virtual double AwardPoints()
    {
        //Polymorphism method. This will be different in inherited classes.
        return -1;
    }
    public virtual void Setgoal(string description, double importanceRating, double difficultyRating)
    {
        _description = description; //Set the values to what was provided by the user
        _importanceRating = importanceRating;
        _difficultyRating = difficultyRating;
        //Before calling this get the info you need to set the goal
    }
    public virtual void DesplayGoal()
    {
        //Desplaying the goal, this will be called any time the user wants to see their goals
    }
}