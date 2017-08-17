/**
 * 组合模式——结构型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphic picture1 = new Picture();
            Graphic picture2 = new Picture();
            picture2.Add(new Text());
            picture1.Add(picture2);
            picture1.Draw();
            picture2 = picture1.GetChild(2);
            picture1.Remove(picture2);
            Console.ReadLine();
        }
    }
   abstract  class Graphic
    {
        protected List<Graphic> graphics;
        public abstract void Draw();
       
        public virtual void Add(Graphic g)
        {

        }
        public virtual void Remove(Graphic g)
        {

        }
        public virtual Graphic GetChild(int index)
        {
            return (graphics != null && graphics.Count > index)
                ? graphics[index] : null;
        }
    }
    class Picture : Graphic
    {
        public Picture()
        {
            if (graphics == null)
            {
                graphics = new List<Graphic>();
            }
            graphics.Add(new Line());
            graphics.Add(new Rectangle());
        }
        public override void Draw()
        {
            Console.WriteLine("画图操作");
            Console.WriteLine("——画图子操作开始——");
            foreach(var g in graphics)
            {
                g.Draw();
            }
        }
        public override void Add(Graphic g)
        {
            graphics.Add(g);
        }
        public override void Remove(Graphic g)
        {
            graphics.Remove(g);
        }
        public override Graphic GetChild(int index)
        {
            return (graphics!=null && graphics.Count > index)
                ? graphics[index]:null ;
        }

    }
    class Line : Graphic
    {
        public override void Draw()
        {
            Console.WriteLine("画线操作");
        }
    }
    class Rectangle : Graphic
    {
        public override void Draw()
        {
            Console.WriteLine("画矩形操作");
        }
    }
    class Text : Graphic
    {
        public override void Draw()
        {
            Console.WriteLine("写正文操作");
        }
    }
}
