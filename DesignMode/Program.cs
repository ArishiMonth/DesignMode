using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Room> room = new Waze().CreateWaze();
            var r1 = room[0];
            r1.GetSide(Direction.South);
            Console.ReadLine();
        }
    }

    abstract class MapSite
    {
        public abstract void Enter();
    }
    class Room: MapSite
    {
        public int roomNumber;
        private Dictionary<Direction, MapSite> _map=new Dictionary<Direction, MapSite>();
        public Room(int number)
        {
            this.roomNumber = number;
        }
       
        public void SetSide (Direction orientate, MapSite map)
        {
            if (_map.Any(p => p.Key.Equals(orientate)))
            {
                _map[orientate] = map;
            }else
            {
                _map.Add(orientate, map);
            }
            Console.WriteLine("当前的方位是：" + orientate.ToString());
            map.Enter();

        }

        public void GetSide(Direction orientate)
        {
            Console.WriteLine("当前的方位是：" + orientate.ToString());
            _map[orientate].Enter();
            
        }

        public override void Enter()
        {
            Console.WriteLine("进入了一个房间，房间号是：" + roomNumber);
        }


    }

    class Wall: MapSite
    {
        public override void Enter()
        {
            Console.WriteLine("这是一堵墙!");
        }
    }
    class Door: MapSite
    {
        private Room roomNumber1;
        private Room roomNumber2;
        private bool _isOpen;
        public Door(Room room1, Room room2,bool isOpen)
        {
            this.roomNumber1 = room1;
            this.roomNumber2 = room2;
            _isOpen = isOpen;
        }
        public override void Enter()
        {
            Console.WriteLine("这是一扇"+ (_isOpen ? "开着" : "关闭") + "的门");
            Console.WriteLine("门前的房间号：" + roomNumber1.roomNumber + "，门后的房间号："+ roomNumber2.roomNumber);
        }
    }

    class Waze
    {
        public List<Room> CreateWaze()
        {
            List<Room> waze = new List<Room>();
            Room r1 = new Room(1001);
            Room r2 = new Room(1002);
            Door door = new Door(r1, r2,true);
            Door door1 = new Door(r2, r1, true);
            waze.Add(r1);
            waze.Add(r2);
            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, new Wall());
            r1.SetSide(Direction.South, door);
            r1.SetSide(Direction.West, new Wall());

            r2.SetSide(Direction.North, door1);
            r2.SetSide(Direction.East, new Wall());
            r2.SetSide(Direction.South, new Wall());
            r2.SetSide(Direction.West, new Wall());

            return waze;
        }
    }

    enum Direction
    {
        North=1,
        South=2,
        East=3,
        West
    }


}
