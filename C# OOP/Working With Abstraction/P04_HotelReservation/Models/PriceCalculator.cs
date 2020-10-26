namespace P04_HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int days, Season season, DiscountType discount = DiscountType.None)
        {
            decimal total = (pricePerDay * days) * (int)season;

            if (discount != 0)
            {
                total -= total * (int)discount / 100;
            }

            return total;
        }
    }
}
