

namespace DesignPattern;

public partial class CinemaHall
{
    public int CinemaHallId { get; set; }

    public string Name { get; set; } = null!;

    public int TotalSeats { get; set; }

    public int CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<CinemaSeat> CinemaSeats { get; } = new List<CinemaSeat>();

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
