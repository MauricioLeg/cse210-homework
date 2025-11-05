using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Job jobOne = new Job();
        jobOne._jobTitle = "Software Engineer";
        jobOne._company = "Apple";
        jobOne._startYear = 2020;
        jobOne._endYear = 2021;

        Job jobTwo = new Job();
        jobTwo._jobTitle = "Software Engineer";
        jobTwo._company = "Samsung";
        jobTwo._startYear = 2021;
        jobTwo._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "John Wick";
        myResume._jobs.Add(jobOne);
        myResume._jobs.Add(jobTwo);

        myResume.Display();
    }
}
