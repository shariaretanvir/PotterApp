using PotterApp.Common;
using PotterApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterApp.Service
{
    public class BookBasketService
    {
        private readonly List<BookSet> _bookSets = new();

        public double BasketPrice
        {
            get
            {
                return _bookSets.Sum(x => x.Price);
            }
        }

        public void AddBooks(BookType bookType, int quantity)
        {
            for (int i = 1; i <= quantity; i++)
            {
                var book = new Book(bookType);
                var probableBaskets = _bookSets.Where(x => !x.Exists(book));

                if (probableBaskets.Any())
                {
                    BookSet addedBookSet = AddAppropriateBasket(probableBaskets, book);
                    addedBookSet.Addbook(book);
                }
                else
                {
                    var bookSet = new BookSet();
                    bookSet.Addbook(book);
                    _bookSets.Add(bookSet);
                }
            }
        }

        private BookSet AddAppropriateBasket(IEnumerable<BookSet> probableBaskets, Book book)
        {
            var tempBookSet = new BookSet();
            double totalPrice = double.MaxValue;

            foreach (var bookSet in probableBaskets)
            {
                bookSet.Addbook(book);
                
                if(BasketPrice < totalPrice)
                {
                    totalPrice = BasketPrice;
                    tempBookSet = bookSet;
                }
                bookSet.RemoveBook(book);
            }
            return tempBookSet;
        }

        public string PrintBasket()
        {
            StringBuilder result = new StringBuilder();

            foreach (var bookSet in _bookSets)
            {
                result.Append(bookSet.PrintResult()).Append("\n");

            }
            return result.ToString();
        }
    }
}
