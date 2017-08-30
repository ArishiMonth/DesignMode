/**
 * 策略模式——行为型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //可根据想要使用的算法进行调用
            Composition com = new Composition(new SimpleCompositor());
            com.Repair();
            Console.WriteLine("——————————");
            //算法替换
            com.ChangeCompositor(new TxtCompositor());
            com.Repair();
            Console.WriteLine("——————————");
            //算法替换
            com.ChangeCompositor(new ArrayCompositor());
            com.Repair();

            Console.ReadLine();
        }
    }
    #region 对一系列算法进行封装
    interface Compositor
    {
        void Compose(Composition com);
    }
    class SimpleCompositor : Compositor
    {
        public void Compose(Composition com)
        {
            Console.WriteLine("简单换行算法");
        }
    }
    class TxtCompositor : Compositor
    {
        public void Compose(Composition com)
        {
            Console.WriteLine("文本换行算法");
        }
    }
    class ArrayCompositor : Compositor
    {
        public void Compose(Composition com)
        {
            Console.WriteLine("数组换行算法");
            com.Callback();
        }
    }
    #endregion
    /// <summary>
    /// 算法调用入口
    /// </summary>
    class Composition
    {
        private Compositor _com;
        public Composition(Compositor com)
        {
            this._com = com;
        }
        public void ChangeCompositor(Compositor com)
        {
            _com = com;
        }
        public void Repair()
        {
            _com.Compose(this);
        }
        public void Callback()
        {
            Console.WriteLine("方法回调");
        }
    }
}
