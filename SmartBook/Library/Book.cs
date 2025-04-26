using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Library
{
    internal class Book
    {
        private string title;
        private string author;
        private int isbn;
        private int category;
        private bool availability = false;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Isbn
        {
            get { return isbn; }
            set
            {
                if (value > 0)
                    isbn = value;
            }
        }
        public int Category
        {
            get { return category; }
            set { category = value; }
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
