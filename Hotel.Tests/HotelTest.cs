using System;
using Xunit;
using Hotels;

namespace HotelTests
{
	public class HotelTest
	{
		[Fact]
		public void RoomCountSet_Success()
		{
			// Arrange + Act.
			const uint expectedRoomCount = 10;
			var hotel = new Hotel(expectedRoomCount);

			// Assert.
			Assert.Equal(expectedRoomCount, hotel.RoomCount);
		}

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void RoomCountSet_IfInvalid_Throws(uint roomCount)
        {
            // Arrange + Act + Assert.
            Assert.Throws<ArgumentException>(() => new Hotel(roomCount));
        }

        [Fact]
        public void CheckIn_IncrementsOccupiedRoomCount()
        {
            // Arrange.
            var hotel = new Hotel(10);

            // Act.
            hotel.CheckIn();

            // Assert.
            Assert.Equal((uint)1, hotel.OccupiedRooms);
        }

        [Fact]
        public void CheckInOverCapacity_Throws()
        {
            // Arrange.
            var hotel = new Hotel(1);

            // Act.
            hotel.CheckIn();

            // Assert.
            Assert.Throws<ArgumentOutOfRangeException>(() => hotel.CheckIn());
        }


        [Fact]
        public void CheckOut_DecrementsOccupiedRoomCount()
        {
            // Arrange.
            var hotel = new Hotel(1);

            hotel.CheckIn();

            // Act.
            hotel.CheckOut();

            // Assert.
            Assert.Equal((uint)0, hotel.OccupiedRooms);
        }

        [Fact]
        public void IfEmptyHotel_CheckOut_Throws()
        {
            // Arrange.
            var hotel = new Hotel(1);

            // Act.
            hotel.CheckIn();
            hotel.CheckOut();

            // Assert.
            Assert.Throws<ArgumentOutOfRangeException>(() => hotel.CheckOut());
        }
    }
}
