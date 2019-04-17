using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class BooksRepository : IBooksRepository<Book>
    {
        private readonly BookContext _dbContext;
        public BooksRepository(BookContext context)
        {
            _dbContext = context;
        }
        public async Task<Book> Get(long isbn)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(m => m.ISBN == isbn);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }
        public async Task Add(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Book book, Book entity)
        {
            book.ISBN = entity.ISBN;
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.YEAR = entity.YEAR;

            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        

       
    }
}
