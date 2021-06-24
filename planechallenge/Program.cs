using System;
using System.Collections.Generic;
namespace PlaneChallenge
{
    class Program
    {
        public enum SeatPosition
        {
            Aisle,
            Middle,
            Window
        }
        public struct Seat
        {
            public string SeatNumber { get; set; }
            public bool isAvailable { get; set; }
            public SeatPosition SeatPosition { get; set; }
        }

        public class Plane
        {
            public string TailNumber { get; set; }
            public string FlightNumber { get; set; }
            public List<Seat> Seats { get; set; }

            public IEnumerable<Seat> getAvailableSets()
            {
                var availableSeats = new List<Seat>();
                foreach (Seat seatinfo in Seats)
                {
                    if (seatinfo.isAvailable)
                    {
                        availableSeats.Add(seatinfo);
                    }

                }
                return (IEnumerable<Seat>)availableSeats;

            }
        }
        static void Main(string[] args)
        {
            Plane plane = new Plane();
            plane.Seats = new List<Seat>();

            for (int i = 1; i <= 10; i++)
            {
            plane.Seats.Add(new Seat { SeatNumber = $"{i}a", isAvailable = true, SeatPosition = SeatPosition.Window });
            plane.Seats.Add(new Seat { SeatNumber = $"{i}b", isAvailable = true, SeatPosition = SeatPosition.Middle });
            plane.Seats.Add(new Seat { SeatNumber = $"{i}c", isAvailable = false, SeatPosition = SeatPosition.Aisle });
            plane.Seats.Add(new Seat { SeatNumber = $"{i}d", isAvailable = false, SeatPosition = SeatPosition.Aisle });
            plane.Seats.Add(new Seat { SeatNumber = $"{i}e", isAvailable = true, SeatPosition = SeatPosition.Middle });
            plane.Seats.Add(new Seat { SeatNumber = $"{i}f", isAvailable = true, SeatPosition = SeatPosition.Window });
            };


            foreach (Seat seat in plane.getAvailableSets())
            {
                Console.WriteLine($"Seat: {seat.SeatNumber}");
            }

        }
    }
}