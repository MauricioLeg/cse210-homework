using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        int number = -1;
        int sum = 0;
        double average = 0;
        Console.WriteLine("Enter a list of numbers (type 0 when finish)");
        List<int> numbers = new List<int>();
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string givenNumber = Console.ReadLine();
            number = int.Parse(givenNumber);

            if (number != 0)
            {
                numbers.Add(number);
            }
            sum += number;
            double listSize = numbers.Count;
            average = sum / listSize;

        }
            int largest = numbers[0];
            foreach (int findNumber in numbers)
            {
                if (findNumber > largest)
                {
                    largest = findNumber;
                }
            }

            int smallest = numbers[0];
            foreach (int findNumber in numbers)
            {
                if (findNumber < smallest && findNumber > 0)
                {
                    smallest = findNumber;
                }
            }

            
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine($"{num}");
        }
    }
}