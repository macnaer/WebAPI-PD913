using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publishersService;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            _logger.LogInformation($"sortBy: {sortBy}\tsearchString: {searchString}\tpageNumber: {pageNumber}");
            if (!string.IsNullOrEmpty(sortBy))
            {

            }

            var allPublishers = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
            return Ok(allPublishers);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _publisher = _publishersService.GetPublisherById(id);
            if (_publisher != null)
            {
                return Ok(_publisher);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _allPublisherData = _publishersService.GetPublisherData(id);
            if (_allPublisherData != null)
            {
                return Ok(_allPublisherData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
