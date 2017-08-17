/**
 * 建造者——创建型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> disc = new Dictionary<int, string>();
            disc.Add(1, "字符串");
            disc.Add(2, "9");
            disc.Add(3, "没有东西");
            List<TextConvert> model = RTFReader.CreatReader(disc);
            Console.WriteLine("——————————————");

            MazeDirection r1 = new MazeDirection(1);
            MazeDirection r2 = new MazeDirection(2);
            int[] isWall= { 1, 0, 1, 0 };
            int[] roomNumber = { 0, 2, 0, 3 };
            r1.CreateRoom(isWall, roomNumber);
            int[] isWall1 = { 0, 1, 0, 0 };
            int[] roomNumber1 = { 1, 0, 3, 5 };
            r2.CreateRoom(isWall1, roomNumber1);
            Console.ReadLine();
        }

        class RTFReader
        {
            public static List<TextConvert> CreatReader(Dictionary<int,string> str)
            {
                List<TextConvert> res = new List<TextConvert>();
                foreach (var temp in str)
                {
                    switch (temp.Key)
                    {
                        case 1:
                            TextConvert r1 = new StringConvert();
                            r1.ConvertCharacter(temp.Value);
                            res.Add(r1);
                            break;
                        case 2:
                            TextConvert r2 = new IntConvert();
                            r2.ConvertFontChange(Convert.ToInt32(temp.Value));
                            res.Add(r2);
                            break;
                        case 3:
                            TextConvert r3 = new NothingConvert();
                            r3.ConvertParagraph();
                            res.Add(r3);
                            break;
                    }
                }

                return res;
            }
        }

         class TextConvert
        {
            public virtual void ConvertCharacter(string _char) { }
            public virtual void ConvertFontChange(int font) { }
            public virtual void ConvertParagraph() { }
        }

        class StringConvert : TextConvert
        {
            public StringConvert() { }
            public override void ConvertCharacter(string _char)
            {
                Console.WriteLine("这是一个" + _char);
            }
        }

        class IntConvert: TextConvert
        {
            public IntConvert() { }
           

            public override void ConvertFontChange(int font)
            {
                Console.WriteLine("这是一个数字：" + font);
            }

        }

        class NothingConvert : TextConvert
        {
            public NothingConvert() { }

            public override void ConvertParagraph()
            {
                Console.WriteLine("没有变动");
            }
        }

    }
}
