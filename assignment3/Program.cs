using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    abstract class Shape
    {
        public abstract double Area();
        public abstract bool IsShape();
    }   
    class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            if (length <= 0 || width <= 0)
                throw new Exception("长宽必须大于0！");   
            this.length = length;
            this.width = width;
        }
        public override double Area()
        {
            return length * width;
        }
        public override bool IsShape()
        {
            return length>=0&&width>=0;
        }
    }   
    class Square : Shape
    {
        private double side;
        public Square(double side)  
        {
            if (side<=0)
                throw new Exception("边长必须大于0！");
            this.side = side;
        }
        public override double Area()
        {
            return side * side;
        }
        public override bool IsShape()
        {
            return side>0;
        }
    }   
    class Triangle : Shape
    { 
        private double a;
        private double b;   
        private double c;
        public Triangle(double a, double b, double c)
        {
            if (a<=0||b<=0||c<=0)
                throw new Exception("边长必须大于0！");
            if (!(a + b > c && a + c > b && b + c > a)) 
                throw new Exception("不满足三角形三边条件");
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Area()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public override bool IsShape()
        {
            return a + b > c && a + c > b && b + c > a;
        }   

    }  
    static class ShapeFactory
    {
        private static Random random = new Random();
        public static Shape CreateRandomShape()
        {
            int type = random.Next(0, 3);
            switch (type)
            {
                case 0: // 长方形
                    return new Rectangle(
                        random.NextDouble() * 10 + 1,
                        random.NextDouble() * 10 + 1);

                case 1: // 正方形
                    return new Square(random.NextDouble() * 10 + 1);

                case 2: // 三角形
                    double a = random.NextDouble() * 10 + 1;
                    double b = random.NextDouble() * 10 + 1;
                    double minC = Math.Abs(a - b) + 0.1;
                    double maxC = a + b - 0.1;
                    double c = random.NextDouble() * (maxC - minC) + minC;

                    return new Triangle(a, b, c);

                default:
                    throw new InvalidOperationException("未知形状类型");
            }
        }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            double totalArea = 0;

            for (int i = 0; i < 10; i++)
            {
                Shape shape = ShapeFactory.CreateRandomShape();
                totalArea += shape.Area();
                Console.WriteLine($"第{i+1}个为{shape.GetType().Name}, 面积: {shape.Area():F2}");
            }
            Console.WriteLine($"\n总面积为: {totalArea:F2}");
        }
    }
}
