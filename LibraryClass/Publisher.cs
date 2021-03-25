using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public class Publisher
    {
        private Book[] _books;
        private Author[] _authors;
        private string _publisherName;
        private decimal _money;
        private int[] _soldBooks;

        public Publisher()
        {
            _authors = new Author[0];
            _books = new Book[0];
            _publisherName = "BookSeller";
            _money = 0;
            _soldBooks = new int[0];

        }
        public Publisher(string name):this()
        {
            PublisherName = name;
        }

        public Publisher(string name,decimal money):this(name)
        {
            Money = money;
        }
        public Publisher(string name, decimal money, Author author) : this(name, money)
        {
            AddAuthor(author);
        }
        public Publisher(string name, decimal money, Author author,int soldBooks) : this(name, money, author)
        {
            
        }
        public void AddAuthor(Author author)
        {
            int oldSizeAuthor = Authors.Length;
            Array.Resize<Author>(ref _authors, oldSizeAuthor + 1);
            author.Publishers = this;
            Authors[oldSizeAuthor] = author;           
            
        }
        public void AddBook(Book book)
        {
            int oldSize = _books.Length;
            Array.Resize<Book>(ref _books, oldSize + 1);
            book.Publisher = this;
            Books[oldSize] = book;

            Array.Resize<int>(ref _soldBooks, oldSize + 1);
        }
        public void SellBook(int sell, Book book)
        {
            if(sell<1) throw new ArgumentException();
            int i = 0;
            foreach (var item in _books)
            {
                if (item == book)
                {
                    _soldBooks[i] += sell ;
                    Money += sell * book.Price;
                    book.Author.Royalty(sell*0.1m * book.Price);
                }
                i++;
            }        
        }

        public override string ToString()
        {
            string temp = $"{_publisherName}\t{_money}\t{_soldBooks}\t";
            foreach (var item in _authors)
            {
                temp += item + "\t";
            }
            foreach (var item in _books)
            {
                temp += item + "\t";
            }
            return temp;
        }

        public Book[] Books { get => _books; set => _books = value; }
        public Author[] Authors { get => _authors; set => _authors = value; }
        public string PublisherName { get => _publisherName; set => _publisherName = value; }
        public decimal Money { get => _money; set => _money = value > 0 ? value : throw new ArgumentException(); }
        public int[] SoldBooks { get => _soldBooks; }
    }
}
