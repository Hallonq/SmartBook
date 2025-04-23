using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Library
{
    internal class Library
    {
        public List<Book> Books { get; set; }
        public Library()
        {
            Books = [];
        }
    }
}
