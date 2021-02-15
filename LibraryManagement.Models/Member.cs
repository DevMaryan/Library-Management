using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; set; }
        public DateTime Date { get; set; }



        public Member(int id, string name, string surname, string email, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Date = date;
        }
        public Member(int id, string name, string surname, string email, List<Book> books, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Date = date;
            Books = books;
        }

        public Member()
        {

        }
    }
}
