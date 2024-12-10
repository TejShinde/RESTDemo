using RESTDemo .Model;
using RESTDemo .Repositories;

namespace RESTDemo .Services
    {
    public class UserService : IUserService
        {
        private readonly IUserRepository _repo;

        public UserService ( IUserRepository repo )
            {
            _repo = repo;
            }

        // Get all users
        public IEnumerable<User> GetAllUsers ()
            {
            return _repo .GetAllUsers();  // Call to repository method
            }

        // Get user by ID
        public User GetUserById ( int id )
            {
            return _repo .GetUserById(id);  // Call to repository method
            }

        // Get user by Email
        public User GetUserByEmail ( string email )
            {
            return _repo .GetUserByEmail(email);  // Call to repository method
            }

        // Register User
        public int RegisterUser ( User user )
            {
            return _repo .RegisterUser(user);  // Call to repository method to add the user
            }

        // Login User
        public User LoginUser ( string email , string password )
            {
            return _repo .LoginUser(email , password);  // Call to repository method to validate user login
            }

        // Check if User exists by Email
        public bool CheckIfUserExists ( string email )
            {
            return _repo .CheckIfUserExists(email);  // Call to repository method to check if user exists
            }
        }
    }
