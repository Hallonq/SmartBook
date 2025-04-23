using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Library
{
    internal class Book
    {
        private string _title;
        private string _author;
        private int _isbn;
        private int _category;
        private bool _availability;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public int Isbn
        {
            get { return _isbn; }
            set
            {
                if (value > 0)
                    _isbn = value;
            }
        }
        public int Category
        {
            get { return _category; }
            set { _category = value; }
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
            get { return _availability; }
            set { _availability = value = true ? _availability = true : _availability = false; }
        }
        public enum AvailabilityType
        {
            Available,
            Rented
        }
        public Book()
        {
            _title = string.Empty;
            _author = string.Empty;
        }
    }
}
