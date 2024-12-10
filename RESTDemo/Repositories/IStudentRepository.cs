using RESTDemo .Model;

namespace RESTDemo .Repositories
    {
    public interface IStudentRepository
        {
        IEnumerable<Student> GetStudents ();
        Student GetStudentById ( int id );
        IEnumerable<Student> GetStudentByName ( string name );
        int AddStudent ( Student student );
        int UpdateStudent ( Student student );
        int DeleteStudent ( int id );
        }
    }
