using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video firstVideo = new Video("How to Make Homemade Pizza", "Kitchen Corner", 615);
        firstVideo.AddComment(new Comment("Maria", "This recipe was easy to follow. Thank you!"));
        firstVideo.AddComment(new Comment("David", "I tried it with extra cheese and it was delicious."));
        firstVideo.AddComment(new Comment("Ana", "Could you make a video about homemade pasta next?"));
        videos.Add(firstVideo);

        Video secondVideo = new Video("Beginner Guitar Lesson: First Three Chords", "Music Steps", 482);
        secondVideo.AddComment(new Comment("Carlos", "I finally learned my first song with these chords."));
        secondVideo.AddComment(new Comment("Sofia", "The explanation was very clear."));
        secondVideo.AddComment(new Comment("James", "Please make another lesson about strumming patterns."));
        videos.Add(secondVideo);

        Video thirdVideo = new Video("10 Tips for Better Landscape Photos", "Creative Lens", 754);
        thirdVideo.AddComment(new Comment("Emily", "The lighting tip made a big difference in my photos."));
        thirdVideo.AddComment(new Comment("Luis", "I liked the examples from different locations."));
        thirdVideo.AddComment(new Comment("Rachel", "This was helpful for my next trip."));
        videos.Add(thirdVideo);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
