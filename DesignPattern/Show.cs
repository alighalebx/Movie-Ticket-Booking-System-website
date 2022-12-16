using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class Show
{
    public int ShowId { get; set; }

    public string Date { get; set; } = null!;

    public string StartTime { get; set; } = null!;

    public string EndTime { get; set; } = null!;

    public int CinemaHallId { get; set; }

    public int MovieId { get; set; }

    public virtual CinemaHall CinemaHall { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<ShowSeat> ShowSeats { get; } = new List<ShowSeat>();
}
