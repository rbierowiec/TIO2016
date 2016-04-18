using System;
using System.Collections.Generic;
using Library1;

namespace AuthorManager
{
    public interface IService1
    {
        List<Author> GetAllAuthors();
        int Add(Author author);
        Author getAuthor(int id);
        Author Update(Author second);
        bool Delete(int id);
    }
}
