//Student class example
using System.Reflection;
using System.Text;


public class Student
{
    private string _FirstName { get; set; }
    public string LastName { get; set; }
    public string Major { get; set; }
    public float GPA {get; set;}

    // private string _firstName;
    // private string _lastName;
    // private string _major;
    // private float _gpa;

    public Student() //Constructor, this runs everytime something in the student class is created
    {
        _FirstName = "Jacob";
        LastName = "Ethington";
        Major = "Computers";
        GPA = 4.0f;
        Testing();
    }
    public void Testing()
    {
        PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property}");
        }
    }
    // public string GetStringRepresentation()
    // {
    //     StringBuilder representation = new StringBuilder();
    //     representation.AppendLine("Profile:");

    //     PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    //     foreach (PropertyInfo property in properties)
    //     {
    //         if (property.PropertyType == );
    //         string typeName = property.PropertyType.Name;
    //         object value = property.GetValue(this);

    //         representation.AppendLine($"{typeName}:{value}");
    //     }
    //     return representation.ToString();
    // }
    public string GetType1(object test)
    {
        Type testtype = test.GetType();
        
        return "test";
    }
}

