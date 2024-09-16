// See https://aka.ms/new-console-template for more information

using CLI.UI;
using GithubTest;
using InMemoryRepositories;

try
{
    Console.WriteLine("Starting...");
        
    IUserRepository userRepository = new UserInMemoryRepository();
    ICommentRepository commentRepository = new CommentInMemoryRepository();
    IPostRepository postRepository = new PostInMemoryRepository();
        
    var cliApp = new CliApp(userRepository, commentRepository, postRepository);
        
    await cliApp.StartAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}