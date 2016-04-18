using System;
using System.Collections.Generic;
using Library1;

namespace BookManager
{
    public interface IService1
    {
        List<Book> GetAllBooks();
        int Add(Book book);
        Book getBook(int id);
        Book Update(Book second);
        bool Delete(int id);
    }
}
