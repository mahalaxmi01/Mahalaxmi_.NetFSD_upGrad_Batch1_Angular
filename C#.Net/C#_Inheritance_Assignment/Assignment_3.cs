using System;
using System.Collections.Generic;
using System.Text;

namespace C__Inheritance_Assignment
{
    class Order
    {
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }

        public virtual double CalculateShippingCost()
        {
            return 50;
        }
    }

    class StandardOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 50;
        }
    }

    class ExpressOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 100;
        }
    }

    class InternationalOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 500;
        }
    }
    internal class Assignment_3
    {
        static void Main()
        {
            Order[] orders = new Order[3];

            orders[0] = new StandardOrder { OrderId = 1, OrderAmount = 1000 };
            orders[1] = new ExpressOrder { OrderId = 2, OrderAmount = 2000 };
            orders[2] = new InternationalOrder { OrderId = 3, OrderAmount = 3000 };

            foreach (Order order in orders)
            {
                Console.WriteLine("Order ID: " + order.OrderId);
                Console.WriteLine("Order Amount: " + order.OrderAmount);
                Console.WriteLine("Shipping Cost: " + order.CalculateShippingCost());
                Console.WriteLine("----------------------");
            }
        }
    }
}
