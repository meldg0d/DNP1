using GithubTest;

namespace CLI.UI.ManagePosts;

public class CreatePostView
{

    public async Task Show(IPostRepository postRepository, IUserRepository userRepository)
    {
        Console.Clear();
        Console.WriteLine("What is the username of the user who is creating the post?");
        var username = Console.ReadLine();

        try
        {
            var user = await userRepository.GetUserAsync(username);
            Console.WriteLine($"User: {username} found");
            
            Console.WriteLine("What is the title of the post?");
            var title = Console.ReadLine();
            
            Console.WriteLine("What is the content of the post?");
            var content = Console.ReadLine();
            
            Post? post = new Post(title, content, user.Id);
            
            await postRepository.AddAsync(post);
            
            Console.WriteLine("Post created... press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while adding the Post: " + e.Message);
            Console.ResetColor();
            Console.ReadKey();
        }
        
        
        

    }
    
}