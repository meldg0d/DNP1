using GithubTest;
using InMemoryRepositories;

namespace CLI.UI.ManageUsers;

public class EditUsersView
{
    public async Task Show(IUserRepository userInMemoryRepository)
    {
        Console.Clear();
        Console.WriteLine("Enter username on user to edit?");
        string? userName = Console.ReadLine();


        try
        {
            var user = await userInMemoryRepository.GetUserAsync(userName);
            
            Console.WriteLine($"Username: {user.Username} Password: {user.Password}");
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("1. Username");
            Console.WriteLine("2. Password");

            string msg = Console.ReadLine();

            switch (msg)
            {
                //Username
                case "1":
                    Console.Clear();
                    Console.WriteLine("Enter new username");
                    string newUserName = Console.ReadLine();
                    
                    User newUserUN = new User(user.Id,newUserName, user.Password);
                    
                    userInMemoryRepository.UpdateUserAsync(newUserUN);
                    
                    break;
                //Password
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter new password");
                    string newPassword = Console.ReadLine();
                    
                    User newUserPW = new User(user.Id, user.Username, newPassword);
                    
                    userInMemoryRepository.UpdateUserAsync(newUserPW);
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        

    }
}