using GithubTest;

namespace CLI.UI.ManagePosts;

public class ListPostsView
{
    public async Task Show(IPostRepository postRepository)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        var post = postRepository.GetAll();
        
        Console.WriteLine("ListPostsView:");
        Console.WriteLine();
        post.ToList().ForEach(p => Console.WriteLine($"ID:  {p.Id} Title:  {p.Title} Body:  {p.Body}"));

        
        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
    }
}