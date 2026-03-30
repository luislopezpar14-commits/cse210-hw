using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial", "CodeMaster", 1200);
        video1.AddComment(new Comment("Alice", "This tutorial is very helpful! Learned a lot."));
        video1.AddComment(new Comment("Bob", "The explanations are clear and easy to follow."));
        video1.AddComment(new Comment("Charlie", "Great pacing! Wish there were more examples though."));
        video1.AddComment(new Comment("Diana", "Finally understand abstraction. Thank you!"));
        videos.Add(video1);

        Video video2 = new Video("OOP Concepts", "Tech", 2400);
        video2.AddComment(new Comment("Eve", "Mind blown! This changed how I write code."));
        video2.AddComment(new Comment("Frank", "Could you go deeper into inheritance patterns?"));
        video2.AddComment(new Comment("Grace", "Excellent practical examples."));
        videos.Add(video2);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }
            
            Console.WriteLine(); 
        }
    }
}