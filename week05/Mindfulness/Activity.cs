public class Activity
{
    private string _name = "";
    private string _description = "";
    private int _duration;
    
    public Activity(string name)
    {
        _name = name;
        if (name == "Breathing")
        {
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
        if (name == "Reflecting")
        {
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }
        if (name == "Listing")
        {
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("\b\b\b\b \b");
        Console.WriteLine($"Welcome to the {_name} activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string time = Console.ReadLine();
        _duration = int.Parse(time);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well Done!!!");
        ShowSpinner();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner();
        Console.Clear();
        Console.WriteLine("\b\b\b \b");
    }
    public void ShowSpinner()
    {
        List<string> line = new List<string>();
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(10);
        int i = 0;
        while (DateTime.Now < end)
        {
            string s = line[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;

            if (i >= line.Count())
            {
                i = 0;
            }
        }
    }

    public void ShowSpinnerLarger()
    {
        List<string> line = new List<string>();
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");
        line.Add("|");
        line.Add("/");
        line.Add("−");
        line.Add("\\");

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(15);
        int i = 0;
        while (DateTime.Now < end)
        {
            string s = line[i];
            Console.Write(s);
            Thread.Sleep(800);
            Console.Write("\b \b");
            i++;

            if (i >= line.Count())
            {
                i = 0;
            }
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public int GetDuration()
    {
        return _duration;
    }
}
            