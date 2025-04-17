using Mysqlx.Crud;
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
        //private List<Order> orders;


        public OrderService() {
            
        }

       

        public List<Order> GetAllOrders()
        {
            using (var dbContext=new OrderDbContext()) 
            {
                return dbContext.Orders.Include("Details").Include("Customer").ToList();
            }   
        }

        public Order GetOrder(int id)
        { using(var dbContext = new OrderDbContext()) 
            { 
                return dbContext.Orders
                    .Include("Details")
                    .Include("Customer").FirstOrDefault(o => o.OrderId == id); 
            }
                
        }
        //避免级联添加或修改customer和goods
        
        public void AddOrder(Order order)
        {
            using (var dbContext = new OrderDbContext())
            {
                //
                dbContext.Entry(order).State = System.Data.Entity.EntityState.Added;
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }   
        }

        public void RemoveOrder(int orderId)
        {
            using(var dbContext = new OrderDbContext())
            {
                var order = dbContext.Orders.Include("Details").Include("Customer").FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    dbContext.Orders.Remove(order);
                    dbContext.SaveChanges();
                }
            }   
        }

        public void UpdateOrder(Order newOrder)
        {
            using(var dbContext = new OrderDbContext())
            {
                dbContext.Entry(newOrder).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }   
        }
        

        public List<Order> QueryOrdersByProductName(string productName) {
            using (var dbContext = new OrderDbContext()) {
                var query = dbContext.Orders
                        .Where(order => order.Details.Exists(item => item.ProductName == productName))
                        .OrderBy(o => o.TotalPrice);
                return query.ToList();
            }
            
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            using(var dbContext = new OrderDbContext())
            {
                var query = dbContext.Orders
                        .Where(order => order.CustomerName == customerName)
                        .OrderBy(o => o.TotalPrice);
                return query.ToList();
            }   
        }

       

        public void Export(String fileName) {
            using (var dbContext = new OrderDbContext())
            {   
                XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create)) 
                {
                xs.Serialize(fs, dbContext.Orders);
                }
            }   
            
        }

        public void Import(string path) {
            using (var dbContext = new OrderDbContext())
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    List<Order> temp = (List<Order>)xs.Deserialize(fs);
                    temp.ForEach(order =>
                    {
                        if (!dbContext.Orders.Contains(order))
                        {
                            dbContext.Orders.Add(order);
                        }
                    });
                }
            }
            
        }

        public object QueryByTotalAmount(float amout) {
            using (var dbContext = new OrderDbContext())
            {
                return dbContext.Orders
                    .Where(order => order.TotalPrice > amout)
                    .OrderBy(o => o.TotalPrice).ToList();  
            }
          
        }
    }
}
