using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>
        {
            new Video("Lionel Messi 12 Most LEGENDARY Moments Ever in Football ►Impossible to Repeat◄", "Messi Magic", 555),
            new Video("Lionel Messi 100 Magical Dribbles", "Barca Tv", 1235),
            new Video("Lionel Messi Career Highlights", "The Highlight Factory", 599)
        };


        videos[0].AddComment("rmiddlehouse", "Messi the only athlete that requires 9 replays to fully understand what he did");
        videos[0].AddComment("joebarca3965", "I watched all of Messi's goals,skills,assists but still don't get tired of watching him over and over again");
        videos[0].AddComment("Debebek1","Seen a lot of messi videos, but this one hits different. Great editing, great timing, great music, thanks for this.");
        videos[0].AddComment("Marleyjr00X","Argentina just won the 2022 World Cup and this man is definitely without a doubt the GOAT!!!");

        videos[1].AddComment("pattywu3915", "Messi has raised the bar so high that he is alone up there!");
        videos[1].AddComment("Cualchris", "Give props to all the cameraman. They had the difficult task to keep up with that man.");
        videos[1].AddComment("isaacknecht974","we will all miss Messi my childhood icon and insparation");
        videos[1].AddComment("zeebaa6","I've watched this prbly 20 times. Masterpiece of football editing.");

        videos[2].AddComment("hogrider206", "Speed reacting to this is the funniest thing ever.");
        videos[2].AddComment("dannylaverdedrums", "Who’s here after 2022 World Cup?");
        videos[2].AddComment("chelious1973","Honestly, im so thankfull that i got the oppertunity to watch Messi play growing up. There is simply nothing like him…");
        videos[2].AddComment("EBLego","Balance, vision, dribbling, speed, finishing, passing. The best ever");

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string name, string text)
    {
        Comments.Add(new Comment(name, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}