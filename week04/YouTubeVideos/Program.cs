using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Unboxing the New TechPro Smartphone", "TechReviewer", 847);
        video1.AddComment(new Comment("Amazing phone! The camera quality is incredible", "@TechEnthusiast22"));
        video1.AddComment(new Comment("Thanks for the detailed review, very helpful", "@SarahJohnson"));
        video1.AddComment(new Comment("Where can I buy this phone?", "@MikeTheGeek"));
        video1.AddComment(new Comment("The battery life is impressive too!", "@TechGuru2024"));

        Video video2 = new Video("Morning Coffee Routine with FreshBrew Machine", "CoffeeLoverDaily", 423);
        video2.AddComment(new Comment("This coffee maker changed my life!", "@CaffeineFan99"));
        video2.AddComment(new Comment("Love how easy it looks to use", "@MorningPerson"));
        video2.AddComment(new Comment("Does it work with different coffee brands?", "@JavaJunkie"));
        
        Video video3 = new Video("10 Minute Workout with PowerFit Resistance Bands", "FitnessWithEmma", 612);
        video3.AddComment(new Comment("Great workout! I'm sweating already", "@HealthyLife2024"));
        video3.AddComment(new Comment("These bands are so versatile", "@GymRat87"));
        video3.AddComment(new Comment("Can beginners do this workout?", "@NewToFitness"));
        video3.AddComment(new Comment("Just ordered mine, can't wait to try this!", "@FitnessFanatic"));
        
        Video video4 = new Video("Cooking the Perfect Steak with ChefMaster Grill", "CulinaryKing", 956);
        video4.AddComment(new Comment("My mouth is watering! Need this grill now", "@FoodieForever"));
        video4.AddComment(new Comment("Best cooking tutorial I've seen", "@HomeCookHero"));
        video4.AddComment(new Comment("What temperature do you recommend?", "@SteakLover101"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        Console.WriteLine("Videos:");
        foreach (Video video in videos)
        {
            video.GetDisplayText();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}