using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Foundation 1, Youtube video tracker:\n");
        List<Video> videos = CreateExampleVideos();
        int index = 1;
        foreach(Video video in videos)
        {
            Console.WriteLine($"\t\tVideo #{index}");
            video.DisplayVideoInfo();
            Console.WriteLine("");
            index++;
        }
    }
    public static List<Video> CreateExampleVideos()
    {
        //The example data is AI generated but dont worry, nothing else is. 

        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Gaming: Speedrunning Classic RPGs", // Title
            "RetroGamerMax", // Author
            480, // Length in seconds
            new List<Comment> // Comments
            {
                new Comment("SpeedyGamer87", "Incredible skills, Max!"),
                new Comment("OldSchoolFanatic", "Nostalgia overload!"),
                new Comment("RPGMastermind", "You make it look easy.")
            }
        );
        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Travel Vlog: Exploring Tokyo's Hidden Gems",
            "WanderlustAdventures",
            600,
            new List<Comment>
            {
                new Comment("TokyoExplorer123", "I miss Tokyo!"),
                new Comment("TravelEnthusiast", "Adding these spots to my list!"),
                new Comment("HiddenGemHunter", "Thanks for sharing!")
            }
        );
        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Fitness: HIIT Workout for Beginners",
            "FitLifeWithSarah",
            300,
            new List<Comment>
            {
                new Comment("FitnessJunkie99", "Great beginner routine!"),
                new Comment("HealthAndWellnessFan", "Easy to follow, thanks!"),
                new Comment("NewYearNewMe2023", "Starting my fitness journey!")
            }
        );
        videos.Add(video3);

        return videos;
    }
}