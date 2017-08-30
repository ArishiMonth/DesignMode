/**
 * 状态模式——行为型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPConnection tcp = new TCPConnection();
            tcp.Open();
            tcp.Acknowledge();
            tcp.Close();
            Console.ReadLine();
        }
    }
     class TCPState
    {
        public virtual void Open() { }
        public virtual void Close() { }
        public virtual void Acknowledge() { }
    }
    class Established : TCPState
    {
        public override void Open()
        {
            Console.WriteLine("链接打开成功，状态为链接已建立");
        }
    }
    class Listening : TCPState
    {
        public override void Acknowledge()
        {
            Console.WriteLine("此时链接正在监听中");
        }
    }
    class Closed : TCPState
    {
        public override void Close()
        {
            Console.WriteLine("链接关闭成功");
        }
    }
    /// <summary>
    /// 根据内部状态决定行为
    /// </summary>
    class TCPConnection
    {
        private TCPState state;
        public void Open()
        {
            if (state == null)
            {
                state = new Established();
            }else
            {
                Console.WriteLine("状态不对，不继续执行");
            }
            state.Open();
        }
        public void Acknowledge()
        {
            if(state.GetType() == typeof(Established))
            {
                state = new Listening();
            }
            else
            {
                Console.WriteLine("状态不对，不继续执行");
            }
            state.Acknowledge();
        }
        public void Close()
        {
            if (state.GetType() == typeof(Listening))
            {
                state = new Closed();
            }
            else
            {
                Console.WriteLine("状态不对，不继续执行");
            }
            state.Close();
        }
    }
    
}
