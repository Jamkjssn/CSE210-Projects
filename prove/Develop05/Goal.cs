using System.ComponentModel;
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
    public virtual void EditGoal()
    {
        //Editing Goal will be different for each class, base represents the simple goal
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