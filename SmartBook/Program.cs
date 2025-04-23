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
                            Console.ReadKey();
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
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case '4': // search book
                        try
                        {
                            Console.WriteLine("Search...");
                            string searchBookInput = Console.ReadLine()!;
                            Book searchedBook = bs.GetBook(searchBookInput);
                            BookInfo(searchedBook, bs);
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '5': // mark enum "rented" or "available"
                        Console.WriteLine("Set last searched book rent status");
                        int temp = int.Parse(Console.ReadLine()!);
                        bool availableInput = Convert.ToBoolean(temp);
                        bs.SetAvailability(availableInput); // book marked cw
                        break;


                        // save library as json and load library from json
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
    }
}