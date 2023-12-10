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
        if(_completedParts == _totalParts && intPartsCompleted == 0)
        {
            _isComplete = true;
            pointsToAward += AwardPoints();
        }
        for(int i = intPartsCompleted; i > 0; i--)
        {
            if (_completedParts+1 == _totalParts)
            {
                _isComplete = true;
                _completedParts++;
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
        _finishPoints = Math.Round(_finishPoints, 2); 
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
    public override int EditGoal()
    {
        int selection = base.EditGoal();
        if (selection == 5)
        {
            Console.WriteLine("Since this is a Checklist Goal the only other thing to edit is the number of parts");
            Console.WriteLine("Would you like to edit this? (yes/no)");
            string answer = Console.ReadLine();
            if(answer.ToLower() == "yes")
            {
                bool finished = false;
                while(!finished)
                {
                    Console.WriteLine("What would you like the new number of parts to be?");
                    string numParts = Console.ReadLine();
                    try
                    {
                        int intParts = int.Parse(numParts);
                        if(intParts < _completedParts)
                        {
                            Console.WriteLine("Your goal doesn't have that many parts left to complete");
                        }
                        else if(intParts == _completedParts)
                        {
                            Console.WriteLine("Since you've subtracted the exact amount of parts left to do, your goal is complete!");
                            Console.WriteLine("Go to report goal progress and report a completion of 0 parts to claim your points and mark this goal as finished");
                            _totalParts = intParts;
                            finished = true;
                        }
                        else
                        {
                            _totalParts = intParts;
                            Console.WriteLine($"Your goal is now comprised of {intParts} parts");
                            finished = true;
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your number of parts as a number");
                    }
                }
            }
        }
        return 0;
    }
}