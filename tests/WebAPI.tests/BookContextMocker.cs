using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.DbContexts;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.tests
{
    public static class BookContextMocker
    {
        public static IBooksRepository<Book> GetInMemoryBooksRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            BookContext bookContext = new BookContext(options);
            bookContext.FillDatabase();

            return new BooksRepository(bookContext);
        }
    }
}
