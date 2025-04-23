using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static SmartBook.Library.Book;

namespace SmartBook.Library.Services
{
    internal class BookService
    {
        public Library Library { get; set; }
        private Book LastSearchedBook { get; set; }
        public BookService()
        {
            Library ??= new Library();
        }
        public void CreateBook(Book book)
        {
            Library.Books.Add(book);
        }
        public List<Book> GetBooks()
        {
            return Library.Books.OrderBy(x => x.Title).ToList();
        }
        public Book GetBook(string searchInput)
        {
            Book result = Library.Books.Where(x => x.Title.Contains(searchInput) || x.Author.Contains(searchInput)).SingleOrDefault()!;
            LastSearchedBook = result;
            return result;
        }
        public string GetCategory(int id)
        {
            return Enum.GetName(typeof(CategoryType), id)!;
        }
        public string GetAvailability(bool status)
        {
            return Enum.GetName(typeof(AvailabilityType), status)!;
        }
        public void SetAvailability(bool status)
        {
            LastSearchedBook.Availability = status;
        }
        public bool DeleteBook(string titleOrIsbn)
        {
            if (Library.Books.Remove(Library.Books.FirstOrDefault(x => x.Title == titleOrIsbn || x.Isbn == int.Parse(titleOrIsbn))!))
            {
                return true;
            }
            return false;
        }
    }
}
