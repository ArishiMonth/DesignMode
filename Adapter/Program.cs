/**
 * 实现的该适配器为对象适配器，
 * 类适配器日常开发太常用了，就不实现了
 * 适配器——结构型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //画线调用
            Shape line = new Line();
            line.BoundingBox();
            line.CreateManipulator().Move();
            Console.WriteLine("——————————");
            //文本编辑调用
            Shape editor = new TextShape();
            editor.BoundingBox();
            editor.CreateManipulator().Move();
            Console.ReadLine();
        }
    }
    abstract class Shape
    {
        public abstract void BoundingBox();
        public abstract Manipulator CreateManipulator();
    }
    class Line : Shape
    {
        public override void BoundingBox()
        {
            Console.WriteLine("这是画线的！");
        }

        public override Manipulator CreateManipulator()
        {
            Console.WriteLine("画线——这是拖动或其他！");
            return new LineManipulator();
        }
    }
    class TextShape : Shape
    {
        /// <summary>
        /// 适配器方法(对象适配器)
        /// 将TextShape.BoundingBox方法与TextView.GetExtent进行适配
        /// </summary>
        public override void BoundingBox()
        {
            TextView editor = new TextViewAction();
            Console.WriteLine(editor.GetExtent());
        }
        /// <summary>
        /// 额外的功能
        /// </summary>
        /// <returns></returns>
        public override Manipulator CreateManipulator()
        {
            Console.WriteLine("文字编辑——这是拖动或其他！");
            return new TextManipulator();
        }
    }
    interface TextView
    {
         string GetExtent();
    }
    class TextViewAction: TextView
    {
        public string GetExtent()
        {
            return "以前的显示和编辑文本接口";
        }
    }
    abstract class Manipulator
    {
        public abstract void Move();
    }
    class LineManipulator : Manipulator
    {
        public override void Move()
        {
            Console.WriteLine("这条线移动了！");
        }
    }
    class TextManipulator : Manipulator
    {
        public override void Move()
        {
            Console.WriteLine("文本框移动了！");
        }
    }
}
