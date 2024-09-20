using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using GithubTest;

namespace CLI.UI;

public class CliApp
{
    private readonly IUserRepository _userRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    
    
    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public async Task StartAsync()
    {
        // Simulate connection to some server
        await Task.Delay(1000);
        
        // Seed the repository with random users (e.g., 10 users)
        await _userRepository.SeedUsersAsync(10);

        // Now proceed with the rest of your application logic
        Console.WriteLine("Random users have been added to the system!");
        
        
        
        Console.WriteLine("App started");
        
        Console.Title = "Cool Console Menu"; //Console title... 
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("*        Select an option:          *");
            Console.WriteLine("*************************************");
            
            Console.WriteLine("1. Manage Posts");
            Console.WriteLine("2. Manage Users");
            Console.WriteLine("3. Manage Comments");
            Console.WriteLine("4. Exit");

            Console.WriteLine("*************************************");
            Console.ResetColor();
            
            // Get user input
            Console.Write("\nEnter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                //ManagePosts
                case "1":
                     ManagePostsView postView = new ManagePostsView();
                     postView.Show();
                    break;
                //ManageUsers
                case "2":
                    ManageUsersView userView = new ManageUsersView();
                    userView.Show(_userRepository);
                    break;
                //ManageComments
                case "3":
                    break;
                
                //Closing App
                case "4":
                    System.Environment.Exit(1);
                    break;
                
                //Default
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice, please try again.");
                    Console.ResetColor();
                    break;
            }
            
        }
    }
        

}