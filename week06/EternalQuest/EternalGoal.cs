public class EternalGoal : Goal
{
    public EternalGoal(string type, string name, string description, string points) : base(type, name, description, points)
    {
        
    }

    public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        return "";
    }
}