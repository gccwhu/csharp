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
        public Order(string id, DateTime orderTime, Customer customer, List<OrderDetails> orderDetails)
        {
            ID = id;
            OrderTime = orderTime;
            Customer = customer;
            OrderDetails = orderDetails;
        }

        public override string ToString()
        {
            return $"Order ID: {ID}, Order Time: {OrderTime}, Customer: {Customer}, Order Details: {string.Join(", ", OrderDetails)},TotalPrice{TotalPrice}";
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   ID == order.ID &&
                   OrderTime == order.OrderTime &&
                   EqualityComparer<Customer>.Default.Equals(Customer, order.Customer) &&
                   EqualityComparer<List<OrderDetails>>.Default.Equals(OrderDetails, order.OrderDetails);
        }

        public override int GetHashCode()
        {
            int hashCode = -927193306;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + OrderTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetails>>.Default.GetHashCode(OrderDetails);
            return hashCode;
        }
    }
}
