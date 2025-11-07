using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<string> _entries = new List<string>();
    public List<string> _newEntries = new List<string>();
    private bool _isLoaded = true;
    private string _loadedFileName;
    private string[] _loadedLines;
    private Entry _currentEntry;
    public Entry AddEntry()
    {
        PromptGenerator generator = new PromptGenerator();
        string prompt = generator.GetRandomPrompt();
        Console.WriteLine(prompt);
        string userAnswer = Console.ReadLine();
        string dateText = DateTime.Now.ToShortDateString();

        _entries.Add(dateText + " - " + prompt + " " + userAnswer);
        _newEntries.Add(dateText + " - " + prompt + " " + userAnswer);

        _currentEntry = new Entry
        {
            prompt = prompt,
            userAnswer = userAnswer,
            dateText = dateText
        };

        return _currentEntry;
    }
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There is nothing to display");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            return;
        }

        foreach (string i in _entries)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(i);
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
    public string[] Load()
    {
        string dir = Directory.GetCurrentDirectory();
        string[] txtFiles = Directory.GetFiles(dir, "*.txt");

        List<string> fileNames = new List<string>();
        foreach (var f in txtFiles)
        {
            fileNames.Add(Path.GetFileName(f));
        }

        // Check if there is any files to load
        if (fileNames.Count == 0)
        {
            Console.WriteLine($"No files to load.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            _isLoaded = false;
            return new string[0];
        }

        // Displays the file names
        Console.WriteLine("Files:");
        for (int i = 0; i < fileNames.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {fileNames[i]}");
        }
        
        Console.WriteLine("What is the name of the file you want to load?");
        string fileToLoad = Console.ReadLine();

        // Load the file to a list
        if (File.Exists(fileToLoad))
        {
            _loadedLines = File.ReadAllLines(fileToLoad);
            _loadedFileName = fileToLoad;
            _isLoaded = true;
            
            foreach (string line in _loadedLines)
            {
                _entries.Add(line);
            }
            Console.WriteLine($"File {fileToLoad} loaded successfully.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            return _loadedLines;
        }
        else
        {
            Console.WriteLine($"Error: File '{fileToLoad}' not found");
            Console.WriteLine("--------------------------------------------------------------------------------");
            _isLoaded = false;
            return new string[0];
        }
    }

    public Entry GetCurrentEntry()
    {
        return _currentEntry;
    }
    public void Save()
    {
        if (_currentEntry == null)
        {
            Console.WriteLine("No entry to save. Please write an entry first using option 1.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            return;
        }

        Console.Write("Do you want to create a new file or save into a loaded file (new/loaded)? ");
        string saveOpt = Console.ReadLine().ToLower();

        Entry entry = GetCurrentEntry();

        if (saveOpt == "new")
        {
            Console.WriteLine("What will be the name of the file?");
            string fileName = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (string i in _entries)
                {
                outputFile.WriteLine(i);
                }
            }
            Console.WriteLine("File saved successfully.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        if (saveOpt == "loaded")
        {
            if (_loadedLines != null && File.Exists(_loadedFileName))
            {
                using (StreamWriter outputFile = new StreamWriter(_loadedFileName, append: true))
                {
                    foreach (string i in _newEntries)
                    {
                        outputFile.WriteLine(i);
                    }
                }
                Console.WriteLine("Entry saved successfully.");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Error: No file has been loaded yet. Please load a file first.");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}