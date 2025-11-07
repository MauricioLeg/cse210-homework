using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {"What made me smile today?",
    "What are three thing I'm grateful for right now?",
    "How did I see the hand of the Lord today?",
    "If I could travel anywhere in the world, where would I go and why?",
    "What challenges did I face today?",
    "What was the best part of my day and why?",
    "How did I practice self-care today?",
    "What was the strongest emotion I felt today?",
    "Who was the most interesting person I met today?",
    "What is a goal you're working towards right now?"};

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}