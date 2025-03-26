using System;
using System.Collections.Generic;

namespace assignment5
{
    public class OrderDetails
    {
        public Goods Goods { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get => Goods.Price * Quantity; } 
        public OrderDetails(Goods goods, int quantity)
        {
            Goods = goods;
            Quantity = quantity;
        }
        //÷ÿ–¥ToString∑Ω∑®
        public override string ToString()
        {
            return $"Goods: {Goods}, Quantity: {Quantity},TotalPrice:{TotalPrice}";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Goods>.Default.Equals(Goods, details.Goods) &&
                   Quantity == details.Quantity;
        }

        public override int GetHashCode()
        {
            int hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
