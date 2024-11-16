using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbProductionModel
{
    public int IdproductionModel { get; set; }

    public string Automaker { get; set; } = null!;

    public int SeatingCapacity { get; set; }

    public string Gearbox { get; set; } = null!;

    public string Fuel { get; set; } = null!;

    public string Describe { get; set; } = null!;

    public int FuelConsumption { get; set; }

    public int ManufactureYear { get; set; }

    public int Star { get; set; }

    public virtual ICollection<TbCar> TbCars { get; set; } = new List<TbCar>();
}
