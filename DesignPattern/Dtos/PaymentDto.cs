namespace DesignPattern.Dtos
{
    public class PaymentDto
    {
        public int DiscountCouponId { get; set; }

        public DateTime Timestamp { get; set; }

        public int PaymentMethod { get; set; }

        public int BookingId { get; set; }

    }
}
