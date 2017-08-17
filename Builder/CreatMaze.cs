using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class MazeDirection
    {
        private CreatMaze pb;
        public MazeDirection(int index)
        {
            string assemblyName = "Builder";
            object[] args = new object[1];
            args[0] = index;
            //反射绑定类
            this.pb = (CreatMaze)Assembly.Load(assemblyName).CreateInstance(assemblyName + ".Room", false, BindingFlags.Default, null, args, null, null);
        }
        public void CreateRoom(int[] arr,int[] roomNumber)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                Direction tempOrient = (Direction)(i + 1);
                if (arr[i] == 0)
                {
                    pb.BuildDoor(pb.roomNumber, roomNumber[i], tempOrient);
                }else
                {
                    pb.BuildRoom(tempOrient);
                }
            }
        }
    }
    abstract class CreatMaze
    {
        public int roomNumber;
        public CreatMaze(int roomNumber)
        {
            this.roomNumber = roomNumber;
        }
        public abstract void BuildRoom(Direction orientate);
        public abstract void BuildDoor(int r1, int r2, Direction orientate);

    }

    class Room : CreatMaze
    {
        private Dictionary<Direction, MapSite> orient;
        public Room(int number) : base(number)
        {
            if (orient == null)
            {
                orient = new Dictionary<Direction, MapSite>();
            }
        }

        public override void BuildRoom(Direction orientate)
        {
            if (orient.Any(p => p.Key.Equals(orientate)))
            {
                orient[orientate] = new Wall();
            }else
            {
                orient.Add(orientate, new Wall());
            }
        }

        public override void BuildDoor(int r1, int r2, Direction orientate)
        {
            if (orient.Any(p => p.Key.Equals(orientate)))
            {
                orient[orientate] = new Door(r1,r2,false);
            }
            else
            {
                orient.Add(orientate, new Door(r1, r2, false));
            }
        }
        public void GetSide(Direction orientate)
        {
            Console.WriteLine("当前的方位是：" + orientate.ToString());

        }
        public void Enter(Direction orientate)
        {

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
    abstract class MapSite
    {
        // public  string Name;
        public abstract void Enter();
    }
    class Door : MapSite
    {
        private int roomNumber1;
        private int roomNumber2;
        private bool _isOpen;
        public Door(int room1, int room2, bool isOpen)
        {
            this.roomNumber1 = room1;
            this.roomNumber2 = room2;
            _isOpen = isOpen;
        }
        public override void Enter()
        {
            Console.WriteLine("这是一扇" + (_isOpen ? "开着" : "关闭") + "的门");
            Console.WriteLine("门前的房间号：" + roomNumber1 + "，门后的房间号：" + roomNumber2);
        }
    }
    enum Direction
    {
        East = 1,
        South = 2,
        West = 3,
        North=4
    }
}
