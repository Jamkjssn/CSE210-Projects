public class Profile
{
    private string _username;
    private string _rankAdjective;
    private string _rankTitle;
    private int _experiencePoints;
    private int _lifetimeExperiencePoints;
    private int _goalsCompleted;
    private int _goalsSet;
    private double _goalCompletionRatio;
    private int _loginStreak;
    private int _longestLoginStreak;
    private List<Goal> _currentgoals;
    private List<Goal> _completedgoals;
    private bool _autosave;
    public Profile(string name)
    {
        _username = name;
        _rankAdjective = "Placeholder";
        _rankTitle = "placeholder";
        _experiencePoints = 0;
        _lifetimeExperiencePoints = 0;
        _goalsCompleted = 0;
        _goalsSet = 0;
        _goalCompletionRatio = 1;
        _loginStreak = 0;
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
    public void CheckLoginStreak()  // This one is a bit more complicated, so we'll wait to create it.
    {
        // Use starting up the program to log their logins and save it in the profile class maybe?
        // Every time you increase the login streak also check to see if it's the new longest streak. 
    }
    public void ChangeUsername(string newusername) //Change the profile Username
    {
        //I still need to figure out how this will work with the file being saved to
        _username = newusername;
    }
    public void DisplayGoals() //Display the users goals
    {
        foreach(Goal goal in _currentgoals)
        {
            goal.DesplayGoal();
        }
        Console.WriteLine("Would you also like to view past completed goals? (y/n) ");
        string viewcompleted = Console.ReadLine();
        if (viewcompleted == "y")
        {
            foreach(Goal goal in _completedgoals)
            {
                goal.DesplayGoal();
            }
        }
        Console.WriteLine("Press \"Enter\" when you're ready to return to the Main Menu");
        while (Console.ReadKey().Key != ConsoleKey.Enter){}
    }
    public bool GetAutosave() //Get value of Autosave
    {
        return _autosave;
    }
    public void ToggleAutosave() //Flip Autosave bool
    {
        _autosave = !_autosave;
    }
    public void DisplayProfile() //Display profile information to the user
    {
        Console.WriteLine($"\t\t{_username}s Profile:");
        Console.WriteLine($"Rank: {_rankAdjective} {_rankTitle}");
        Console.WriteLine($"Current Points: {_experiencePoints}");
        Console.WriteLine($"Total Points: {_lifetimeExperiencePoints}");
        Console.WriteLine($"Goals Set: {_goalsSet}");
        Console.WriteLine($"Goals Completed:{_goalsCompleted}");
        Console.WriteLine($"Goal Completion Ratio: {_goalCompletionRatio}");
        Console.WriteLine($"Current Login Streak: {_loginStreak}");
        Console.WriteLine($"Longest Login Streak: {_longestLoginStreak}");
    }
}