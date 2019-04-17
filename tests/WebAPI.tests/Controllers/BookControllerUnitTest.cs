using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;
using Xunit;
namespace WebAPI.tests.Controllers
{
    public class BookControllerUnitTest
    {
        [Fact]
        public async Task get_all_books()
        {
       
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_all_books));
            var controller = new BookController(repository);

         
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

          
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, books.Count);
        }

        [Fact]
        public async Task get_book_with_existing_isbn()
        {
          
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_existing_isbn));
            var controller = new BookController(repository);
            var expectedValue = "Harry Potter";

            var response = await controller.Get(123456) as ObjectResult;
            var book = response.Value as Book;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, book.Title);
        }
        [Fact]
        public async Task get_book_with_not_existing_isbn()
        {

            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_not_existing_isbn));
            var controller = new BookController(repository);

            var response = await controller.Get(1234567) as ObjectResult;
            var book = response.Value as Book;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(null, book);
        }

    }
}
