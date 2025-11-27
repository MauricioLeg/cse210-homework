public class ListingActivity : Activity
{
    private int _count = 0;
    private int times = 0;
    private List<string> _prompts = new List<string>();
    private static List<string> _usedPrompts = new List<string>();
    public ListingActivity() : base("Listing")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
        _prompts.Add("What are some things you are grateful for today?");
        _prompts.Add("What are some of your favorite memories?");
        _prompts.Add("What are some things that make you happy?");
        _prompts.Add("What are some accomplishments you are proud of?");
        _prompts.Add("What are some goals you have achieved?");
        _prompts.Add("What are some talents or skills you possess?");
        _prompts.Add("What are some ways you have shown kindness recently?");
        _prompts.Add("What are some positive qualities you see in yourself?");
        _prompts.Add("What are some blessings in your life?");
        _prompts.Add("What are some times when you felt loved?");
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("\b\b\b\b \b");
        Console.WriteLine("Get Ready...");
        ShowSpinner();
        Console.WriteLine();

        Console.WriteLine("List as many responses to the following prompt");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
    public void GetRandomPrompt()
    {
        Random random = new Random();
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        string prompt;
        do
        {
            int index = random.Next(_prompts.Count);
            prompt = _prompts[index];
        }
        while (_usedPrompts.Contains(prompt));
        _usedPrompts.Add(prompt);
        Console.WriteLine($"---{prompt}---");
    }
    public List<string> GetListFromUser()
    {
        List<string> userResponses = new List<string>();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            userResponses.Add(response);
            _count++;
            
            times ++;
            if (times > 5)
            {
                Console.Clear();
                Console.WriteLine("\b\b\b\b \b");
                times = 0;
            }
        }
        return userResponses;
    }
}