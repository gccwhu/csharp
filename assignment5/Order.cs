using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment5
{
    public class Order
    {
        public string ID { get; set; }
        public DateTime OrderTime { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public double TotalPrice { get => OrderDetails.Sum(d => d.TotalPrice);  }
        public Order()
        {
            OrderTime = DateTime.Now;   
        }   
        public Order(string id, Customer customer,DateTime createTime)
        {
            ID = id;
            Customer = customer;
            OrderTime =createTime;
            OrderDetails = new List<OrderDetails>();
        }   
        public Order(string id, DateTime orderTime, Customer customer, List<OrderDetails> orderDetails)
        {
            ID = id;
            OrderTime = orderTime;
            Customer = customer;
            OrderDetails = orderDetails;
        }

        public override string ToString()
        {
            return $"Order ID: {ID}, \nOrder Time: {OrderTime}, \nCustomer: \n{Customer}, \nOrder Details: {string.Join(", ", OrderDetails)},\nTotalPrice:{TotalPrice}";
        }
        //重写Equals方法    
        public override bool Equals(object obj)
        {
            //只需要比较订单号  
            return obj is Order order &&order!=null &&
                   ID == order.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
