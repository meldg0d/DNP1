using GithubTest;

namespace CLI.UI.ManagePosts;

public class ManagePostsView
{

    public async Task Show(IPostRepository postRepository, IUserRepository userRepository)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=====================================");
        Console.WriteLine("       Manage Posts View      ");
        Console.WriteLine("=====================================");

        // Set color for options
        Console.WriteLine("1. Create a new post");
        Console.WriteLine("2. Edit a post");
        Console.WriteLine("3. Delete a post");
        Console.WriteLine("4. view all posts");
        Console.WriteLine("5. Back to Main Menu");
        Console.WriteLine("*************************************");

        // Get user input
        Console.Write("\nEnter your choice (1-4): ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            //Create new posts
            case "1":
                CreatePostView newPostView = new CreatePostView();
                await newPostView.Show(postRepository, userRepository);
                break;
            //Edit posts
            case "2":
                EditPostView editPostView = new EditPostView();
                await editPostView.Show(postRepository);
                break;
            //Delete posts 
            case "3":
                DeletePostView deletePostView = new DeletePostView();
                await deletePostView.Show(postRepository);
                break;
            //Back to menu
            case "4":
                ListPostsView listPostsView = new ListPostsView();
                await listPostsView.Show(postRepository);
                break;
            
            case "5":
                break;
                
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice, please try again.");
                Console.ResetColor();
                Console.ReadKey();
                break;
        }
    }
}