using RESTDemo .Data;
using RESTDemo .Model;


namespace RESTDemo .Repositories
    {
    public class BookRepository : IBookRepository
        {
        private readonly ApplicationDbContext db;
        public BookRepository ( ApplicationDbContext db )
            {
            this.db = db;
            }
        public int AddBook ( Book book )
            {
            int result=0;
            db.Books?.Add(book);
            result = db.SaveChanges();
            return result;
            }

        public int DeleteBook ( int id )
            {
            int result = 0;
            var b = db.Books?.Where(x => x .BookId == id) .FirstOrDefault();
            if ( b != null )
                {
                db .Books?.Remove(b);
                result = db .SaveChanges();
                }
            return result;
            }

    

        public IEnumerable<Book> GetBookByAuthor ( string name )
            {
            var model = db .Books?.Where(x => x .Author .Contains(name)) .ToList();
            return model;

            }

        public Book GetBookById ( int id )
            {
            return db .Books?.Where(x => x .BookId == id) .FirstOrDefault();
            }

    

        public IEnumerable<Book> GetBooks ()
            {
            return db .Books .ToList();
            }

        public int UpdateBook ( Book book )
            {
            int result = 0;
            var b = db .Books?.Where(x => x .BookId == book .BookId) .SingleOrDefault();
            if ( b != null )
                {
                db .Entry<Book>(b) .CurrentValues .SetValues(book);
                //    Console .WriteLine("Book found, updating...");
                //    b .BookName = book .BookName;
                //    b .Author = book .Author;
                //    b .Price = book .Price;
                result = db .SaveChanges();
                //    Console .WriteLine("Book updated successfully.");
                //    }
                //else
                //    {
                //    Console .WriteLine("Book not found.");
                }
            return result;
            }
        }
    }
