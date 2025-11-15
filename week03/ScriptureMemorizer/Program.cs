// Some code were added to read from a file that contain multiple scriptures within the subfolder bin\Debug\net8.0
// The program display all the scriptures available to memorize
//  The program prompts the user to choose a scripture by number or random

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        string[] lines = File.ReadAllLines("scriptures.txt");
        int refNumber = 1;
        Console.WriteLine("Choose from the following scriptures to memorize:");
        for (int i = 0; i < lines.Length; i++)
        {
            string allReferences = lines[i];
            string[] splitRef = allReferences.Split('|');
            string onlyRef = splitRef[0];
            
            Console.Write(refNumber + " - ");
            Console.WriteLine(onlyRef);
            refNumber++;
        }
        Console.WriteLine("Choose by number or type 'random' for a random scripture:");
        string choose = Console.ReadLine().ToLower();
        string givenLine;
        var rng = new Random();

        if (choose == "random")
        {
            givenLine = lines[rng.Next(lines.Length)];
        }
        else
        {
            if (!int.TryParse(choose,out int choiceNumber) ||
                choiceNumber < 1 || choiceNumber > lines.Length)
            {
                Console.WriteLine("Invalid Selection");
                return;
            }
            givenLine = lines[choiceNumber - 1];
        }

        string[] parts = givenLine.Split('|');
        string refText = parts[0].Trim();
        string text = parts[1].Trim();

        string[] refParts = refText.Split(' ');
        
        string book = string.Join(" ", refParts.Take(refParts.Length -1));
        string[] chapterVerse = refParts.Last().Split(':');
        int chapter = int.Parse(chapterVerse[0]);
        
        string verseText = chapterVerse[1];
        int lastVerse;
        
        Reference reference;
        Scripture scripture;
        if (verseText.Contains('-'))
        {
            // multiple verses
            string[] verseRange = verseText.Split('-');
            int verse = int.Parse(verseRange[0]);
            lastVerse = int.Parse(verseRange[1]);
            reference = new Reference(book, chapter, verse, lastVerse);
            scripture = new Scripture(reference, text);
        }
        else
        {
            // single verse
            int verse = int.Parse(verseText.Trim());
            reference = new Reference(book, chapter, verse);
            scripture = new Scripture(reference, text);            
        }

        while (true)
        {
            ClearScreen();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;
            
            if (input == "")
            {
                int toHide = rng.Next(2, 4);
                scripture.HideRandomWords(toHide);
            }
        }
    }

    static void ClearScreen()
    {
        // Print just enough newlines to clear visible content, leaving room for the scripture and prompt
        for (int i = 0; i < Console.WindowHeight - 5; i++)
        {
            Console.WriteLine();
        }
    }
}