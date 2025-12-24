using System;
using NUnit.Framework;
using BridgeLabz_Training.Review.BusSeatAllocation;

namespace BusSeatAllocation.Tests
{
    [TestFixture]
    public class BusSeatAllocationTests
    {
        private SeatAllocation seat;

        [SetUp]
        public void Setup()
        {
            seat = new seat();
        }
        
        // Seat Allocation Test
        [Test] 
        public void SeatAllocationTest_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                seat.Book("Seat not Booked"));
        }

        // Seat Cancellation
        [Test]
        public void SeatCancellation_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                seat.Check("Seat is cancelled"));
        }
    }
}