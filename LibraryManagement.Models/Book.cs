using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumOfCopies { get; set; }

        public DateTime Date { get; set; }

        public Book(int id, string title, int numofcopies, DateTime date)
        {
            Id = id;
            Title = title;
            NumOfCopies = numofcopies;
            Date = date;
        }

        public Book()
        {

        }

    }
}
