using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System.IO;

namespace LibraryManagement.Services
{
    public class Service
    {
        public Service()
        {
            rentedBooks = new List<Book>();
            ClosedRents = new List<Book>();
            _book = new Book();
            _member = new Member();
            _bookRepository = new BookRepository();
            _memberRepository = new MemberRepository();
        }
        public List<Book> rentedBooks { get; set; }
        public List<Book> ClosedRents { get; set; }
        public Book _book { get; set; }
        public Member _member { get; set; }
        public BookRepository _bookRepository { get; set; }

        public MemberRepository _memberRepository { get; set; }


        // BOOK SECTION //


        // Create Book

        public void CreateBook()
        {
            // book title
            Console.WriteLine("Enter Title: ");
            var bookTitle = Console.ReadLine();

            // number of copies

            Console.WriteLine("Enter numer of copies: ");
            var bookNumOfCop = int.Parse(Console.ReadLine());

            // New Object
            Book newBook = new Book(GenerateBookId(), bookTitle, bookNumOfCop, DateTime.Now);

            // Save that Object

            if (_bookRepository != null)
            {
                _bookRepository.Create(newBook);
                Console.WriteLine("");
                Console.WriteLine($"New book {newBook.Title} has been added.");
                Console.WriteLine("");
            }

        }

        public void DeleteBook()
        {
            if(_bookRepository.Database.Count > 0)
            {
                // List All books
                ShowAllBooks();

                // User to pick book
                Console.WriteLine("Please choose book ID that you want to delete");
                var userChoice = int.Parse(Console.ReadLine());

                // Get that BOOK FROM DB
                var selectedBook = _bookRepository.Database.FirstOrDefault(x => x.Id == userChoice);

                // Send the selected book to DB for deleting
                _bookRepository.Delete(selectedBook);
                Console.WriteLine($"The book {selectedBook.Title} has been deleted.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NO DATA AVAILABLE");
                Console.WriteLine("");
            }

        }

        public void ShowAllBooks()
        {
            // Going through BOOK DB to find books
            if(_bookRepository.Database.Count > 0)
            {
                foreach (var book in _bookRepository.Database)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ID: {book.Id} | Book Title: {book.Title} | Number of Copies: {book.NumOfCopies} ");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NO BOOKS AVILABLE");
                Console.WriteLine("");
            }

        }

        // ID Book
        private int GenerateBookId()
        {
            var newId = 0;
            if (_bookRepository.Database.Count > 0)
            {
                newId = _bookRepository.Database.Max(x => x.Id);
            }
            return newId + 1;
        }

        // Member Section //

        // Create Member

        public void CreateMember()
        {
            // Member Name
            Console.WriteLine("Enter member name: ");
            var memberName = Console.ReadLine();

            // Member Surname
            Console.WriteLine("Enter member surname: ");
            var memberSurname = Console.ReadLine();

            // Member Email
            Console.WriteLine("Enter member email");
            var memberEmail = Console.ReadLine();

            // Create Member Object
            Member newMember = new Member(GenerateMemberId(), memberName, memberSurname, memberEmail, DateTime.Now);


            // Send that object into Repository for saving
            if (_memberRepository != null)
            {
                _memberRepository.Create(newMember);
                Console.WriteLine("");
                Console.WriteLine($"New member {newMember.Name} has been created.");
                Console.WriteLine("");
            }

        }

        // View All members from DB

        public void ShowAllMembers()
        {
            // List all members from db
            if(_memberRepository.Database.Count > 0)
            {
                foreach(var member in _memberRepository.Database)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ID: {member.Id} | Name: {member.Name} | Surname {member.Surname} | Email: {member.Email} | Member since: {member.Date}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NO MEMBERS AVAILABLE");
                Console.WriteLine("");
            }
            
        }

