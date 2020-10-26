using System;

namespace P04_HotelReservation.Models
{
    public class CommandParser
    {
        public decimal PricePerDay { get; set; }
        public int Days { get; set; }
        public Season Seasons { get; set; }
        public DiscountType Discount { get; set; }

        public static CommandParser ParseCommand(string text)
        {
            var args = text.Split();
            var discountType = "None";

            if (args.Length == 4)
            {
                discountType = args[3];
            }

            return new CommandParser
            {
                PricePerDay = decimal.Parse(args[0]),
                Days = int.Parse(args[1]),
                Seasons = Enum.Parse<Season>(args[2]),
                Discount = Enum.Parse<DiscountType>(discountType)
            };
        }
    }
}
