using PotterApp.Common;
using PotterApp.Service;

namespace PotterApp.Tests
{
    public class BookBasketServiceTests
    {
        [Theory]
        [InlineData(1 * 8, new int[5] { 1, 0, 0, 0, 0 })]
        [InlineData(2 * 8 * 0.95, new int[5] { 1, 1, 0, 0, 0 })]
        [InlineData(3 * 8 * 0.9, new int[5] { 1, 1, 1, 0, 0 })]
        [InlineData(4 * 8 * 0.8, new int[5] { 1, 1, 1, 1, 0 })]
        [InlineData(5 * 8 * 0.75, new int[5] { 1, 1, 1, 1, 1 })]
        public void BookBasketService_AddBooks_SingleBasketDiscount_ShouldEqual(double actual, int[] bookTypes)
        {
            //arrange
            BookBasketService bookBasket = new();

            //act
            for (int i = 1; i <= bookTypes.Length; i++)
            {
                bookBasket.AddBooks((BookType)(i), bookTypes[i - 1]);
            }
            double result = bookBasket.BasketPrice;

            //assert
            Assert.Equal(actual, result);
        }


        [Theory]
        [InlineData(4 * 8 * 0.8 + 4 * 8 * 0.8 + 1 * 8, new int[5] { 2, 2, 3, 1, 1 })]
        public void BookBasketService_AddBooks_MultipleBasketDiscount_ShouldEqual(double actual, int[] bookTypes)
        {
            //arrange
            BookBasketService bookBasket = new();

            //act
            for (int i = 1; i <= bookTypes.Length; i++)
            {
                bookBasket.AddBooks((BookType)(i), bookTypes[i - 1]);
            }
            double result = bookBasket.BasketPrice;

            //assert
            Assert.Equal(actual, result);
        }
    }
}