using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class Movie
{
    public string Name { get; set; } = null!;

    public string Descreption { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Realeasedate { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int MoiveId { get; set; }

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
