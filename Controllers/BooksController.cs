using Books.Application.DTOs;
using Books.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService booksService;

        public BooksController(BooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDto)
        {
            var book = booksService.AddBook(bookDto);
            return Ok(book);
        }
 


        [HttpGet ("{id}")]

        public IActionResult GetBookById(Guid id)
        {
            var book = booksService.GetBookById(id);

            if (book == null)
            return NotFound("This Book was not found");

            return Ok(book);
        }


        [HttpGet]
        public IActionResult GetBooks(
            string? title,
            string? author,
            string? genre,
            int?    stock,
            bool?   isavailable)
        {
            var books = booksService.GetBooks(title, author, genre, stock, isavailable);
            return Ok (books);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] BookDTO bookDTO)
        {
            var updatedBook = booksService.UpdateBook(id, bookDTO);

            if (updatedBook == null)
            return NotFound("This Book was not found");

            return Ok(updatedBook);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBook(Guid id, [FromBody] BookPatchDTO bookPatchDTO)
        {
            var patchedBook = booksService.PatchBook(id, bookPatchDTO);

            if (patchedBook == null)
                return NotFound("This Book was not found");

            return Ok(patchedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var deleted = booksService.DeleteBook(id);

            if (!deleted)
                return NotFound("This Book was not found");

            return NoContent();
        }

    }
}