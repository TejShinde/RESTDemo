using RESTDemo .Data;
using RESTDemo .Model;

namespace RESTDemo .Repositories
    {
    public class StudentRepository : IStudentRepository
        {
        private readonly ApplicationDbContext db;
        public StudentRepository ( ApplicationDbContext db )
            {
            this .db = db;

            }
        public int AddStudent ( Student student )
            {
            int result = 0;
            db .Students?.Add(student);
            result = db .SaveChanges();
            return result;
            }

        public int DeleteStudent ( int id )
            {
            int result = 0;
            var s = db .Students?.Where(x => x .StudentId == id) .FirstOrDefault();
            if ( s != null )
                {
                db .Students?.Remove(s);
                result = db .SaveChanges();
                }
            return result;
            }

        public Student GetStudentById ( int id )
            {
            //return db.Students?.Where(x => x.StudentId == id).SingleOrDefault();
            return db .Students?.Where(x => x .StudentId == id) .FirstOrDefault();
            }

        public IEnumerable<Student> GetStudentByName ( string name )
            {
            var model = db .Students?.Where(x => x .Name .Contains(name)) .ToList();
            return model;
            }

        public IEnumerable<Student> GetStudents ()
            {
            return db .Students .ToList();
            }

        public int UpdateStudent ( Student student )
            {
            int result = 0;
            var s = db .Students?.Where(x => x .StudentId == student .StudentId) .FirstOrDefault();
            if ( s != null )
                {
                s .Name = student .Name;
                s .Email = student .Email;
                s .Grade = student .Grade;
               // db .Entry(student) .State = Microsoft .EntityFrameworkCore .EntityState .Modified;
                result = db .SaveChanges();
                }
            return result;
            }

       
        }
    }
