/**
 * 访问者模式——行为型
 * 适用于对象结构稳定不变，但相关操作经常变动
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Visitor v1 = new ConcreteVisitor1();
            Visitor v2 = new ConcreteVisitor2();
            Element e1 = new ConcreteElementA();
            Element e2 = new ConcreteElementB();
            e1.Accept(v1);
            e2.Accept(v1);
            Console.WriteLine("————————————");
            e1.Accept(v2);
            e2.Accept(v2);
            Console.ReadLine();
        }
    }
    interface Visitor
    {
        void VisitorConcreteElementA(ConcreteElementA elementA);
        void VisitorConcreteElementB(ConcreteElementB elementB);
    }
    class ConcreteVisitor1: Visitor
    {
        public void VisitorConcreteElementA(ConcreteElementA elementA)
        {
            elementA.OperationA();
            Console.WriteLine("A元素操作1");
        }
        public void VisitorConcreteElementB(ConcreteElementB elementB)
        {
            elementB.OperationB();
            Console.WriteLine("B元素操作1");
        }
    }
    class ConcreteVisitor2 : Visitor
    {
        public void VisitorConcreteElementA(ConcreteElementA elementA)
        {
            elementA.OperationA();
            Console.WriteLine("A元素其他操作2");
        }
        public void VisitorConcreteElementB(ConcreteElementB elementB)
        {
            elementB.OperationB();
            Console.WriteLine("B元素其他操作2");
        }
    }
    #region 节点
    abstract class Element
    {
        public abstract void Accept(Visitor v);
    }
    class ConcreteElementA : Element
    {
        public override void Accept(Visitor v)
        {
            v.VisitorConcreteElementA(this);
        }
        public void OperationA()
        {
            Console.WriteLine("A元素自身操作");
        }
    }
    class ConcreteElementB : Element
    {
        public override void Accept(Visitor v)
        {
            v.VisitorConcreteElementB(this);
        }
        public void OperationB()
        {
            Console.WriteLine("B元素自身操作");
        }
    }
    #endregion
}
