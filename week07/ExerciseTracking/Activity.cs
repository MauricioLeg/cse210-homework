using System.Diagnostics;
public abstract class Activity
{
    private int _minutes;
    public Activity(int minutes)
    {
        _minutes = minutes;
    }
    public string GetDate()
    {
        string dateText = DateTime.Now.ToString("dd MMM yyyy");
        return dateText;
    }
    public int TrackTime()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine("Press enter when finished...");
        Console.ReadLine();

        stopwatch.Stop();
        _minutes = (int)stopwatch.Elapsed.TotalMinutes;
        return _minutes;
    }
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public string GetSummary()
    {
        string date = GetDate();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        string activityType = this.GetType().Name;
        return $"{date} {activityType} ({_minutes} min): Distance {distance:F1}km, Speed: {speed:F1} kmh, Pace {pace:F2} min per km";
    }
    public int GetMinutes()
    {
        return _minutes;
    }
}