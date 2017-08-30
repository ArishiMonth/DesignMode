using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{

    //事件处理程序的委托
    delegate void EventHandler();

    class TabObserver1 
    {
        private DataModel _serverState;
        private ConcreteDataSubject _subject;
        public TabObserver1(ConcreteDataSubject subject)
        {
            _subject = subject;
            _serverState = subject.GetDataState();
        }
        public  void UpdateTab()
        {
            //var data = _subject.GetDataState();
            Console.WriteLine("表格数据，X：" + _serverState.X + "Y:" + _serverState.Y);

        }
    }
    class LineObserver1 
    {
        private DataModel _serverState;
        private ConcreteDataSubject _subject;
        public LineObserver1(ConcreteDataSubject subject)
        {
            _subject = subject;
            _serverState = subject.GetDataState();
        }
        public  void UpdateLine()
        {
            Console.WriteLine("柱状图数据，X：" + _serverState.X + "Y:" + _serverState.Y);
        }
    }

    /// <summary>
    /// 目标
    /// </summary>
    interface DataSubject
    {

        /// <summary>
        /// 通知
        /// </summary>
        void Notify();
    }
    class ConcreteDataSubject : DataSubject
    {
        private DataModel _data;
        public event EventHandler Update;
        public DataModel GetDataState()
        {
            return _data;
        }
        public void SetDataState(DataModel data)
        {
            _data = data;
        }
        public void Notify()
        {
            Update();
        }
    }
}
