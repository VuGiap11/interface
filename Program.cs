using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(4, 5);
            Console.WriteLine("DT = {0}", rectangle.getArea());
            rectangle.Resize(10);
            Console.WriteLine("DT moi = {0}", rectangle.getArea());

            Console.ReadKey();
        }

        interface IResizeable
        {
            void Resize(double percent);
        }
        interface IColorable
        {
            void HowToColor();
        }
        public class Shape
        {
            private string color = "green";
            private bool filled = true;
            public Shape() { }
            public Shape(string color, bool filled)
            {
                this.color = color;
                this.filled = filled;
            }

            public string getColor()
            {
                return color;
            }

            public void setColor(string color)
            {
                this.color = color;
            }
            public bool isFilled()
            {
                return filled;
            }
            public void setFilled(bool filled)
            {
                this.filled = filled;
            }
            public override string ToString()
            {
                return "A Shape with color of "
                        + getColor()
                        + " and "
                        + (isFilled() ? "filled" : "not filled");
            }
        }

        public class Circle : Shape, IResizeable
        {
            private double radius = 1.0;

            public Circle()
            {
            }
            public Circle(double radius)
            {
                this.radius = radius;
            }
            public Circle(double radius, String color, bool filled) : base(color, filled)
            {
                this.radius = radius;
            }
            public double getRadius()
            {
                return radius;
            }
            public void setRadius(double radius)
            {
                this.radius = radius;
            }
            public double getArea()
            {
                return radius * radius * Math.PI;
            }
            public double getPerimeter()
            {
                return 2 * radius * Math.PI;
            }
            public override string ToString()
            {
                return "A Circle with radius="
                        + getRadius()
                        + ", which is a subclass of "
                        + base.ToString();
            }
            public void Resize(double percent)
            {
                radius *= (1 + percent / 100);
            }
        }

        public class Rectangle : Shape, IResizeable
        {
            private double width = 1.0;
            private double length = 1.0;

            public Rectangle()
            {
            }

            public Rectangle(double width, double length)
            {
                this.width = width;
                this.length = length;
            }

            public Rectangle(double width, double length, string color, bool filled) : base(color, filled)
            {
                this.width = width;
                this.length = length;
            }

            public double getWidth()
            {
                return width;
            }

            public virtual void setWidth(double width)
            {
                this.width = width;
            }

            public double getLength()
            {
                return length;
            }

            public virtual void setLength(double length)
            {
                this.length = length;
            }

            public double getArea()
            {
                return width * this.length;
            }

            public double getPerimeter()
            {
                return 2 * (width + this.length);
            }

            public override string ToString()
            {
                return "A Rectangle with width="
                        + getWidth()
                        + " and length="
                        + getLength()
                        + ", which is a subclass of "
                        + base.ToString();
            }

            public void Resize(double percent)
            {
                width *= (1 + percent / 100);
            }
        }

        public class Square : Rectangle, IColorable
        {
            public Square()
            {
            }

            public Square(double side) : base(side, side)
            {
            }

            public Square(double side, string color, bool filled) : base(side, side, color, filled)
            {
            }

            public double getSide()
            {
                return getWidth();
            }

            public void setSide(double side)
            {
                base.setWidth(side);
                base.setLength(side);
            }
            public override void setWidth(double width)
            {
                setSide(width);
            }

            public override void setLength(double length)
            {
                setSide(length);
            }

            public override string ToString()
            {
                return "A Square with side="
                        + getSide()
                        + ", which is a subclass of "
                        + base.ToString();
            }

            public void HowToColor()
            {
                Console.WriteLine("Square color {0}", getColor());
            }
        }
    }
}
