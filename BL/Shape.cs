using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public abstract class Shape
    {
        //MUST override in derived class
        public abstract void Draw();
        
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle is drawn");
        }
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Square is drawn");
        }
    }
}
