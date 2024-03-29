using PotterApp.Common;
using PotterApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterApp.Model
{
    internal class BookSet
    {
        private readonly List<Book> books = new();
        private readonly DiscountService _discountService = new();

        public double Price
        {
            get
            {
                var discount = _discountService.GetDiscount(books.Count);
                return books.Sum(x => x.Price) * discount;
            }
        }

        public bool Exists(Book book)
        {
            return books.Any(x => x.BookType == book.BookType);
        }

        internal void Addbook(Book book)
        {
            books.Add(book);
        }

        internal void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        internal string PrintResult()
        {
            StringBuilder sb = new StringBuilder();
            foreach (BookType type in Enum.GetValues(typeof(BookType)))
            {
                string temp = books.Any(x => x.BookType == type) ? "1" : "0";
                sb.Append(temp + ", ");
            }
            return sb.ToString().TrimEnd(',');
        }
    }
}
