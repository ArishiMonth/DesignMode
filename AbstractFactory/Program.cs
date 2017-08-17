/**
 * 抽象工厂——创建型
 * 原型模式（Clone）
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> room = new Waze().CreateWaze();
            var r1 = room[0];
            Console.WriteLine("当前房间号：" + r1.roomNumber);
            r1.East.SetSide();
            r1.South.SetSide();
            r1.West.SetSide();
            r1.North.SetSide();
            Console.WriteLine("————————————");
            var r2 = room[1];
            Console.WriteLine("当前房间号：" + r2.roomNumber);
            r2.East.SetSide();
            r2.South.SetSide();
            r2.West.SetSide();
            r2.North.SetSide();
            Console.WriteLine("————————————");
            Console.ReadLine();
        }
    }

    abstract class MapSite
    {
       // public  string Name;
        public abstract void Enter();
    }
    class Room : MapSite
    {
        public int roomNumber;
        public Position North;
        public Position South;
        public Position East;
        public Position West;
        public Room(int number)
        {
            this.roomNumber = number;
        }

        public void SetSide(Direction orientate, MapSite map)
        {
            switch (orientate)
            {
                case Direction.North:
                    North = new North(map);
                    South = new South(new Wall());
                    East = new East(new Wall());
                    West = new West(new Wall());
                    break;
                case Direction.East:
                    East = new East(map);
                    North = new North(new Wall());
                    South = new South(new Wall());
                    West = new West(new Wall());
                    break;
                case Direction.South:
                    South = new South(map);
                    East = new East(new Wall());
                    North = new North(new Wall());
                    West = new West(new Wall());
                    break;
                case Direction.West:
                    West = new West(map);
                    South = new South(new Wall());
                    East = new East(new Wall());
                    North = new North(new Wall());
                    break;
            }
        }

        public override void Enter()
        {
            Console.WriteLine("进入了一个房间，房间号是：" + roomNumber);
        }
        /// <summary>
        /// 克隆方法（原型模式（创建型）的应用）
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {
            Room obj = new Room(this.roomNumber);

            obj.North = this.North;
            obj.South = this.South;
            obj.East = this.East;
            obj.West = this.West;
            return obj;
        }
    }

    class Wall : MapSite
    {
        //public  string Name = "墙";
        public override void Enter()
        {
            Console.WriteLine("这是一堵墙!");
        }
    }
    class Door : MapSite
    {
        private Room roomNumber1;
        private Room roomNumber2;
        private bool _isOpen;
        public Door(Room room1, Room room2, bool isOpen)
        {
            this.roomNumber1 = room1;
            this.roomNumber2 = room2;
            _isOpen = isOpen;
        }
        public override void Enter()
        {
            Console.WriteLine("这是一扇" + (_isOpen ? "开着" : "关闭") + "的门");
            Console.WriteLine("门前的房间号：" + roomNumber1.roomNumber + "，门后的房间号：" + roomNumber2.roomNumber);
        }
    }

    class Waze
    {
        public List<Room> CreateWaze()
        {
            List<Room> waze = new List<Room>();
            Room r1 = new Room(1001);
            Room r2 = new Room(1002);
            Door door = new Door(r1, r2, true);
            Door door1 = new Door(r2, r1, true);
            waze.Add(r1);
            waze.Add(r2);
            r1.SetSide(Direction.South,door);
            r2.SetSide(Direction.North, door1);
            
            return waze;
        }
    }

    abstract class Position
    {
        protected MapSite _map;
        public Position(MapSite map)
        {
            _map = map;
        }
        public abstract void SetSide();
        public abstract string GetSide();
    }

    class North: Position
    {

        public North(MapSite map)
            : base(map)
        {
        }
        public override void SetSide()
        {
            Console.WriteLine("这是北边");
            _map.Enter();
        }
        public override string GetSide()
        {
            return "";
        }
    }

    class South : Position
    {

        public South(MapSite map)
            : base(map)
        {
        }
        public override void SetSide()
        {
            Console.WriteLine("这是南边" );
            _map.Enter();
        }
        public override string GetSide()
        {
            return "";
        }
    }
    class East : Position
    {

        public East(MapSite map)
            : base(map)
        {
        }
        public override void SetSide()
        {
            Console.WriteLine("这是东边");
            _map.Enter();
        }
        public override string GetSide()
        {
            return"";
        }
    }
    class West : Position
    {

        public West(MapSite map)
            : base(map)
        {
        }
        public override void SetSide()
        {
            Console.WriteLine("这是西边");
            _map.Enter();
        }
        public override string GetSide()
        {
            return "";
        }
    }

    enum Direction
    {
        North = 1,
        South = 2,
        East = 3,
        West
    }
}
