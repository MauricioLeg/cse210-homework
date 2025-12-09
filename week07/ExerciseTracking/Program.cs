using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        Running running = new Running(30, 4.5);
        Cycling cycling = new Cycling(30, 15);
        Swimming swimming = new Swimming(30, 6);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}