        // Delete Member
        public void DeleteMember()
        {

            if(_memberRepository.Database.Count > 0)
            {
                // List All members
                ShowAllMembers();

                // User choice..
                Console.WriteLine("Please choose an ID member that you want to delete");
                var userChoice = int.Parse(Console.ReadLine());

                // Get that Member from DB
                var selectedMember = _memberRepository.Database.FirstOrDefault(x => x.Id == userChoice);

                // Send that member for be delete into Member Repository
                _memberRepository.Delete(selectedMember);
                Console.WriteLine("");
                Console.WriteLine($"Member {selectedMember.Name} has been deleted.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NO DATA AVIALABLE");
                Console.WriteLine("");
            }

        }


        // ID Member
        private int GenerateMemberId()
        {
            var newId = 0;
            if (_memberRepository.Database.Count > 0)
            {
                newId = _memberRepository.Database.Max(x => x.Id);
            }
            return newId + 1;
        }

        // RENT SECTION // 

        public void RentBook()
        {
            Console.WriteLine("");
            // Select member first by ID 
            ShowAllMembers();

            // User Choice
            Console.WriteLine("Please choose an member by his ID");
            var userChoice = int.Parse(Console.ReadLine());

            // Selected Member
            var selectedMember = _memberRepository.Database.FirstOrDefault(x => x.Id == userChoice); // WE GOT THE MEMBER

            // Show all books from _bookrepository
            ShowAllBooks();

            // Select Book
            Console.WriteLine("Please select book by its ID");
            var userBookSelect = int.Parse(Console.ReadLine());

            // User choose book
            var selectedBook = _bookRepository.Database.FirstOrDefault(x => x.Id == userBookSelect); // WE GOT THE BOOK
            selectedBook.NumOfCopies--;
            Console.WriteLine("");
            Console.WriteLine($"{selectedBook.Title} has {selectedBook.NumOfCopies} more copies");
            Console.WriteLine("");
            // Add the book to his books list
            selectedMember.Books = new List<Book> { selectedBook };
            Console.WriteLine("");
            Console.WriteLine($"{selectedMember.Name} rented {selectedBook.Title} book.");
            Console.WriteLine("!!! WE APPRECIATE YOUR BUSINESS!!!");
            Console.WriteLine("");

            rentedBooks.Add(selectedBook);
        }

        public void CloseRent()
        {
            Console.WriteLine("");
            var total = rentedBooks.Count;
            Console.WriteLine($"Total {total} books are rented.");
            foreach (var book in rentedBooks)
            {
                Console.WriteLine($"ID: {book.Id} | Title: {book.Title}");
            }

            // User picks book ID
            Console.WriteLine("Please choose an book ID");
            var userChoice = int.Parse(Console.ReadLine());

            // select that book
            var selectBook = rentedBooks.FirstOrDefault(x => x.Id == userChoice);

            // SHow all members
            ShowAllMembers();

            // Choose member
            Console.WriteLine("Please choose member by his ID");
            var chosenUser = int.Parse(Console.ReadLine());

            // Get the member from DB
            var selectedUser = _memberRepository.Database.FirstOrDefault(x => x.Id == chosenUser);

            selectedUser.Books.Remove(selectBook);
            Console.WriteLine("");
            Console.WriteLine($"The book {selectBook.Title} has been removed from {selectedUser.Name}");
            Console.WriteLine("");
            ClosedRents.Add(selectBook);

        }

        public void RentedBooks()
        {
            Console.WriteLine("");
            if (rentedBooks.Count > 0)
            {
                var total = rentedBooks.Count;
                Console.WriteLine($"Total {total} books are rented.");
                foreach(var book in rentedBooks)
                {
                    Console.WriteLine($"ID: {book.Id} | Title: {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("NO RENTED BOOKS");
            }

        }
        public void ClosedRentsBooks()
        {
            if(ClosedRents.Count > 0)
            {
                foreach(var closed in ClosedRents)
                {
                    Console.WriteLine($"ID {closed.Id} Title {closed.Title}");
                }
            }
            
        }
    }
}
