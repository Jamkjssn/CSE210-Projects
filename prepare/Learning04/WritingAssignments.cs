public class WritingAssignments : Assignment
{
private string _title { get; set; }
public WritingAssignments(string title, string name, string topic) : base(name, topic)
{
    _title = title;
}
public string GetWritingInformation()
{
    string name = GetStudentName();
    return $"{_title} by {name}";
}
}