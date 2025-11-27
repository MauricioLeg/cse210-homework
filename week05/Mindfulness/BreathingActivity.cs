public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing")
    {
        
    }
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("\b\b\b\b \b");
        int duration = GetDuration();
        Console.WriteLine("Get Ready...");
        ShowSpinner();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breath In...");
            ShowCountDown(4);
            Thread.Sleep(1000);
            Console.WriteLine("\b \b");
            Console.Write("Now breath Out...");
            ShowCountDown(6);
            Thread.Sleep(1000);
            Console.WriteLine("\b \b");

            count++;
            if (count > 3)
            {
                Console.Clear();
                Console.WriteLine("\b\b\b\b \b");
            }
        }
        DisplayEndingMessage();
        Console.WriteLine("\b\b\b \b");
    }
}