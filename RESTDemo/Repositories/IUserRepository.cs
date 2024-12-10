using RESTDemo .Model;

namespace RESTDemo .Repositories
    {
    public interface IUserRepository
        {
        IEnumerable<User> GetAllUsers ();
        User GetUserById ( int id );
        User GetUserByEmail ( string email );
        int RegisterUser ( User user );
        User LoginUser ( string email , string password );
        bool CheckIfUserExists ( string email );
        }
    }
