//Student class example
public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Major { get; set; }
    public float GPA { get; set; }

    // private string _firstName;
    // private string _lastName;
    // private string _major;
    // private float _gpa;

    public Student() //Constructor, this runs everytime something in the student class is created
    {
        FirstName = "";
    }
    
}