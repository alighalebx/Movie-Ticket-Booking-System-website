using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class CinemaSeat
{
    public int CinemaSeatId { get; set; }

    public int? SeatNumber { get; set; }

    public int? Type { get; set; }

    public int? CinemaHallId { get; set; }

    public virtual CinemaHall? CinemaHall { get; set; }

    public virtual ICollection<ShowSeat> ShowSeats { get; } = new List<ShowSeat>();
}
