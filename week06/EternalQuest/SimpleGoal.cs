public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string type, string name, string description, string points) : base(type, name, description, points)
    {
        
    }
    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        return "";
    }
    public void SetComplete(bool value)
    {
        _isComplete = value;
    }
}