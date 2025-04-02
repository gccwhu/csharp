using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment5
{
    public class OrderService
    {
        public List<Order> OrderList = new List<Order>();

        // 添加订单
        public void AddOrder(Order order)
        {
            //隐式调用Order.Equals方法    
            if (OrderList.Contains(order))
            {
                throw new Exception("Order already exists!");
            }
            OrderList.Add(order);
        }

        // 删除订单
        public void RemoveOrder(Order order)
        {
            if (!OrderList.Contains(order))
            {
                throw new Exception("Order does not exist!");
            }
            OrderList.Remove(order);
        }

        // 修改订单
        public void ModifyOrder(Order order)
        {
            var existingOrder = OrderList.FirstOrDefault(o => o.ID == order.ID);
            if (existingOrder == null)
            {
                throw new Exception("Order does not exist!");
            }
            RemoveOrder(existingOrder);
            AddOrder(order);    
        }
        public Order getOrder(string id)
        {
            return OrderList.FirstOrDefault(o => o.ID == id);
        }
        // 查询方法（使用LINQ）
        public IEnumerable<Order> QueryOrders(Func<Order, bool> QueryMethod) =>
            OrderList.Where(QueryMethod).OrderBy(o => o.ID);

        // 按订单号查询
        public IEnumerable<Order> QueryByOrderId(string id) =>
            QueryOrders(o => o.ID.Contains(id));

        // 按商品名称查询
        public IEnumerable<Order> QueryByGoods(string GoodsName) =>
            QueryOrders(o => o.OrderDetails.Any(d => d.Goods.Name.Contains(GoodsName)));

        // 按客户查询
        public IEnumerable<Order> QueryByCustomer(string customer) =>
            QueryOrders(o => o.Customer.Name.Contains(customer));

        // 按订单金额查询
        public IEnumerable<Order> QueryByAmountRange(double min, double max) =>
            QueryOrders(o => o.TotalPrice >= min && o.TotalPrice <= max);

        // 排序方法
        public void SortOrders(Func<Order, object> keySelector = null)
        {
            if (keySelector == null)
            {
                OrderList = OrderList.OrderBy(o => o.ID).ToList();
            }
            else
            {
                OrderList = OrderList.OrderBy(keySelector).ToList();
            }
        }
    }
}