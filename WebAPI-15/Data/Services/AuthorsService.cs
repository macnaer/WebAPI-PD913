using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Controllers;
using WebAPI_15.Data.Models;
using WebAPI_15.Data.ViewModels;

namespace WebAPI_15.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public Author AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();

            return _author;
        }

        public AuthorWithBookVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBookVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
