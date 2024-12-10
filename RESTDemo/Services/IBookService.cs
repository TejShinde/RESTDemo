using RESTDemo .Model;
using RESTDemo .Repositories;

namespace RESTDemo .Services
    {
    public interface IBookService
        {
        IEnumerable<Book> GetBooks ();
        Book GetBookById ( int id );
        IEnumerable<Book> GetBookByAuthor ( string name );
        int AddBook ( Book book );
        int UpdateBook ( Book book );
        int DeleteBook ( int id );
        }
    }
