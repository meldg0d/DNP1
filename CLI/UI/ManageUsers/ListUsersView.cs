using GithubTest;
using InMemoryRepositories;

namespace CLI.UI.ManageUsers;

public class ListUsersView
{
    public async Task Show(IUserRepository userInMemoryRepository)
    {
        
        //not using await because it isnt asynchronous and console.clear will clear at the wrong time. This solution locks the thread until it's done. *use await instead*
         var userlist =  userInMemoryRepository.GetAllUsersAsync().GetAwaiter().GetResult();
         
         Console.Clear();
         
        //show list of all users
        userlist.ForEach(u => Console.WriteLine($"{u.Id}   {u.Username}:{u.Password}"));
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}