// The prompt for the reflecting activity is always shown throughout the activity
// Also, any random question/prompt is repeated until all are displayed
//

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        string choice = "";
        while (choice != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice a number from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                Activity activity = new Activity("Breathing");
                breathing.DisplayStartingMessage();
                breathing.Run();
            }
            if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                Activity activity = new Activity("Reflecting");
                reflecting.DisplayStartingMessage();
                reflecting.Run();
            }
            if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                Activity activity = new Activity("Listing");
                listing.DisplayStartingMessage();
                listing.Run();
            }
        }
    }
}