using GithubTest;
using InMemoryRepositories;

namespace CLI.UI.ManageUsers;

public class CreateUserView
{
    public async Task Show(IUserRepository userInMemoryRepository)
    {
        Console.Clear();
        Console.WriteLine("Username:");
        var username = Console.ReadLine().ToLower();
        
        Console.WriteLine("Password:");
        var password = Console.ReadLine();
        
        User user = new User(username, password);


        try
        {
            await userInMemoryRepository.AddUserAsync(user);
            Console.WriteLine("User successfully added!");
            Console.WriteLine($"Username: {username} \nPassword: {password}");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while adding the user: " + e.Message);
            Console.ResetColor();
        }
       
        
    }
}