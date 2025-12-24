/*
Bus Seat Allocation Problem
- Seat allocation

- If the booking is cancelled, the next bus is allocated to it

- Unit test the code 
    - Seat Allocation Test (for allocation)
    - Seat Cancellation
 */

using System;

namespace BridgeLabz_Training.Review.BusSeatAllocation
{
    public class SeatAllocation
    {
        private int seat;
        
        public int Seat
        {
            get { return seat; }
        }

        public SeatAllocation(int seat)
        {
            if(seat == 0)
            {
                throw new ArgumentException("No seat has been booked");
            }
            seat++;
        }

        public void Book(bool book)
        {
            if(seat == 0)
            {
                throw new ArgumentException("The seat has not been booked");
            }
        }

        public void Check(bool check)
        {
            if (check == false)
            {
                throw new ArgumentException("The booking is cancelled. Change the bus");
            }
        }

    }
}
