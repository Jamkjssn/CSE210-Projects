public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string goalType = "simplegoal") : base(goalType, name)
    {

    }
    public override void Setgoal(string description, int importanceRating, int difficultyRating)
    {
        _description = description; //Set the values to what was provided by the user
        _importanceRating = importanceRating;
        _difficultyRating = difficultyRating;
        //Before calling this get the info you need to set the goal
    }
}