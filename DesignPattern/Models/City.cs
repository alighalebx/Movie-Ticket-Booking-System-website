using System;

namespace DesignPattern;

public partial class City
{

    private static City single_instance = null;
    public int CityId { get; set; }

    public string? Name { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Cinema> Cinemas { get; } = new List<Cinema>();


    public static City SingleInstance()
    {
        if(single_instance == null)
        {
            single_instance = new City();

        }
        return single_instance;
    }
}
