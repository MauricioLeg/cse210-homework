using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your score? ");
        string score = Console.ReadLine();
        int scoreNumber = int.Parse(score);

        string letter = "";

        if (scoreNumber >= 90)
        {
            letter = "A";
        }

        else if (scoreNumber >= 80)
        {
            letter = "B";
        }

        else if (scoreNumber >= 70)
        {
            letter = "C";
        }

        else if (scoreNumber >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        int lastDigit = scoreNumber % 10;

        string sign = "";

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        if (scoreNumber >= 93)
        {
            sign = "";
        }
        else if (scoreNumber < 60)
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (scoreNumber >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class");
        }

        if (scoreNumber < 70)
        {
            Console.WriteLine("You did not pass the class. Try next time");
        }
    }
}