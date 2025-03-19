using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public class node<T>
    {
        public T data { get; set; }
        public node<T> next { get; set; }   
        public node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }   
    public class GenericList<T>: node<T>
    {
        public node<T> Head;
        public GenericList() : base(default(T)) 
        {
            Head = null;
        }
        public void Add(T data)
        {
            node<T> newNode = new node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                node<T> temp = Head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }   
        public void ForEach(Action<T> action)
        {
            node<T> temp = Head;
            while (temp != null)
            {
                action(temp.data);
                temp = temp.next;
            }
        }   

    }   
    class Nodelist
    {
        static void Main(string[] args)
        {
            Random  random = new Random();
            GenericList<double> NodeList = new GenericList<double>();
            //随机生成10个数  
            for (int i = 0; i < 10; i++)
                NodeList.Add(10*random.NextDouble());
            //打印链表
            NodeList.ForEach(m=>Console.WriteLine(m));
            //求和
            double sum = 0;
            NodeList.ForEach(m=>sum+=m);
            Console.WriteLine("Sum of the list is: " + sum);
            //求最大值
            double max = 0;
            NodeList.ForEach(m => max = Math.Max(max, m));
            Console.WriteLine("Max of the list is: " + max);
            //求最小值  
            double min = 32768;    
            NodeList.ForEach(m => min = Math.Min(min, m));
            Console.WriteLine("Min of the list is: " + min);    
        }
    }
}
