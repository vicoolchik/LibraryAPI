using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LibraryAPI.Validation;
using LibraryApplication.DTOs;
using LibraryApplication.Interfaces;
using LibraryApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<SaveBookDTO> _saveBookValidator;
        private readonly IValidator<ReviewDTO> _reviewValidator;
        private readonly IValidator<int> _ratingValidator;

        public BooksController(IBookService bookService, IValidator<int> ratingValidator, IValidator<SaveBookDTO> saveBookValidator, IValidator<ReviewDTO> reviewValidator)
        {
            _bookService = bookService;
            _saveBookValidator = saveBookValidator;
            _reviewValidator = reviewValidator;
            _ratingValidator = ratingValidator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all books", Description = "Returns a list of all books in the library.")]
        [SwaggerResponse(200, "List of books", typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] string order = "title")
        {
            var books = await _bookService.GetAllBooksAsync(order);
            return Ok(books);
        }

        [HttpGet("recommended")]
        [SwaggerOperation(Summary = "Get recommended books", Description = "Returns a list of top-rated books in the specified genre.")]
        [SwaggerResponse(200, "List of recommended books", typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> GetTopRatedBooksAsync([FromQuery] string genre = "")
        {
            var books = await _bookService.GetTopRatedBooksAsync(genre);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get book details", Description = "Returns details of the book with the specified ID.")]
        [SwaggerResponse(200, "Book details", typeof(BookDetailsDTO))]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> GetBookDetailsAsync(int id)
        {
            var book = await _bookService.GetBookDetailsAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a book", Description = "Deletes the book with the specified ID.")]
        [SwaggerResponse(204, "Book deleted")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> DeleteBookAsync(int id, [FromQuery] string secret)
        {
            var result = await _bookService.DeleteBookAsync(id, secret);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("save")]
        [SwaggerOperation(Summary = "Save a book", Description = "Saves a new book to the library.")]
        [SwaggerResponse(200, "Book ID", typeof(int))]
        public async Task<IActionResult> SaveBookAsync([FromBody] SaveBookDTO book)
        {
            var validationResult = _saveBookValidator.Validate(book);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _bookService.SaveBookAsync(book);
            return Ok(new { Id = result });
        }

        [HttpPut("{id}/review")]
        [SwaggerOperation(Summary = "Add a review", Description = "Adds a new review to the book with the specified ID.")]
        [SwaggerResponse(200, "Review ID", typeof(int))]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> AddReviewAsync(int id, [FromBody] ReviewDTO review)
        {
            var validationResult = _reviewValidator.Validate(review);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _bookService.AddReviewAsync(id, review);
            return Ok(new { Id = result });
        }

        [HttpPut("{id}/rate")]
        [SwaggerOperation(Summary = "Add a rate", Description = "Adds a new rate to the book with the specified ID.")]
        [SwaggerResponse(200, "Rate ID", typeof(int))]
        [SwaggerResponse(404, "Book not found")]
        public async Task<IActionResult> AddRatingAsync(int id, [FromBody] int score)
        {
            var validationResult = _ratingValidator.Validate(score);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _bookService.AddRatingAsync(id, score);
            return Ok(new { Id = result });
        }
    }
}

