using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbProductionModel
{
    public int IdproductionModel { get; set; }

    public string? Automaker { get; set; }

    public int? SeatingCapacity { get; set; }

    public string? Gearbox { get; set; }

    public string? Fuel { get; set; }

    public string? Describe { get; set; }

    public virtual ICollection<TbCar> TbCars { get; set; } = new List<TbCar>();
}
