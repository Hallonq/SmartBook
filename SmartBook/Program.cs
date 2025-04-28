using SmartBook.Library;
using SmartBook.Library.Services;
using System;

namespace SmartBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookService bs = new();
            bool exit = false;
            do
            {
                // meny
                Console.Clear();
                Console.WriteLine("SmartBook");
                Console.WriteLine("(1) add book");
                Console.WriteLine("(2) remove book");
                Console.WriteLine("(3) list all books");
                Console.WriteLine("(4) search");
                Console.WriteLine("(5) mark book as rented or available");
                Console.WriteLine("(6) save library as json");
                Console.WriteLine("(7) read library from json");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (input)
                {
                    case '1': // add book
                        try
                        {
                            Console.WriteLine("Title: ");
                            string title = Console.ReadLine()!;
                            Console.WriteLine("Author: ");
                            string author = Console.ReadLine()!;
                            Console.WriteLine("ISBN: ");
                            int isbn = int.Parse(Console.ReadLine()!);
                            Console.WriteLine("Category: ");
                            string[] categories = Enum.GetNames(typeof(Book.CategoryType));
                            for (int i = 0; i < categories.Length; i++)
                            {
                                Console.WriteLine($"[{i}]: {categories[i]}");
                            }
                            int category = int.Parse(Console.ReadLine()!);
                            bs.CreateBook(new Book()
                            {
                                Title = title,
                                Author = author,
                                Isbn = isbn,
                                Category = category,

                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '2': // remove book
                        try
                        {
                            Console.WriteLine("Remove book by title or ISBN");
                            string deleteBookInput = Console.ReadLine()!;
                            if (bs.DeleteBook(deleteBookInput))
                            {
                                Console.WriteLine("Book deleted");
                            }
                            else
                            {
                                Console.WriteLine("No changes made");
                            }
                            MenuSupport();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '3': // getbooks with linq
                        try
                        {
                            foreach (Book book in bs.GetBooks())
                            {
                                BookInfo(book, bs);
                            }
                            MenuSupport();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case '4': // search book
                        try
                        {
                            Console.WriteLine("Search on title or author");
                            string searchBookInput = Console.ReadLine()!;
                            if (string.IsNullOrEmpty(searchBookInput))
                            {
                                Console.WriteLine("Search input cannot be empty");
                            }
                            Book searchedBook = bs.GetBook(searchBookInput);
                            BookInfo(searchedBook, bs);
                            MenuSupport();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '5': // mark enum "rented" or "available"
                        try
                        {
                            Console.WriteLine("Change book availability status, write isbn of book");
                            foreach (Book book in bs.GetBooks())
                            {
                                BookInfo(book, bs);
                            }
                            if (int.TryParse(Console.ReadLine()!, out int isbn))
                            {
                                Book book = bs.Library.Books.Where(x => x.Isbn == isbn).SingleOrDefault()!;
                                bs.SetAvailability(book);
                                Console.WriteLine($"Book: {book.Title} availability status changed to {bs.GetAvailability(book.Availability)}");
                                MenuSupport();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case '6': // save library as json and load library from json
                        Console.WriteLine("writing tojson...");
                        try
                        {
                            bs.WriteToFile(bs.SaveAsJson());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '7': // read library from json
                        Console.WriteLine("reading from json...");
                        try
                        {
                            bs.LoadJson(bs.ReadFromFile());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
            while (!exit);
        }

        private static void BookInfo(Book book, BookService bs)
        {
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"ISBN: {book.Isbn}");
            Console.WriteLine($"Category: {bs.GetCategory(book.Category)}");
            Console.WriteLine($"Availability: {bs.GetAvailability(book.Availability)}\n");
        }

        private static void MenuSupport()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}