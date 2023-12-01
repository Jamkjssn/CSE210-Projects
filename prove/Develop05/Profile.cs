using System.Reflection.Metadata;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
public class Profile
{
    private string _username { get; set; }
    private string _rankAdjective { get; set; }
    private string _rankTitle { get; set; }
    private int _experiencePoints { get; set; }
    private int _lifetimeExperiencePoints { get; set; }
    private int _goalsCompleted { get; set; }
    private int _goalsSet { get; set; }
    private double _goalCompletionRatio { get; set; }
    private int _loginStreak { get; set; }
    private int _longestLoginStreak { get; set; }
    private List<Goal> _currentgoals { get; set; }
    private List<Goal> _completedgoals { get; set; }
    private bool _autosave { get; set; }
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
        _longestLoginStreak = 0;
        _currentgoals = new();
        _completedgoals = new();
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
    public void AddGoalSet(Goal goal) // Add 1 to _goalsSet
    {
        _goalsSet++;
        _currentgoals.Add(goal);
    }
    public void CheckLoginStreak()  // This one is a bit more complicated, so we'll wait to create it.
    {
        // Use starting up the program to log their logins and save it in the profile class maybe?
        // Every time you increase the login streak also check to see if it's the new longest streak. 
    }
    public void ChangeUsername(string newusername) //Change the profile Username
    {
        //I still need to figure out how this will work with the file being saved to
        string oldfileName = $"{_username}.dat";
        string newfileName = $"{newusername}.dat";
        _username = newusername;
        if (File.Exists(oldfileName))
        {
            File.Move(oldfileName, newfileName);
        }
        Console.WriteLine($"Your username has successfully been changed to {_username}");
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
        Console.WriteLine($"\t\t{_username}s Profile:\n");
        Console.WriteLine($"Rank:\t {_rankAdjective} {_rankTitle}");
        Console.WriteLine($"Current Points:\t\t {_experiencePoints}");
        Console.WriteLine($"Total Points:\t\t {_lifetimeExperiencePoints}");
        Console.WriteLine($"Goals Set:\t\t {_goalsSet}");
        Console.WriteLine($"Goals Completed:\t {_goalsCompleted}");
        Console.WriteLine($"Goal Completion Ratio:\t {_goalCompletionRatio}");
        Console.WriteLine($"Current Login Streak:\t {_loginStreak}");
        Console.WriteLine($"Longest Login Streak:\t {_longestLoginStreak}");
        Console.WriteLine("Press \"Enter\" when you're ready to return to the Main Menu");
        while (Console.ReadKey().Key != ConsoleKey.Enter){}
    }   
    public void SaveProfile() // Save the current Profile and Goals
    {
    string fileName = $"{_username}.txt"; // Set filename with username
    string profileData = GetStringRepresentation(); // Get string representation
    using (StreamWriter outputFile = new StreamWriter(fileName)) // Write file
        {
            outputFile.WriteLine($"{profileData}");
        }
    }

public string GetStringRepresentation()
{
    StringBuilder representation = new StringBuilder();
    representation.AppendLine("Profile:");

    PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    foreach (PropertyInfo property in properties)
    {
        if (property.PropertyType == (List<>));
        string typeName = property.PropertyType.Name;
        object value = property.GetValue(this);

        representation.AppendLine($"{typeName}:{value}");
    }

    return representation.ToString();
}
    public bool LoadProfile(string username) //Load a profile and goals from a file
    {
        return false;
        // _username = username;
        // string fileName = $"{_username}.dat";
        // if (File.Exists(fileName))
        // {
        //     using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
        //     {
        //         BinaryFormatter binaryFormatter = new BinaryFormatter();

        //         // Get all properties of the class using reflection
        //         PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        //         // Deserialize and set each property value from the file
        //         foreach (PropertyInfo property in properties)
        //         {
        //             object deserializedValue = binaryFormatter.Deserialize(fileStream);
        //             property.SetValue(this, deserializedValue);
        //         }
        //     }
        //     return true;
        // }
        // else
        // {
        //     Console.WriteLine("No save file for that username was found.");
        //     return false;
        // }
    }
}