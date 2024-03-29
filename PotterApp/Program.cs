// See https://aka.ms/new-console-template for more information
using PotterApp.Common;
using PotterApp.Service;

bool startOver = true;
while (startOver)
{
    BookBasketService basketService = new();

    foreach (BookType type in Enum.GetValues(typeof(BookType)))
    {
        Console.Write($"Please provide {type} quantity : ");
        string input = Console.ReadLine();

        if(int.TryParse(input, out int validQuantity))
        {
            basketService.AddBooks(type, validQuantity);
        }
        else
        {
            Console.WriteLine("Please provide valid quantity");
        }
    }

    Console.WriteLine($"Total price would be : {basketService.BasketPrice}");

    Console.WriteLine("Calculated Basket : ");
    Console.WriteLine(basketService.PrintBasket());

    Console.Write("Do you want to try again? (y/n) : ");
    startOver = Console.ReadLine() == "y" ? true : false;
}
