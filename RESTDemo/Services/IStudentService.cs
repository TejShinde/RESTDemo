using RESTDemo .Model;

namespace RESTDemo .Services
    {
    public interface IStudentService
        {
        IEnumerable<Student> GetStudents ();

        Student GetStudentById ( int id );
        IEnumerable<Student> GetStudentByName ( string name );
        int AddStudent ( Student student );
        int UpdateStudent ( Student student );
        int DeleteStudent ( int id );
        }
    }
