using RESTDemo .Model;

namespace RESTDemo .Services
    {
    public interface IUserService
        {
        IEnumerable<User> GetAllUsers ();            // Get all users
        User GetUserById ( int id );                   // Get user by ID
        User GetUserByEmail ( string email );          // Get user by email
        int RegisterUser ( User user );                // Register a new user
        User LoginUser ( string email , string password );  // Login user with email and password
        bool CheckIfUserExists ( string email );       // Check if a user exists by email
        }
    }
 