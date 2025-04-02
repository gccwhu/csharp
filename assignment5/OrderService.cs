using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment5
{
    public class OrderService
    {
        public List<Order> OrderList = new List<Order>();

        // ��Ӷ���
        public void AddOrder(Order order)
        {
            //��ʽ����Order.Equals����    
            if (OrderList.Contains(order))
            {
                throw new Exception("Order already exists!");
            }
            OrderList.Add(order);
        }

        // ɾ������
        public void RemoveOrder(Order order)
        {
            if (!OrderList.Contains(order))
            {
                throw new Exception("Order does not exist!");
            }
            OrderList.Remove(order);
        }

        // �޸Ķ���
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
        // ��ѯ������ʹ��LINQ��
        public IEnumerable<Order> QueryOrders(Func<Order, bool> QueryMethod) =>
            OrderList.Where(QueryMethod).OrderBy(o => o.ID);

        // �������Ų�ѯ
        public IEnumerable<Order> QueryByOrderId(string id) =>
            QueryOrders(o => o.ID.Contains(id));

        // ����Ʒ���Ʋ�ѯ
        public IEnumerable<Order> QueryByGoods(string GoodsName) =>
            QueryOrders(o => o.OrderDetails.Any(d => d.Goods.Name.Contains(GoodsName)));

        // ���ͻ���ѯ
        public IEnumerable<Order> QueryByCustomer(string customer) =>
            QueryOrders(o => o.Customer.Name.Contains(customer));

        // ����������ѯ
        public IEnumerable<Order> QueryByAmountRange(double min, double max) =>
            QueryOrders(o => o.TotalPrice >= min && o.TotalPrice <= max);

        // ���򷽷�
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