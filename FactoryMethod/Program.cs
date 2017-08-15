using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Aplication fac = new MyAplication();
            Document doc = fac.CreateDocument();
            doc.Open();
            doc.Close();
            List<Document> docs = new List<Document>();
            docs.Add(doc);
            fac.NewDocument(docs);
            Console.WriteLine("————以下为利用模板避免创建子类——————");

            Aplication fac1 = new Template<PageDocument>();
            Document doc1 = fac1.CreateDocument();
            docs.Add(doc1);
            doc1.Save();

            Aplication fac2 = new Template<MyDocument>();
            Document doc2 = fac2.CreateDocument();
            doc2.Save();
            Console.ReadLine();

        }
    }
    /// <summary>
    /// 抽象文档类
    /// </summary>
    abstract class Document
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void Save();
        public abstract void Revert();
    }
    /// <summary>
    /// 具体文档
    /// </summary>
    class MyDocument : Document
    {
        public override void Close()
        {
            Console.WriteLine("我的文档关闭了");
        }

        public override void Open()
        {
            Console.WriteLine("我的文档打开了");
        }

        public override void Revert()
        {
            Console.WriteLine("我的文档恢复了");
        }

        public override void Save()
        {
            Console.WriteLine("我的文档保存了");
        }
    }

    class PageDocument : Document
    {
        public override void Close()
        {
            Console.WriteLine("PageDocument文档关闭了");
        }

        public override void Open()
        {
            Console.WriteLine("PageDocument文档打开了");
        }

        public override void Revert()
        {
            Console.WriteLine("PageDocument文档恢复了");
        }

        public override void Save()
        {
            Console.WriteLine("PageDocument文档保存了");
        }
    }

    /// <summary>
    /// 工厂方法
    /// </summary>
    class Aplication
    {
        /// <summary>
        /// 工厂方法抽象定义
        /// </summary>
        public virtual Document CreateDocument() {
            return new MyDocument();
        }
        
        public void NewDocument(List<Document> docs)
        {
            Document doc = CreateDocument();
            docs.Add(doc);
            doc.Open();
        }
        public void OpenDocument()
        {

        }

    }
    /// <summary>
    /// 专门负责生产MyDocument的工厂
    /// </summary>
    class MyAplication : Aplication
    {
        public override Document CreateDocument()
        {
            return new MyDocument();
        }
    }
    /// <summary>
    /// 使用泛型实现工厂模板类
    /// </summary>
    /// <typeparam name="T">需要返回的类型</typeparam>
    class Template<T>: Aplication
        where T : Document, new()
    {
        public override Document CreateDocument()
        {
            return new T();
        }
    }

}
