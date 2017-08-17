/**
 * 装饰器模式——结构型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            VisualComponent view = new TextView();
            //用边框装饰界面
            Decorator border = new BorderDecorator(view);
            //用滚动条装饰界面
            Decorator scroll = new ScrollDecorator(border);
            //滚动时
            scroll.Draw();
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 实际界面处理相关抽象接口
    /// </summary>
    abstract class VisualComponent
    {
        public abstract void Draw();
    }
    /// <summary>
    /// ui界面
    /// </summary>
    class TextView : VisualComponent
    {
        public override void Draw()
        {
            Console.WriteLine("文本UI界面");
        }
    }
    /// <summary>
    /// 装饰器
    /// </summary>
    class Decorator : VisualComponent
    {
        protected VisualComponent _component;
        public Decorator(VisualComponent component)
        {
            _component = component;
        }
        public  override void Draw()
        {
            if (_component != null)
            {
                _component.Draw();
            }
        }
    }
    /// <summary>
    /// 滚动装饰
    /// </summary>
    class ScrollDecorator: Decorator
    {
        public ScrollDecorator(VisualComponent component) :base(component) {}
        private int _scrollPosition;
        public int ScrollPosition
        {
            get { return _scrollPosition; }
            set { this._scrollPosition = value; }
        }
        public override void Draw()
        {
            base.Draw();
            ScrollTo();
        }
        private void ScrollTo()
        {
            Console.WriteLine("界面滚动了");
        }
    }
    /// <summary>
    /// 边框装饰
    /// </summary>
    class BorderDecorator : Decorator
    {
        public BorderDecorator(VisualComponent component) :base(component) { }
        private int _borderWeight;
        public int BorderWeight
        {
            get { return _borderWeight; }
            set { this._borderWeight = value; }
        }
        public override void Draw()
        {
            base.Draw();
            DrawBorder();
        }
        private void DrawBorder()
        {
            Console.WriteLine("画了边框");
        }
    }
}
