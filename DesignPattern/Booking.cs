using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class Booking
{
    public int BookingId { get; set; }

    public int NumberOfSeats { get; set; }

    public DateTime Timestamp { get; set; }

    public int Status { get; set; }

    public int UserId { get; set; }

    public int ShowId { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<ShowSeat> ShowSeats { get; } = new List<ShowSeat>();

    public virtual User User { get; set; } = null!;
}
