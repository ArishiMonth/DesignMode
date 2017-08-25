/**
 * 职责链模式——行为型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //先用组合模式将对象组合，减少判断分支
            HelperHandler helper = new HelperHandler(DataType.默认);
            HelperHandler child = new HelperHandler(DataType.主界面);
            HelperHandler menu = new Application(DataType.菜单);
            //子对象组合
            child.SetChildren(new Dialog(DataType.弹框));
            child.SetChildren(new Button(DataType.按钮));
            //对象最后组合
            helper.SetChildren(menu);
            helper.SetChildren(child);
            //方法请求(默认)
            helper.HandleHelper(DataType.默认);
            Console.WriteLine("——————————");

            //方法请求(按钮)
            helper.HandleHelper(DataType.按钮);
            Console.WriteLine("——————————");

            //方法请求(弹框)
            helper.HandleHelper(DataType.弹框);
            Console.WriteLine("——————————");

            //方法请求(菜单)
            helper.HandleHelper(DataType.菜单);
            Console.ReadLine();
        }
    }
    class HelperHandler
    {
        protected List<HelperHandler> apps;
        public  DataType type;
        public HelperHandler(DataType type)
        {
            this.type = type;
        }
        public virtual void SetChildren(HelperHandler wigt)
        {
            if (apps == null)
            {
                apps = new List<HelperHandler>();
            }
            apps.Add(wigt);
        }
        public virtual void HandleHelper(DataType datatype)
        {
            if(apps==null || datatype== DataType.默认)
            {
                Console.WriteLine("缺省帮助信息");
                return;
            }
            foreach(var children in apps)
            {
                children.HandleHelper(datatype);
            }
        }
    }
    class Application: HelperHandler
    {
        public Application(DataType name) : base(name) { }
        public override void HandleHelper(DataType datatype)
        {
            if(datatype == type)
            {
                Console.WriteLine("菜单帮助信息");
            }
        }
    }
    class Dialog: HelperHandler
    {
        public Dialog(DataType name) : base(name) { }
        public override void HandleHelper(DataType datatype)
        {
            if (datatype == type)
            {
                Console.WriteLine("弹框帮助信息");
            }
        }
    }
    class Button : HelperHandler
    {
        public Button(DataType name) : base(name) { }
        public override void HandleHelper(DataType datatype)
        {
            if (datatype == type)
            {
                Console.WriteLine("按钮帮助信息");
                ShowHelper();
            }

        }
        private void ShowHelper()
        {
            Console.WriteLine("弹出帮助信息");
        }
    }
    enum DataType
    {
        按钮=1,
        弹框=2,
        主界面=3,
        菜单=4,
        默认=5
    }
}
