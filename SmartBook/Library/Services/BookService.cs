using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static SmartBook.Library.Book;

namespace SmartBook.Library.Services
{
    internal class BookService
    {
        private readonly string FilePath = $@"{Environment.CurrentDirectory}/library.json";
        public Library Library { get; set; }
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
            return Library.Books.Where(x => x.Title.Contains(searchInput) || x.Author.Contains(searchInput)).FirstOrDefault()!;
        }
        public string GetCategory(int id)
        {
            return Enum.GetName(typeof(CategoryType), id)!;
        }
        public string GetAvailability(bool status)
        {
            return Enum.GetName(typeof(AvailabilityType), status ? 1 : 0)!;
        }
        public void SetAvailability(Book book)
        {
            Library.Books.Where(x => book == x).SingleOrDefault()!.Availability = !book.Availability;
        }
        public bool DeleteBook(string titleOrIsbn)
        {
            if (Library.Books.RemoveAll(x => x.Title.Equals(titleOrIsbn, StringComparison.CurrentCultureIgnoreCase) || x.Isbn.ToString() == titleOrIsbn) > 0)
            {
                return true;
            }
            return false;
        }
        public string SaveAsJson()
        {
            return JsonSerializer.Serialize(Library);
        }
        public void LoadJson(string data)
        {
            Library = JsonSerializer.Deserialize<Library>(data)!;
        }
        public void WriteToFile(string data)
        {
            using StreamWriter sw = File.CreateText(FilePath);
            sw.WriteLine(data);
        }
        public string ReadFromFile()
        {
            using StreamReader sr = File.OpenText(FilePath);
            return sr.ReadToEnd();
        }
    }
}
