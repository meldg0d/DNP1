using GithubTest;
using InMemoryRepositories;

namespace CLI.UI.ManageUsers;

public class ListUsersView
{

    public async Task Show(IUserRepository userInMemoryRepository)
    {
        Console.Clear();
        
         var userlist = await userInMemoryRepository.GetAllUsersAsync();
         
       
        //show list of all users
        userlist.ForEach(u => Console.WriteLine($"{u.Username}:{u.Password}"));
        
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        
    }
}