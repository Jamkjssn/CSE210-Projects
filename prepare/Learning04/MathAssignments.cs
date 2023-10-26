public class MathAssignments : Assignment
{
private string _textbookSection {get; set;}
private string _problems { get; set; }   
public MathAssignments(string section, string problems, string name, string topic) : base(name, topic)
{
    _textbookSection = section;
    _problems = problems;
}
public string GetHomeworkList()
{
    return $"Section: {_textbookSection}" + "\t" + $"Problems: {_problems}";
}
}