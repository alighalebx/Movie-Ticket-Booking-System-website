

namespace DesignPattern;

public partial class Cinema
{
    public int CinemaId { get; set; }

    public string Name { get; set; } = null!;

    public int TotalCinemaHalls { get; set; }

    public int CityId { get; set; }

    public virtual ICollection<CinemaHall> CinemaHalls { get; } = new List<CinemaHall>();

    public virtual City City { get; set; } = null!;
}
