// See https://aka.ms/new-console-template for more information

using CLI.UI;
using FileRepositories;
using GithubTest;

try
{
    Console.WriteLine("Starting...");
        
    IUserRepository userRepository = new UserFileRepository(); //OLD InMemoryRepository
    ICommentRepository commentRepository = new CommentFileRepository(); //OLD InMemoryRepository
    IPostRepository postRepository = new PostFileRepository(); //OLD InMemoryRepository
    
    
        
    var cliApp = new CliApp(userRepository, commentRepository, postRepository);
        
    await cliApp.StartAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}