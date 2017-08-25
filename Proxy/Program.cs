/**
 * 代理模式——结构型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //客户端只知道代理对象，不知道真实对象
            Graphic proxy = new ImageProxy("图片a",200,300);
            var extent = proxy.GetExtent();
            Console.WriteLine("宽：" + extent.Weight + ",高：" + extent.Height);
            Console.WriteLine("————————");
            proxy.Draw();
            extent= proxy.GetExtent();
            Console.WriteLine("宽：" + extent.Weight + ",高：" + extent.Height);
            Console.ReadLine();
        }
    }
    abstract class Graphic
    {
        public abstract void Draw();
        public abstract Extent GetExtent();
        public abstract void Store();
        public abstract void Load();
    }
    /// <summary>
    /// 真实的对象
    /// </summary>
    class Image : Graphic
    {
        private string imgImp;
        private Extent extent;
        public Image(string fileName)
        {
            imgImp ="路径+文件名："+ fileName;
            extent = new Extent();
            extent.Height = 100;
            extent.Weight = 100;
        }
        public override void Draw()
        {
            Console.WriteLine("进行画图操作");
        }

        public override Extent GetExtent()
        {
            Console.WriteLine("获取尺寸");
            return extent;
        }

        public override void Load()
        {
            Console.WriteLine("加载图片");
        }

        public override void Store()
        {
            Console.WriteLine("存储图片");
        }
    }
    /// <summary>
    /// 代理对象
    /// </summary>
    class ImageProxy : Graphic
    {
        private Graphic _img;
        private string _fileName;
        private Extent extent;
        public ImageProxy(string fileName,int weight,int height)
        {
            _fileName = fileName;
            extent = new Extent();
            extent.Weight = weight;
            extent.Height = height;
        }
        public override void Draw()
        {
            if (_img == null)
            {
                _img = new Image(_fileName);
                Console.WriteLine("图片实例化");
            }
            _img.Draw();
        }

        public override Extent GetExtent()
        {
           if(_img == null)
            {
                return extent;
            }else
            {
                return _img.GetExtent();
            }
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Store()
        {
            throw new NotImplementedException();
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
