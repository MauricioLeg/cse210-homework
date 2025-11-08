// A text is display to let the user choose to save the entry to a new file or to a loaded file
// so the user can have multiple files or keep writing in the same file.
// The program displays the files that are stored for the user to choose where to write

using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = "0";
        Journal entry = new Journal();
        Console.WriteLine("Hello World! This is the Journal Project.");
        while (answer != "5")
        {
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choice: ");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1")
            {
                entry.AddEntry();
            }
            if (answer == "2")
            {
                entry.Display();
            }

            if (answer == "3")
            {
                entry.Load();
            }

            if (answer == "4")
            {
                entry.Save();
            }
        }
    }
}