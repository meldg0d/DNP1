﻿namespace GithubTest;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }

    public Post(int id, string title, string body, int userId)
    {
        Id = id;
        Title = title;
        Body = body;
        UserId = userId;
    }
    
    public Post( string title, string body, int userId)
    { 
        Id = new Random().Next();
        Title = title;
        Body = body;
        UserId = userId;
    }
}