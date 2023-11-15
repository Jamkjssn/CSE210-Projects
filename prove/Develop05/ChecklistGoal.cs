public class ChecklistGoal : Goal
{
    private int _completedParts;
    private int _totalParts;
    public ChecklistGoal(string name, string goalType = "ChecklistGoal") : base(goalType, name) {}
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
    
}