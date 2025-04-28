using SmartBook.Library;
using SmartBook.Library.Services;

namespace SmartBookTests
{
    public class BookTests
    {
        [Fact]
        public void Add_Book_To_List_Of_Type_Book()
        {
            // arrange
            BookService bs = new();
            Book testBook = new Book()
            {
                Title = "Test Book",
                Author = "Test Author",
                Isbn = 123456789,
                Category = (int)Book.CategoryType.ScienceFiction,
                Availability = true
            };

            // act
            bs.CreateBook(testBook);

            // assert
            Assert.Equal(testBook, bs.Library.Books[0]);
        }

        [Fact]
        public void Search_Book_By_Title()
        {
            // arrange
            BookService bs = new();
            bs.Library.Books.Add(new Book()
            {
                Title = "Test Book",
                Author = "Test Author",
                Isbn = 123456789,
                Category = (int)Book.CategoryType.ScienceFiction,
                Availability = true
            });

            // act
            Book foundBook = bs.GetBook("Test Book");

            // assert
            Assert.Equal(foundBook, bs.GetBook("Test Book"));
        }
    }
}
