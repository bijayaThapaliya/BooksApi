using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using TheBookApp;

namespace TheBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService){
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks(){
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{Id}")]
        public IActionResult GetBookById(int Id){
            var book = _bookService.GetBookById(Id);

            if (book is null){
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book){
            if(book is null){
                return BadRequest("Book is null");
            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new {id = book.Id}, book );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book){
            if(book is null || book.Id != id){
                return BadRequest();
            }    

            var existingBook = _bookService.GetBookById(id);
            if(existingBook is null){
                return NotFound();
            }
            _bookService.UpdateBook(book);
            return NoContent();
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);
            return NoContent();
        }
        [HttpGet("{id}/publisher")]
        public IActionResult GetPublisherOfBook(int id){
            var publishers = _bookService.GetPublisherOfBook(id);
            if(publishers is null){
                return NotFound();
            }

            return Ok(publishers);
        }
    }
}
