using System;
using System.Collections.Generic;

namespace assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer("Alice", "123 Main St", "123-4567-7890", "alice@example.com");
            Goods goods1 = new Goods("Laptop", 1000);
            Goods goods2 = new Goods("Mouse", 50);
            OrderDetails orderDetails1 = new OrderDetails(goods1, 1);
            OrderDetails orderDetails2 = new OrderDetails(goods2, 2);
            List<OrderDetails> orderDetailsList1 = new List<OrderDetails> { orderDetails1, orderDetails2 };
            Order order1 = new Order("001", DateTime.Now, customer1, orderDetailsList1);

            orderService.AddOrder(order1);

            // ²éÑ¯¶©µ¥
            var orders = orderService.QueryOrders(o => o.Customer.Name == "Alice");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            // ÐÞ¸Ä¶©µ¥
            order1.OrderDetails.Add(new OrderDetails(new Goods("Keyboard", 100), 1));
            orderService.ModifyOrder(order1);

            // É¾³ý¶©µ¥
            orderService.RemoveOrder(order1);

            // ÅÅÐò¶©µ¥
            orderService.SortOrders();
        }
    }
}
