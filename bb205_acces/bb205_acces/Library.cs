using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb205_acces
{
    internal class Library
    {
        Book[] Books;
        public Library()
        {
            Books = new Book[0];
        }
        public void AddBook(Book book)
        {
            Book[] newBooks=new Book[Books.Length+1];
            for(int i=0; i<Books.Length; i++)
            {
                newBooks[i]=Books[i];
            }
            newBooks[newBooks.Length - 1] = book;
            Books = newBooks;
            
        }
        public Book GetBook(string name)
        {
            foreach(Book book in Books)
            {
                if(book.Name.ToLower() == name.ToLower())
                {
                    return book;
                }
            }
            return null;
        }
    }
}
