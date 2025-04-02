using System;
using System.Collections.Generic;

namespace assignment5
{
    public class Goods
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
        public override bool Equals(object obj)
        {
            return obj is Goods goods && goods != null &&
                   Name == goods.Name &&
                   Price == goods.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
