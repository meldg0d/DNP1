using GithubTest;
using InMemoryRepositories;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    public void Show(IUserRepository userInMemoryRepository)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=====================================");
        Console.WriteLine("       Manage User View      ");
        Console.WriteLine("=====================================");

        // Set color for options
        Console.WriteLine("1. Create a new User");
        Console.WriteLine("2. See all users");
        Console.WriteLine("3. Edit a User");
        Console.WriteLine("4. Delete a User");
        Console.WriteLine("5. Back to Main Menu");
        Console.WriteLine("*************************************");

        // Get user input
        Console.Write("\nEnter your choice (1-4): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            //Create new posts
            case "1":
                CreateUserView createUserView = new CreateUserView();
                createUserView.Show(userInMemoryRepository);
                break;
            //Edit posts
            case "2":
                ListUsersView listUserView = new ListUsersView();
                listUserView.Show(userInMemoryRepository);

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