using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheBookApp;
using TheBookApp.Models;

namespace TheBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/Publisher
        [HttpGet]
       public IActionResult GetAllPubulisher(){
        var publishers = _publisherService.GetAllPublishers();
        return Ok(publishers);
       }

        // GET: api/Publisher/5
        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id){
            var publisher = _publisherService.GetPublisherById(id);
            if(publisher is null){
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] Publisher publisher){
            if(publisher is null){
                return BadRequest("Publisher Object is null");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            _publisherService.AddPublisher(publisher);
            return CreatedAtAction(nameof(GetPublisherById), new{id=publisher.Id}, publisher);
        }

        // PUT: api/Publisher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] Publisher publisher){
            if(publisher is null || publisher.Id != id){
                return BadRequest();
            }
            var existingPublisher = _publisherService.GetPublisherById(id);
            if(existingPublisher is null){
                return NotFound();
        
            }
            _publisherService.UpdatePublisher(publisher);
            return NoContent();
        }


        // DELETE: api/Publisher/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {   var publisher = _publisherService.GetPublisherById(id);
            if(publisher is null){
                return NotFound();
            }
            _publisherService.DeletePublisher(id);
            return NoContent();
        }
        
        // [HttpGet("{id}/book")]
        // public IActionResult GetBooks(int id){
        //     var books = _publisherService.GetBooksByPublisher(id);

        //     if(books is null){
        //         return NotFound();
        //     }

        //     return Ok(books);
        // }
        
    }
}
