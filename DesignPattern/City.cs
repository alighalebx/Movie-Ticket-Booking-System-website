using System;
using System.Collections.Generic;

namespace DesignPattern;

public partial class City
{
    public int CityId { get; set; }

    public string? Name { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Cinema> Cinemas { get; } = new List<Cinema>();
}
