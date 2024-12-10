using Microsoft .AspNetCore .Mvc;
using RESTDemo .Model;
using RESTDemo .Services;

namespace RESTDemo .Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
        {
        private readonly IBookService service;
        public BookController ( IBookService service )
            {
            this .service = service;
            }
        // localhost:3553/api/Book/GetBooks
        [HttpGet]
        [Route("GetBooks")]
        public IActionResult Get ()
            {
            try
                {
                var model = service .GetBooks();
                return new ObjectResult(model);
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status204NoContent , ex .Message);
                }
            }

        // GET api/Book/GetBookById/5
        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult Get ( int id )
            {
            try
                {
                var model = service .GetBookById(id);
                if ( model != null )
                    {
                    return new ObjectResult(model);
                    }
                else
                    {
                    return StatusCode(StatusCodes .Status204NoContent);
                    }
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }
        [HttpGet]
        [Route("GetBookByAuthor/{name}")]
        public IActionResult Get ( string name )
            {
            try
                {
                var model = service .GetBookByAuthor(name);
                if ( model != null )
                    {
                    return new ObjectResult(model);
                    }
                else
                    {
                    return StatusCode(StatusCodes .Status204NoContent);
                    }
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult Post ( [FromBody] Book book )
            {
            try
                {
                var res = service.AddBook(book);
                if ( res >= 1 )
                    {
                    return StatusCode(StatusCodes .Status201Created);
                    }
                else
                    {
                    return StatusCode(StatusCodes .Status500InternalServerError);
                    }

                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex.Message);
                }
            }
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult Put ( [FromBody] Book book )
            {
            try
                {
                var res = service .UpdateBook(book);
                if ( res >= 1 )
                    {
                    return StatusCode(StatusCodes .Status200OK , "Book updated successfully.");
                    }
                else
                    {
                   // return StatusCode(StatusCodes .Status500InternalServerError);
                    return StatusCode(StatusCodes .Status500InternalServerError , "Book not found.");
                    }

                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult Delete ( int id )
            {
            try
                {
                var res = service .DeleteBook(id);
                if ( res >= 1 )
                    {
                    return StatusCode(StatusCodes .Status200OK);
                    }
                else
                    {
                    return StatusCode(StatusCodes .Status500InternalServerError);
                    }

                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }
        }
    }
