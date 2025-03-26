using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace assignment5.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void TestAddOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.AddOrder(order);
            var orders = orderService.QueryOrders(o => o.ID == "001");
            Assert.AreEqual(1,orders.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order already exists!")]
        public void TestAddDuplicateOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.AddOrder(order);
            orderService.AddOrder(order); // Should throw exception
        }

        [TestMethod]
        public void TestRemoveOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.AddOrder(order);
            orderService.RemoveOrder(order);
            var orders = orderService.QueryOrders(o => o.ID == "001");
            Assert.AreEqual(0, orders.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order does not exist!")]
        public void TestRemoveNonExistentOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.RemoveOrder(order); // Should throw exception
        }

        [TestMethod]
        public void TestModifyOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.AddOrder(order);
            order.OrderDetails.Add(new OrderDetails(new Goods("Mouse", 50), 2));
            orderService.ModifyOrder(order);
            var orders = orderService.QueryOrders(o => o.ID == "001").ToList();
            Assert.AreEqual(1, orders.Count());
            Assert.AreEqual(2, orders[0].OrderDetails.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order does not exist!")]
        public void TestModifyNonExistentOrder()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("Alice", "123 Main St", "123-456-7890", "alice@example.com");
            Goods goods = new Goods("Laptop", 1000);
            OrderDetails orderDetails = new OrderDetails(goods, 1);
            List<OrderDetails> orderDetailsList = new List<OrderDetails> { orderDetails };
            Order order = new Order("001", DateTime.Now, customer, orderDetailsList);

            orderService.ModifyOrder(order); // Should throw exception
        }
    }
}
