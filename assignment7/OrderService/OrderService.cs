using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

    /**
     * The service class to manage orders
     * */
    public class OrderService {

        //the order list
        private List<Order> orders;


        public OrderService() {
            orders = new List<Order>();
        }

        private OrderDbContext dbContext = new OrderDbContext();

        public List<Order> GetAllOrders()
        {
            return dbContext.Orders.Include("Details").Include("Customer").ToList();
        }

        public Order GetOrder(int id)
        {
            return dbContext.Orders.Include("Details").Include("Customer").FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public void RemoveOrder(int orderId)
        {
            var order = dbContext.Orders.Find(orderId);
            if (order != null)
            {
                dbContext.Orders.Remove(order);
                dbContext.SaveChanges();
            }
        }

        public void UpdateOrder(Order newOrder)
        {
            var existingOrder = dbContext.Orders.Find(newOrder.OrderId);
            if (existingOrder != null)
            {
                dbContext.Entry(existingOrder).CurrentValues.SetValues(newOrder);
                dbContext.SaveChanges();
            }
        }
        

        public List<Order> QueryOrdersByProductName(string productName) {
            var query = orders
                    .Where(order => order.Details.Exists(item => item.ProductName == productName))
                    .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            return orders
                .Where(order => order.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice)
                .ToList();
        }

       

        public void Export(String fileName) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                xs.Serialize(fs, orders);
            }
        }

        public void Import(string path) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!orders.Contains(order)) {
                        orders.Add(order);
                    }
                });
            }
        }

        public object QueryByTotalAmount(float amout) {
            return orders
               .Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
        }
    }
}
