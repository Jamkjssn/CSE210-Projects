public class ChecklistGoal : Goal
{
    private int _completedParts {get; set;}
    private int _totalParts {get; set;}
    private double _finishPoints {get; set;}
    private double _progressPoints {get; set;}
    public ChecklistGoal(string name, string goalType = "ChecklistGoal") : base(goalType, name) 
    {
        _completedParts = 0;
    }
    public override double CompleteGoal()
    {
        bool numPartsSelect = true;
        int intPartsCompleted = 0;
        while(numPartsSelect)
        {
            Console.WriteLine("How many parts to this goal would you like to report as completed? ");
            string partscompleted = Console.ReadLine();
            try
            {
                intPartsCompleted = int.Parse(partscompleted);
                if(intPartsCompleted < 0 || intPartsCompleted > _totalParts-_completedParts)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter a valid number of Parts\n");
                }
                else
                {
                    numPartsSelect = false;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Enter your selection as a number\n");
            }
        }
        double pointsToAward = 0;
        for(int i = intPartsCompleted; i > 0; i--)
        {
            if (_completedParts+1 == _totalParts)
            {
                _isComplete = true;
                pointsToAward += AwardPoints();
            }
            else
            {
                _completedParts++;
                pointsToAward += AwardPoints();
            }
        }
        return pointsToAward;
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
        Console.WriteLine();
        if (_name != "empty")
        {
            Console.WriteLine($"Goal Name: {_name}");
        }
        Console.WriteLine($"Goal: {_description}");
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