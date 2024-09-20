using GithubTest;

namespace CLI.UI.ManagePosts;

public class DeletePostView
{
    public async Task Show(IPostRepository postRepository)
    {
        Console.Clear();
        Console.WriteLine("What is the ID of the post?");
        int postId;
        while (true)
        {
            var input = Console.ReadLine();
    
            // Try to parse the input to an integer
            if (int.TryParse(input, out postId))
            {
                break; // If parsing succeeds, break out of the loop
            }
    
            // If input is invalid, display an error and prompt again
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a valid numeric Post ID.");
            Console.ResetColor();
        }
        try
        {
            await postRepository.DeleteAsync(postId);
            Console.WriteLine("Post deleted. Press any key to exit.");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while deleting: " + e.Message);
            Console.ResetColor();
            Console.ReadKey();
            throw;
        }
        
        
    }
}