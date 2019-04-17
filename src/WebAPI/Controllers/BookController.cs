using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBooksRepository<Book> _booksRepository;

        public BookController(IBooksRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksRepository.GetAll();
            return Ok(books);
        }
        [HttpGet("{isbn}", Name = "Get")]
        public async Task<IActionResult> Get(long isbn)
        {
            var book = await _booksRepository.Get(isbn);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _booksRepository.Add(book);

            if (book == null)
            {
                return NotFound("The Book record could not be found");
            }

            return CreatedAtAction(nameof(Get), new { ISBN = book.ISBN }, book);
        }

        [HttpPut("{isbn}")]
        public async Task<IActionResult> Put(long isbn, Book book)
        {
            var bookToUpdate = await _booksRepository.Get(isbn);
            await _booksRepository.Update(bookToUpdate, book);

            if (book == null)
            {
                return NotFound("The Book record could not be found");
            }

            return NoContent();
        }

        [HttpDelete("{isbn}")]
        public async Task<IActionResult> Delete(long isbn, Book book)
        {
            var bookToDelete = await _booksRepository.Get(isbn);
            await _booksRepository.Delete(bookToDelete);

            if (book == null)
            {
                return NotFound("The Book record could not be found");
            }

            return NoContent();
        }
    }
}
