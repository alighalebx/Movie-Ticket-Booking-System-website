
namespace DesignPattern;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int Amount { get; set; }

    public DateTime Timestamp { get; set; }

    public int DiscountCouponId { get; set; }

    public int RemoteTransactionId { get; set; }

    public int PaymentMethod { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
