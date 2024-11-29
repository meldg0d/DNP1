using System.Threading.Channels;
using CLI.UI;
using FileRepositories;
using InMemoryRepositories;
using RepositoryContracts;


Console.WriteLine("Started CLI......");
IUserRepository userRepository = new UserFileRepository();
IPostRepository postRepository = new PostFileRepository();