using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Library
{
    public class Book
    {
        private string title;
        private string author;
        private int isbn;
        private int category;
        private bool availability = false;
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("title cannot be empty or null");
                title = value;
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("author cannot be empty or null");
                author = value;
            }
        }
        public int Isbn
        {
            get { return isbn; }
            set
            {
                if (value <= 0)
                    throw new Exception("ISBN must be a positive number.");

                isbn = value;
            }
        }
        public int Category
        {
            get { return category; }
            set
            {
                if (!Enum.IsDefined(typeof(CategoryType), value))
                    throw new Exception("Invalid category.");

                category = value; // behövs??? funkade utan
            }
        }
        public enum CategoryType
        {
            ScienceFiction,
            Fantasy,
            Horror,
            Mystery,
            Autobiography
        }
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
        public enum AvailabilityType
        {
            Available,
            Rented
        }
        public Book()
        {
            title = string.Empty;
            author = string.Empty;
        }
    }
}
