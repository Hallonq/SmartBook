using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Library
{
    internal class Library
    {
        private List<Book> books;
        public List<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
            }
        }
        public Library()
        {
            books = [];
        }
    }
}
