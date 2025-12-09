public class Running : Activity
{
    private double _distance;
    public Running(int minutes, double distance) : base(minutes)
    {
        _distance = distance;
    }
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        int min = GetMinutes();
        return (_distance / min) * 60;;
    }
    public override double GetPace()
    {
        int min = GetMinutes();
        return min / _distance;
    }
}