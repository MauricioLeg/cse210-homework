public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string type, string name, string description, string points, int target, int bonus) : base(type, name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()
    {
        return $"{_amountCompleted}, {_target}, {_bonus}";
    }
    public override string GetStringRepresentation()
    {
        return $"---------- {_amountCompleted}/{_target}";
    }
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
}