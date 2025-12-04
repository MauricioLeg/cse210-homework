// Completed goals are separated from active goals
// 

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        
        GoalManager starter = new GoalManager();
        starter.Start();
    }
}