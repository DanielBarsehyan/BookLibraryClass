using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public enum Geners
    {
        Comedy,
        Horror,
        Scy_Fi,
        Fantasy,
        Documentary
    }
    public class Book
    {
        private string _text;
        private short _pages;
        private string _name;
        private decimal _price;
        private Geners _geners;
        private Publisher _publisher;
        private Author _author;
        public Book()
        {
            _text = "Hello World!";
            _pages = 1;
            _geners = Geners.Comedy;
            _price = 1;
            _name = "How To learn c++ in 21 days";           
            _publisher = new Publisher();
            _author = new Author();
        }
        public Book(Author author, string text):this()
        {
            Author = author;
            Text = text;
            author.AddBook(this);
        }
        public Book(Author author,string text, string name):this(author,text)
        {           
            Name = name;
        }
        public Book(Author author, string text, string name, short pages) : this(author, text, name)
        {
            Pages = pages;

        }
        public Book(Author author,string text, string name, short pages, Geners gener):this(author,text,name,pages)
        {
            Geners = gener;
        }
        public Book(Author author,string text, string name,  short pages, Geners gener, Publisher publisher): this(author,text,name,pages,gener)
        {
            Publisher = publisher;
        }
        public Book(Author author, string text, string name, short pages, Geners gener, Publisher publisher,decimal price) : this(author, text, name, pages, gener,publisher)
        {
            Price = price;
        }
        public string Text { get => _text; set => _text = value; }
        public short Pages { get => _pages; set => _pages = value>0? value: throw new ArgumentException(); }
        public string Name { get => _name; set => _name = value; }
        public Geners Geners { get => _geners; set => _geners = value; }
        public Publisher Publisher { get => _publisher; set => _publisher = value; }
        public Author Author { get => _author; set => _author = value; }
        public decimal Price { get => _price; set => _price = value > 0 ? value : throw new ArgumentException(); }

        public override string ToString()
        {
            string temp=$"{_name}\t{_text}\t{_geners}\t{_pages}\t{_price}";
            return temp;
        }
    }
    
}
