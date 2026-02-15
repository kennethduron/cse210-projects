using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 30 Minutes", "Code Academy", 1800);
        video1.AddComment(new Comment("Alice", "This was super helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation."));
        video1.AddComment(new Comment("Carlos", "I finally understand classes!"));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video("OOP Explained Simply", "Tech World", 1200);
        video2.AddComment(new Comment("Daniela", "Best OOP video ever."));
        video2.AddComment(new Comment("Elena", "Very clear examples."));
        video2.AddComment(new Comment("Frank", "Thanks for this!"));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Build Projects in C#", "Dev Master", 2400);
        video3.AddComment(new Comment("Grace", "Exactly what I needed."));
        video3.AddComment(new Comment("Henry", "Please make more videos!"));
        video3.AddComment(new Comment("Isabella", "This helped me pass my class."));

        videos.Add(video3);

        // Display videos
        foreach (Video video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLength()}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
