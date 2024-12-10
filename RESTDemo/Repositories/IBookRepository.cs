using RESTDemo .Model;

namespace RESTDemo .Repositories
    {
    public interface IBookRepository
        {
        IEnumerable<Book> GetBooks ();
        Book GetBookById ( int id );
        IEnumerable<Book> GetBookByAuthor (string name);
        int AddBook ( Book book );
        int UpdateBook ( Book book );
        int DeleteBook ( int id );
       
        }
    }
