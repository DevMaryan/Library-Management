using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository
    {
        public BookRepository()
        {
            Database = new List<Book>();
            Rented_books = new List<Book>();
        }
        public List<Book> Rented_books { get; set; }
        public List<Book> Database { get; set; }

        // Add book into DB
        public void Create(Book newBook)
        {
            Database.Add(newBook);
        }

        // Remove book from DB
        public void Delete(Book selectedBook)
        {
            Database.Remove(selectedBook);
        }
    }
}
