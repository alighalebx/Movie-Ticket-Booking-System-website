using Org.BouncyCastle.Utilities.IO;
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
    //public Show (Show target)
    //{
    //    if(target != null)
    //    {
    //        this.ShowId = target.ShowId;
    //        this.Date = target.Date;
    //        this.StartTime = target.StartTime;
    //        this.EndTime = target.EndTime;
    //        this.CinemaHall = target.CinemaHall;
    //        this.MovieId = target.MovieId;
    //    }
    //}

    //var queueDataTable1 = movieTicketSystemContext.Shows;
    //var lastDataRow1 = queueDataTable1.AsEnumerable().Last();
    public Show showClone(string s, int i)
    {
        return new Show
        {
            ShowId = i,
            Date = s,
            StartTime = StartTime,
            EndTime = EndTime,
            CinemaHallId = CinemaHallId,
            MovieId = MovieId
        };
    }
}
