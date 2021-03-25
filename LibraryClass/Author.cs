using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public class Author
    {
        private string _name;
        private string _surname;
        private Book[] _books;
        private Publisher _publishers;
        private decimal _money;

        public Author()
        {
            _books = new Book[0];
            _publishers = new Publisher();
            _name ="Steven";
            _surname = "King";
            _money = 0;
        }
        public Author(string name, string surname):this()
        {
            Name = name;
            Surname = surname;
        }

        public Author(string name, string surname,Book book) : this(name,surname)
        {
            AddBook(book);
        }
        public Author(string name, string surname, Book book, Publisher publisher, decimal money):this(name,surname,book)
        {
            AddBook(book, publisher);
            Money += money;
        }
        public string Name { get => _name; init => _name = value; }
        public string Surname { get => _surname; init => _surname = value; }
        public Book[] Books { get => _books;  }
        
        public decimal Money { get => _money; set => _money = value > 0 ? value : throw new ArgumentException(); }
        public Publisher Publishers { get => _publishers; set => _publishers = value; }

        public void AddBook(Book book)
        {
            
            int oldSize = _books.Length;
            Array.Resize<Book>(ref _books, oldSize + 1);
            book.Author = this;
            Books[oldSize] = book;
        }
        public void AddBook(Book book, Publisher publisher)
        {
            AddBook(book);
            
            Publishers = publisher;
        }
        public void Royalty(decimal royalty)
        {
            if (royalty<0)
            {
                throw new ArgumentException();
            }
            Money += royalty;
        }
        public override string ToString()
        {
            string temp = $"{_name}\t{_surname}\t";
            foreach (var item in _books)
            {
                temp += item+"\t";
            }
            
           
            return temp;
        }
    }
}
