using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Controllers;
using WebAPI_15.Data.Models;
using WebAPI_15.Data.Paging;
using WebAPI_15.Data.ViewModels;

namespace WebAPI_15.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var allPublishers = _context.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }


            if (!string.IsNullOrEmpty(searchString))
            {
                allPublishers = allPublishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            int pageSize = 6;
            allPublishers = PaginationList<Publisher>.Create(allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return allPublishers;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id); 

        public PublisherWithBooksAndAuthors GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthors()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Publisher with id {id} not found.");
            }
        }
    }
}
