public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private int _questionIndex = 0;
    private static List<string> _usedPrompts = new List<string>();
    public ReflectingActivity() : base("Reflecting")
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        _prompts.Add("Think of a time when you overcame a fear.");
        _prompts.Add("Think of a time when you made a difficult decision.");
        _prompts.Add("Think of a time when you learned from a failure.");
        _prompts.Add("Think of a time when you showed courage.");
        _prompts.Add("Think of a time when you persevered through a challenge.");
        _prompts.Add("Think of a time when you were honest despite the consequences.");
        _prompts.Add("Think of a time when you forgave someone.");
        _prompts.Add("Think of a time when you worked hard to achieve a goal.");
        _prompts.Add("Think of a time when you stayed calm under pressure.");
        _prompts.Add("Think of a time when you inspired someone else.");
        _prompts.Add("Think of a time when you chose kindness over anger.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
        _questions.Add("What was the most challenging part of this experience?");
        _questions.Add("How did you overcome the obstacles you faced?");
        _questions.Add("Who helped you during this experience?");
        _questions.Add("How did this experience change you?");
        _questions.Add("What strengths did you discover about yourself?");
        _questions.Add("How did others react to what you did?");
        _questions.Add("What would you do differently if you could do it again?");
        _questions.Add("How has this experience influenced your life since then?");
        _questions.Add("What emotions did you feel during this experience?");
        _questions.Add("What was the turning point in this experience?");
        _questions.Add("How did you prepare yourself for this challenge?");
        _questions.Add("What advice would you give someone facing a similar situation?");
        _questions.Add("How did this experience affect your relationships?");
        _questions.Add("What surprised you most about yourself?");
        _questions.Add("How did you know you were doing the right thing?");
        _questions.Add("What risks did you take?");
        _questions.Add("How did this experience build your confidence?");
        _questions.Add("What values did this experience reinforce in you?");
        _questions.Add("How did you handle the fear or uncertainty?");
        _questions.Add("What positive outcomes came from this experience?");
        _questions.Add("How can you apply what you learned to current challenges?");
    }
    
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("\b\b\b\b \b");
        int duration = GetDuration();
        Console.WriteLine("Get Ready...");
        ShowSpinner();
        Console.WriteLine();

        Console.WriteLine("Consider the following prompt");
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"---{prompt}---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter");
        Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in...");
        ShowCountDown(5);

        Console.Clear();
        Console.WriteLine("\b\b\b\b \b");

        Console.WriteLine(prompt);
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        
        int count = 0;
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpinnerLarger();
            Console.WriteLine();
            count++;
            if (count > 8)
            {
                Console.Clear();
                Console.WriteLine("\b\b\b\b \b");
            }
        }
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
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
        return prompt;
    }
    public string GetRandomQuestion()
    {
        if (_questionIndex >= _questions.Count)
        {
            _questionIndex = 0;

            Random random = new Random();
            for (int i = _questions.Count - 1; i > 0; i--)
            {
                int question = random.Next(i +1);
                string used = _questions[i];
                _questions[i] = _questions[question];
                _questions[question] = used;
            }
        }
        return _questions[_questionIndex++];
    }
    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }
    public void DisplayQuestion()
    {
        Console.Write($"{GetRandomQuestion()} ");
    }
}