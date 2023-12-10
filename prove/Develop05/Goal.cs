using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;

public class Goal
{
    protected string _goaltype { get; set; }
    protected string _name { get; set; }
    protected string _description { get; set; }
    protected bool _isComplete { get; set; }
    protected double _importanceRating { get; set; }
    protected double _difficultyRating { get; set; }
    // protected DateTime _creationTimestamp { get; set; }
    // protected DateTime _completionTimestamp { get; set; }
    public Goal(string name, string goalType)
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
    public virtual int EditGoal()
    {
        //Editing Goal will be different for each class, but this bit will always be the same.
        bool editingMenu = true;
        int intSelection = 0;
        while (editingMenu)
        {
            Console.WriteLine("Which aspect of this goal would you like to edit?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Importance Rating");
            Console.WriteLine("4. Difficulty Rating");
            Console.WriteLine("5. Other");
            Console.WriteLine("6. Exit");
            string selection = Console.ReadLine();
            try
            {
                intSelection = int.Parse(selection);
                if (intSelection < 1 || intSelection > 6)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number between 1 and 5");
                }
                else
                {
                    editingMenu = false;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Please enter your choice as a number");
            }
        }
        if (intSelection == 1)
        {
            Console.WriteLine("What would you like the new name of your goal to be?");
            string name = Console.ReadLine();
            _name = name;
            Console.WriteLine("The name has successfully been changed");
        }
        else if (intSelection == 2)
        {
            Console.WriteLine("What would you like your goal description to be?");
            string description = Console.ReadLine();
            _description = description;
            Console.WriteLine("The description has successfully been changed");
        }
        else if (intSelection == 3)
        {
            int intImportance = 0;
            bool importance = true;
            while (importance)
            {
                Console.WriteLine("What woudl you like your Importance Rating to be?");
                string stringimportance = Console.ReadLine();
                try
                {
                    intImportance = int.Parse(stringimportance);
                    if (intImportance < 1 || intImportance > 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 10");
                    }
                    else
                    {
                        importance = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your choice as a number");
                }
            }
            Console.WriteLine("Your importance rating has successfully been changed");
        }
        else if (intSelection == 4)
        {
            int intDifficulty = 0;
            bool difficulty = true;
            while (difficulty)
            {
                Console.WriteLine("What would you like your Difficulty Rating to be?");
                string stringdifficulty = Console.ReadLine();
                try
                {
                    intDifficulty = int.Parse(stringdifficulty);
                    if (intDifficulty < 1 || intDifficulty > 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 10");
                    }
                    else
                    {
                        difficulty = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your choice as a number");
                }
            }
            _difficultyRating = intDifficulty;
            Console.WriteLine("Your difficulty rating has successfully been changed.");
        }
        else
        {
            Console.WriteLine("Editing Error");
        }
        return intSelection;
    }
    public virtual void DesplayGoal()
    {
        //Desplaying the goal, this will be called any time the user wants to see their goals
    }
    public string GetStringRepresentationGoal()
    {
        StringBuilder stringRepresentation = new StringBuilder();
        PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        stringRepresentation.Append(_goaltype);

        foreach(PropertyInfo property in properties)
        {
            string propertyName = property.Name;
            object value = property.GetValue(this);
            stringRepresentation.Append($"`{propertyName},{value}");
        }
        return stringRepresentation.ToString();
    }
    public void DeserializeGoal(string goal)
    {
        // Goal is sent in as a string with the formatting:
        // GoalType`GoalProperty`GoalProperty`GoalProperty

        // This method takes that and sets this goals values to those passed in

        string[] propertyList = goal.Split("`");

        bool first = true; //The first thing in the list is the GoalType, which we can ignore
        foreach (string propertystring in propertyList)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                string[] propertyParts = propertystring.Split(",");
                string propertyName = propertyParts[0];
                // PropertyInfo property = this.GetType().GetProperty(propertyParts[0]); 
                PropertyInfo property = this.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
                string value = propertyParts[1];

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
                        Console.WriteLine("An error has occured and the profile will not load correctly");
                    }
                }
                // else if (property.PropertyType == typeof(DateTime))
                // {
                //     try
                //     {
                //         DateTime dateTimeValue = DateTime.Parse(value);
                //         property.SetValue(this, dateTimeValue);
                //     }
                //     catch
                //     {
                //         Console.WriteLine("An error has occured and the profile will not load correctly");
                //     }
                // }
            }
        }
    }
}