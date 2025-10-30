using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.WriteLine("Guess Random number game");
        string answer = "yes";
        while (answer == "yes")
        {
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 100);

            int guessValue = -1;
            int guesses = 0;

            while (guessValue != randomNumber)
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessValue = int.Parse(guess);
                guesses += 1;

                if (guessValue > randomNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guessValue < randomNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You guessed {guesses} times");
                }
            }

            Console.Write("Do you want to keep playing (yes/no)? ");
            answer = Console.ReadLine();
        }
    }
}