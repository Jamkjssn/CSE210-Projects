public class Profile
{
    private string _username;
    private string _rankAdjective;
    private string _rankTitle;
    private int _experiencePoints;
    private int _goalsCompleted;
    private int _goalsSet;
    private double _goalCompletionRatio;
    private int _loginstreak;
    private List<Goal> _currentgoals;
    private List<Goal> _completedgoals;
    private bool _autosave;
    public Profile(string name)
    {
        _username = name;
        _rankAdjective = "Placeholder";
        _rankTitle = "placeholder";
        _experiencePoints = 0;
        _goalsCompleted = 0;
        _goalsSet = 0;
        _goalCompletionRatio = 1;
        _loginstreak = 0;
        _currentgoals = new();
        _autosave = true;
    }
    public void CalculateCompletionRatio() //Recalculate _goalCompletionRatio
    {
        if (_goalsSet > 0)
        {
            _goalCompletionRatio = _goalsCompleted/_goalsSet;
        }
        else
        {
            _goalCompletionRatio = 1;
        }
    }
    public void AddGoalCompleted() //Add 1 to _goalsCompleted
    {
        _goalsCompleted++;
    }
    public void AddGoalSet() // Add 1 to _goalsSet
    {
        _goalsSet++;
    }
    public void CheckLoginStreak()  //This one is a bit more complicated, so we'll wait to create it.
    {

    }
    public void ChangeUsername(string newusername) //Change the profile Username
    {
        //I still need to figure out how this will work with the file being saved to
        _username = newusername;
    }
    public void DisplayGoals() //Display the users goals
    {

    }
    public bool GetAutosave() //Get value of Autosave
    {
        return _autosave;
    }
    public void ToggleAutosave() //Flip Autosave bool
    {
        _autosave = !_autosave;
    }
}