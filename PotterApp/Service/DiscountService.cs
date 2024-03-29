using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterApp.Service
{
    internal class DiscountService
    {
        private readonly Dictionary<int, double> discountData = new()
        {
            {1, 0},
            {2, 0.05},
            {3, 0.1},
            {4, 0.20},
            {5, 0.25}
        };

        public double GetDiscount(int number)
        {
            return 1- discountData[number];
        }
    }
}
