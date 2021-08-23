using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Data.Services;
using WebAPI_15.Data.ViewModels;

namespace WebAPI_15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorVM author)
        {
            var newAuthor = _authorsService.AddAuthor(author);
            return Created(nameof(AddAuthor), newAuthor);
        }

        [HttpGet("get-author-with-book/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var _books = _authorsService.GetAuthorWithBooks(id);
            if(_books != null)
            {
                return Ok(_books);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
