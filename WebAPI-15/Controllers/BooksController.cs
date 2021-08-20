using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Data;
using WebAPI_15.Data.Services;
using WebAPI_15.Data.ViewModels;

namespace WebAPI_15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book-with-autors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] Book book)
        {
            var updatedBook = _bookService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
