public class ChecklistGoal : Goal
{
    private int _completedParts;
    private int _totalParts;
    private double _finishPoints;
    private double _progressPoints;
    public ChecklistGoal(string name, string goalType = "ChecklistGoal") : base(goalType, name) 
    {
        _completedParts = 0;
    }
    public override double CompleteGoal()
    {
        if (_completedParts+1 == _totalParts)
        {
            _isComplete = true;
        }
        else
        {
            _completedParts++;
        }
        return AwardPoints();
    }
    public override void Setgoal(string description, double importanceRating, double difficultyRating)
    {
        _description = description;
        _importanceRating = importanceRating;
        _difficultyRating = difficultyRating;
        double weight = (_difficultyRating + _importanceRating + _importanceRating)/3;
        _finishPoints = (-165 + Math.Pow(1.155, weight + 39))*0.5; 
        _progressPoints = _finishPoints/4;
    }
    public void SetParts(int totalParts)
    {
        _totalParts = totalParts;
    }
    public override double AwardPoints()
    {
        if (_isComplete)
        {
            return _finishPoints;
        }
        else
        {
            return _progressPoints;
        }
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