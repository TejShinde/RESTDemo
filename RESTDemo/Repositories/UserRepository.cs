using RESTDemo .Data;
using RESTDemo .Model;
using System .Linq;

namespace RESTDemo .Repositories
    {
    public class UserRepository : IUserRepository
        {
        private readonly ApplicationDbContext db;

        public UserRepository ( ApplicationDbContext db )
            {
            this .db = db;
            }

        // Register User
        public int RegisterUser ( User user )
            {
            int result = 0;

            if ( !CheckIfUserExists(user .Email) )
                {
                db .Users .Add(user);
                result = db .SaveChanges();
                }
            return result;
            }

        // Login User
        public User LoginUser ( string email , string password )
            {
            return db .Users?.FirstOrDefault(u => u .Email == email && u .Password == password);
            }

        // Check if User exists by Email
        public bool CheckIfUserExists ( string email )
            {
            return db .Users?.Any(u => u .Email == email) ?? false;
            }

        // Get All Users
        public IEnumerable<User> GetAllUsers ()
            {
            return db .Users .ToList();
            }

        // Get User By ID
        public User GetUserById ( int id )
            {
            return db .Users?.FirstOrDefault(u => u .UserId == id);
            }

        // Get User By Email
        public User GetUserByEmail ( string email )
            {
            return db .Users?.FirstOrDefault(u => u .Email == email);
            }

        }
    }
