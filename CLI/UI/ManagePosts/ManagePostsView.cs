namespace CLI.UI.ManagePosts;

public class ManagePostsView
{

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=====================================");
        Console.WriteLine("       Manage Posts View      ");
        Console.WriteLine("=====================================");

        // Set color for options
        Console.WriteLine("1. Create a new post");
        Console.WriteLine("2. Edit a post");
        Console.WriteLine("3. Delete a post");
        Console.WriteLine("4. Back to Main Menu");
        Console.WriteLine("*************************************");

        // Get user input
        Console.Write("\nEnter your choice (1-4): ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            //Create new posts
            case "1":
                CreatePostView newPostView = new CreatePostView();
                newPostView.Show();
                break;
            //Edit posts
            case "2":
                    
                break;
            //Delete posts 
            case "3":
                break;
            
            case "4":
                break;
                
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice, please try again.");
                Console.ResetColor();
                break;
        }
    }
}