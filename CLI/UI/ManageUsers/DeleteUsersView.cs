using GithubTest;

namespace CLI.UI.ManageUsers;

public class DeleteUsersView
{
    public async Task Show(IUserRepository userInMemoryRepository)
    {
        Console.Clear();
        
        Console.WriteLine("=====================================");
        Console.WriteLine("       Delete User View      ");
        Console.WriteLine("=====================================");

        // Set color for options
        Console.WriteLine("1. Delete user");
        Console.WriteLine("2. Delete all users");
        Console.WriteLine("3. Back to Main Menu");
        
        // Get user input
        Console.Write("\nEnter your choice (1-3): ");
        string? choice = Console.ReadLine();


        switch (choice)
        {
            //Delete single user
            case "1":
                Console.WriteLine("Enter user name: ");
                string? userName = Console.ReadLine();
                
                Console.WriteLine($"Are you sure you want to delete {userName} user? Type yes or no");
                string confirm = Console.ReadLine().ToUpper();
                if (confirm == "YES")
                {
                    try
                    {
                        await userInMemoryRepository.DeleteUserAsync(userName);
                        Console.WriteLine($"{userName} deleted");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error occurred while deleting the user: " + e.Message);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aborted deletion");
                    
                }
                
                break;
            //Delete all users
            case "2":
                Console.WriteLine("Are you sure all users are deleted? Type yes or no");
                string confirm2 = Console.ReadLine().ToUpper();

                if (confirm2 == "YES")
                {
                    await userInMemoryRepository.DeleteAllUsersAsync();
                }
                Console.WriteLine("All users deleted");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                break; 
            case "3":
                return;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice, please try again.");
                Console.ResetColor();
                break;
            
        }
    }
}