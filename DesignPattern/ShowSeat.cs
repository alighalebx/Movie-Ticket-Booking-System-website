using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class ShowSeat
{
    public int ShowSeatId { get; set; }

    public int Status { get; set; }

    public int Price { get; set; }

    public int CinemaSeatId { get; set; }

    public int ShowId { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual CinemaSeat CinemaSeat { get; set; } = null!;

    public virtual Show Show { get; set; } = null!;
}
