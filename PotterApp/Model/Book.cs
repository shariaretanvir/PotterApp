using PotterApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterApp.Model
{
    public class Book
    {
        public double Price { get; private set; } = 8;
        public BookType BookType { get; }

        public Book(BookType type)
        {
            BookType = type;
        }
    }
}
