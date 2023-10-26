public class Assignment
{
private string _studentName { get; set; }
private string _topic {get; set; }
public Assignment(string name, string topic)
{
    _studentName = name;
    _topic = topic;
}
public string GetSummary()
{
    return $"Name: {_studentName}" + "\t" + $"Topic: {_topic}";
}
public string GetStudentName()
{
    return _studentName;
}

}