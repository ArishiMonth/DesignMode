/**
 * 命令模式——行为型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Command> commands = new List<Command>();
            commands.Add(new PasteCommand());
            commands.Add(new DrawCommand());

            Command macro = new MacroCommand(commands);
            macro.Execute();

            Console.ReadLine();
        }
    }
    interface Command
    {
        void Execute();
    }
    /// <summary>
    /// 执行所有请求
    /// </summary>
    class MacroCommand : Command
    {
        List<Command> _commands;
        public MacroCommand(List<Command> commands)
        {
            _commands = commands;
        }
        public void Execute()
        {
            foreach(var temp in _commands)
            {
                temp.Execute();
                Console.WriteLine("————————");
            }
        }
    }
    /// <summary>
    /// 复制命令
    /// </summary>
    class PasteCommand : Command
    {
        private Document doc;
        public void Execute()
        {
            if (doc == null)
            {
                doc = new Document();
            }
            doc.Open();
            doc.Paste();
        }
    }
    /// <summary>
    /// 画图命令
    /// </summary>
    class DrawCommand : Command
    {
        private Image img;
        public void Execute()
        {
            if (img == null)
            {
                img = new Image("图画");
            }
            Extent extent = img.GetExtent();
            Console.WriteLine("宽：" + extent.Weight + ",高：" + extent.Height);
            img.Draw();
        }
    }

    class Document
    {
        public  void Close()
        {
            Console.WriteLine("我的文档关闭了");
        }

        public  void Open()
        {
            Console.WriteLine("我的文档打开了");
        }

        public  void Revert()
        {
            Console.WriteLine("我的文档恢复了");
        }

        public  void Save()
        {
            Console.WriteLine("我的文档保存了");
        }
        public void Paste()
        {
            Console.WriteLine("我的文档复制了");
        }
    }

    class Image 
    {
        private string imgImp;
        private Extent extent;
        public Image(string fileName)
        {
            imgImp = "路径+文件名：" + fileName;
            extent = new Extent();
            extent.Height = 100;
            extent.Weight = 100;
        }
        public  void Draw()
        {
            Console.WriteLine("进行画图操作");
        }

        public  Extent GetExtent()
        {
            Console.WriteLine("获取尺寸");
            return extent;
        }

        public  void Load()
        {
            Console.WriteLine("加载图片");
        }

        public  void Store()
        {
            Console.WriteLine("存储图片");
        }
    }
    class Extent
    {
        private int height;
        public int Height
        {
            get { return height; }
            set { this.height = value; }
        }
        private int weight;
        public int Weight
        {
            get { return weight; }
            set { this.weight = value; }
        }
    }
}
