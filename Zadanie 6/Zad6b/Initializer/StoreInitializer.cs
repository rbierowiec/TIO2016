using System.Collections.Generic;
using Zad6b.Context;
using Zad6b.Models;

namespace Zad6b.Initializer
{
    public class StoreInitializer : System.Data.Entity.CreateDatabaseIfNotExists<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>()
            {
                new Book() { BookTitle = "The C Programming Language", ISBN = "9780131103627"},
                new Book() { BookTitle = "C# 6.0 and the .NET 4.6 Framework", ISBN = "9781484213339"}
            };

            books.ForEach(i => context.Books.Add(i));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() { AuthorName = "Philip", AuthorSurname="Japikse"},
                new Author() { AuthorName = "Brian", AuthorSurname="W. Kernighan"}
            };

            authors.ForEach(g => context.Authors.Add(g));
            context.SaveChanges();
        }
    }
}