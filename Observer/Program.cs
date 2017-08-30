/**
 * 观察者模式——行为型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteDataObject obj = new ConcreteDataObject();
            DataModel data = new DataModel { X = 1, Y = 23};
            obj.SetDataState(data);
            //具体观察者，指向具体目标
            Observer tab = new TabObserver(obj);
            Observer line = new LineObserver(obj);
            //增加观察者
            obj.Add(tab);
            obj.Add(line);
            //通知
            obj.Notify();
            //修改状态
            data.X = 2;
            obj.SetDataState(data);
            obj.Notify();
            Console.WriteLine("—————委托实现Notify—————");

            ConcreteDataSubject obj1 = new ConcreteDataSubject();
            data.Y = 50;
            obj1.SetDataState(data);
            //具体观察者，指向具体目标
            TabObserver1 tab1 = new TabObserver1(obj1);
            LineObserver1 line1 = new LineObserver1(obj1);
            obj1.Update+= new EventHandler(tab1.UpdateTab);
            obj1.Update += new EventHandler(line1.UpdateLine);
            obj1.Notify();
            //设置数据
            data.Y = 60;
            obj1.SetDataState(data);
            obj1.Notify();
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 观察者父类
    /// </summary>
    abstract class Observer
    {
        public abstract void Update();
    }
    class TabObserver : Observer
    {
        private DataModel _serverState;
        private ConcreteDataObject _subject;
        public TabObserver(ConcreteDataObject subject)
        {
            _subject = subject;
            _serverState = subject.GetDataState();
        }
        public override void Update()
        {
            //var data = _subject.GetDataState();
            Console.WriteLine("表格数据，X：" + _serverState.X + "Y:" + _serverState.Y);
          
        }
    }
    class LineObserver : Observer
    {
        private DataModel _serverState;
        private ConcreteDataObject _subject;
        public LineObserver(ConcreteDataObject subject)
        {
            _subject = subject;
            _serverState = subject.GetDataState();
        }
        public override void Update()
        {
            Console.WriteLine("柱状图数据，X：" + _serverState.X + "Y:" + _serverState.Y);
        }
    }

    /// <summary>
    /// 目标
    /// </summary>
    class DataObject
    {
        private List<Observer> _observers;
        /// <summary>
        /// 增加观察者对象
        /// </summary>
        /// <param name="obs"></param>
        public void Add(Observer obs)
        {
            if (_observers == null)
            {
                _observers = new List<Observer>();
            }
            _observers.Add(obs);
        }
        /// <summary>
        /// 删除观察者对象
        /// </summary>
        /// <param name="obs"></param>
        public void Delete(Observer obs)
        {
            if(_observers != null)
            {
                _observers.Remove(obs);
            }
        }
        /// <summary>
        /// 通知
        /// </summary>
        public virtual void Notify()
        {
            if (_observers == null)
            {
                return;
            }
            foreach(var temp in _observers)
            {
                temp.Update();
            }
        }
    }
    class ConcreteDataObject : DataObject
    {
        private DataModel _data;
        public DataModel GetDataState()
        {
            return _data;
        }
        public void SetDataState(DataModel data)
        {
            _data = data;
        }
    }
    /// <summary>
    /// 数据
    /// </summary>
    class DataModel
    {
        private int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        private int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
