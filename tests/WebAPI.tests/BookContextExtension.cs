using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.tests
{
    public static class BookContextExtension
    {
        public static void FillDatabase(this BookContext dbContext)
        {
            dbContext.Books.Add
            (
                new Book
                {
                    ISBN = 123456,
                    Title = "Harry Potter",
                    Author = "J.K Rowling",
                    YEAR = 1991
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    ISBN = 654321,
                    Title = "Simple book",
                    Author = "Author",
                    YEAR = 2019
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    ISBN = 345123,
                    Title = "Mithology",
                    Author = "Neil Gaiman",
                    YEAR = 1999
                }
            );

            dbContext.Books.Add
              (
                  new Book
                  {
                      ISBN = 789654,
                      Title = "Lord of the rings",
                      Author = "Tolkien",
                      YEAR = 1972
                  }
              );

            dbContext.Books.Add
            (
                new Book
                {
                    ISBN = 111111,
                    Title = "Default book",
                    Author = "Default Author",
                    YEAR = 2015
                }
            );

            dbContext.SaveChanges();
        }
    }
}
