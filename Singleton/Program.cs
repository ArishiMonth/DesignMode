/**
 * 单例模式——创建型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.Read();
        }
    }
    class Singleton
    {
        private static Singleton instance;
        private static readonly object syncRoot = new object();
        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {

                lock (syncRoot)
                {

                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

    }
}
