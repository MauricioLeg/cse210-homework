public class Goal
{
    private string _shortName;
    private string _description;
    private string _points;
    private string _goalType;

    public Goal(string type, string name, string description, string points)
    {
        _goalType = type;
        _shortName = name;
        _description = description;
        _points = $"{points}";
    }

    public virtual void RecordEvent()
    {
        
    }

    public virtual bool IsComplete()
    {
        return false;
    }
    public virtual string GetDetailsString()
    {
        return $"{_goalType}, {_shortName}, {_description}, {_points}";
    }
    public virtual string GetStringRepresentation()
    {
        return $"{_shortName} ({_description})";
    }
    public string GetName()
    {
        return _shortName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetPoints()
    {
        return _points;
    }
    public string GetGoalType()
    {
        return _goalType;
    }
}
