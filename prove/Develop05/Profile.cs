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
        Console.WriteLine("\nWould you also like to view past completed goals? (y/n) ");
        string viewcompleted = Console.ReadLine().ToLower();
        if (viewcompleted == "y")
        {
            foreach(Goal goal in _completedgoals)
            {
                goal.DesplayGoal();
            }
        }
        Console.WriteLine("\nPress \"Enter\" when you're ready to return to the Main Menu");
        while (Console.ReadKey().Key != ConsoleKey.Enter){}
        Console.Clear();
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
    // I'd try and explain this better but it took ages to figure out. This saves the profile to a txt in the following format
    // propertyName:propertyValue


    // In the case of the lists of goals the format is as follows
    // propertyName:propertyValue:Goals

    // The goals are organized with this format
    // :Goal~Goal~Goal
    
    // Individual goals are as follows
    // GoalType`GoalProperty`GoalProperty`GoalProperty

    // And Finally the goal properties are organized in the following format
    // propertyName,propertyValue


    StringBuilder representation = new StringBuilder();
    representation.AppendLine("Profile:");

    PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    foreach (PropertyInfo property in properties)
    {

        string propertyName = property.Name;
        object value = property.GetValue(this);

        if (value is List<Goal>)
        {
            List<Goal> goals = (List<Goal>)value;
            representation.Append($"{propertyName}:{value}:");
            bool firstGoal = true;
            foreach(Goal goal in goals)
            {
                if (firstGoal) // This will make sure the first goal doesn't add the ~ before the seperations start
                {
                    firstGoal = false;
                }
                else
                {
                    representation.Append("~");
                }
                representation.Append(goal.GetStringRepresentationGoal());
                if (goals.Count == 0)
                {
                    representation.Append("empty");
                }
            }
            representation.AppendLine();
        }
        else
        {
        representation.AppendLine($"{propertyName}:{value}");
        }
    }

    return representation.ToString();
    }
    public bool CreateSavedProfile(string username)
    {
        _username = username;
                
        // string[] textstuff = { "It is working" };
        // File.WriteAllLines($"{username}.txt", textstuff);
        string filename = $"{username}.txt";
        if (!File.Exists(filename)) //Check if the file exists, if not, return false
        {
            return false; 
        }
        try
        {
        string[] lines = System.IO.File.ReadAllLines(filename);
        lines = lines.Skip(1).ToArray();
        // string[] lines = serializedData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Splits data by lines

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');

            if (parts.Length == 2) // This is for the simple properties
            {
                PropertyInfo property = this.GetType().GetProperty(parts[0]);
                string value = parts[1];
                this.SetPropertyValue(property, value);
            }
            if (parts.Length > 2 && parts[2] != "") // This only runs in the case of the Lists objects
            {
                string propertyName = parts[0];
                PropertyInfo property = this.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
                List<Goal> goalsList = new();
                string[] goalList = parts[2].Split("~"); //Split the goals up
                foreach(string goal in goalList)
                {
                    string[] goalProperties = goal.Split("`"); // This splits that goal into its properties
                    string goalName = goalProperties[2].Split(",")[1]; // This cuts through to the name of the goal for initialization

                    if (goalProperties[0] == "SimpleGoal") // This will initialize each goal as their type and add them to the list
                    {
                        SimpleGoal newGoal = new(goalName);
                        newGoal.DeserializeGoal(goal);
                        goalsList.Add(newGoal);
                    }
                    else if (goalProperties[0] == "ChecklistGoal")
                    {
                        ChecklistGoal newGoal = new(goalName);
                        newGoal.DeserializeGoal(goal);
                        goalsList.Add(newGoal);
                    }
                    else if (goalProperties[0] == "EternalGoal")
                    {
                        EternalGoal newGoal = new(goalName);
                        newGoal.DeserializeGoal(goal);
                        goalsList.Add(newGoal);
                    }
                }
                property.SetValue(this, goalsList); // Set the value to the list we've put together
            }
        }
        return true; // If you make it all the way through return true.
        }
        catch
        {
            Console.WriteLine("There was an error while loading your profile.");
            return false;
        }
    }
    public void SetPropertyValue(PropertyInfo property, string value)
    {
        // This method converts the value back to its origional type and then sets it. 

        if (property != null)
        {
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(this, value);
            }
            else if (property.PropertyType == typeof(int))
            {
                try
                {
                    int intValue = int.Parse(value);
                    property.SetValue(this, intValue);
                }
                catch
                {
                    Console.WriteLine("An error has occured and the profile will not load correctly");
                }
            }
            else if (property.PropertyType == typeof(double))
            {
                try
                {
                    double doubleValue = double.Parse(value);
                    property.SetValue(this, doubleValue);
                }
                catch
                {
                    Console.WriteLine("An error has occured and the profile will not load correctly");
                }
            }
            else if (property.PropertyType == typeof(bool))
            {
                try
                {
                    bool boolValue = bool.Parse(value);
                    property.SetValue(this, boolValue);
                }
                catch
                {
                    Console.WriteLine("An error has occured and the profil will not load correctly");
                }
            }
        }
    }
}