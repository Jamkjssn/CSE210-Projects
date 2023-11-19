public class ChecklistGoal : Goal
{
    private int _completedParts;
    private int _totalParts;
    public ChecklistGoal(string name, string goalType = "ChecklistGoal") : base(goalType, name) 
    {
        _completedParts = 0;
    }
    public void MakeProgress()
    {
        if (_completedParts+1 == _totalParts)
        {
            CompleteGoal();
        }
        else
        {
            _completedParts++;
        }
    }
    public override void CompleteGoal()
    {
        _isComplete = true;
    }
    public override void Setgoal(string description, int importanceRating, int difficultyRating)
    {
        _description = description;
        _importanceRating = importanceRating;
        _difficultyRating = difficultyRating;
    }
    public void SetParts(int totalParts)
    {
        _totalParts = totalParts;
    }
    public override void DesplayGoal()
    {
        if (_name != "empty")
        {
            Console.WriteLine($"{_name}");
        }
        Console.WriteLine($"{_description}");
        for (int iCompleted = 0; iCompleted <= _completedParts-1; iCompleted++)
        {
            Console.Write("[x]");
        }
        for (int iTotal = 0; iTotal <= _totalParts-_completedParts-1; iTotal++)
        {
            Console.Write("[ ]");
        }
        Console.WriteLine($"\t{_completedParts}/{_totalParts} Completed");
    }
}