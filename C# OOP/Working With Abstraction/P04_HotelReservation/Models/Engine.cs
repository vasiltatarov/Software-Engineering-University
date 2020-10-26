using System;

namespace P04_HotelReservation.Models
{
    public class Engine
    {
        public void Procces()
        {
            var line = Console.ReadLine();

            var command = CommandParser.ParseCommand(line);
            var reservationPrice = PriceCalculator.GetTotalPrice(command.PricePerDay, command.Days, command.Seasons, command.Discount);

            Console.WriteLine($"{reservationPrice:F2}");
        }
    }
}
