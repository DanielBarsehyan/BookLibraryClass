using System;

namespace LibraryClass
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Author a = new Author(" AUTHOR ", "1");
            Author a1 = new Author(" AUTHOR ", "2");
            Book b = new Book(a," BOOK  ","1",100,Geners.Horror);
            Book b1 = new Book(a1, "BOOK ", "2", 12, Geners.Horror);
            
            
            Publisher p = new Publisher("BookWaker",2.3m);
            Book b3 = new Book(a, " BOOK  ", "3", 4, Geners.Horror);
            
            

            p.AddAuthor(a);
            a.AddBook(b);
            

            p.AddBook(b1);
            p.AddAuthor(a1);



            p.SellBook(24, b3);
            p.SellBook(12, p.Books[0]);


            Console.WriteLine(b.ToString());
            Console.WriteLine(a.ToString());
            Console.WriteLine(b1.ToString());
            Console.WriteLine(a1.ToString());
            Console.WriteLine(p.ToString());
        }
    }
}
