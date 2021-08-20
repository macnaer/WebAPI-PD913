using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Controllers;

namespace WebAPI_15.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks() => _context.Books.ToList();

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book UpdateBookById(int bookId, Book book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);

            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                //_book.Author = book.Author;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.ImageURL = book.ImageURL;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);

            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }

    }
}
