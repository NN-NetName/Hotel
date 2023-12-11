using System;
using System.Collections.Generic;

namespace Hotels
{
    public class Hotel
    {
        public uint RoomCount { get; private set; } = 1000;
        public uint OccupiedRooms { get; private set; }
        public Hotel(uint _roomCount)
        {
            if (_roomCount <= 0 || _roomCount > RoomCount)
                throw new ArgumentException();
            RoomCount = _roomCount;
        }

        public void CheckIn()
        {
            if (RoomCount < 1)
                throw new ArgumentOutOfRangeException();
            OccupiedRooms ++;
            RoomCount --;
        }
        public void CheckOut()
        {
            if (OccupiedRooms < 1 || OccupiedRooms > 1000)
                throw new ArgumentOutOfRangeException();
            OccupiedRooms --;
            RoomCount ++;
        }
    }
}
